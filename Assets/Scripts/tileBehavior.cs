using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class tileBehavior : MonoBehaviour
{
    public float gravity = 9.81f;
    private Vector2 velocity;
    private bool isFalling = true;

    void Update()
    {
        if (isFalling)
        {
            velocity.y -= gravity * Time.deltaTime;

            transform.position += (Vector3)velocity * Time.deltaTime;

            if (IsGrounded())
            {
                isFalling = false;
                velocity = Vector2.zero;
                // SnapToGround();
            }
        }else if(!IsGrounded()){
            isFalling = true;
        }

        
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.5f), Vector2.down, 0.1f);
        return hit.collider != null;
    }

    private void SnapToGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity);
        if (hit.collider != null)
        {
            transform.position = new Vector3(transform.position.x, hit.point.y + 0.5f, transform.position.z);
            isFalling = false;
            velocity = Vector2.zero;
        }
    }
}
