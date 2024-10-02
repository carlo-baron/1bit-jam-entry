using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    public float moveSpeed;
    Rigidbody2D rb;


    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");   
        moveInput.y = Input.GetAxisRaw("Vertical");

        Vector2 newVelocity = new Vector2(moveInput.x, moveInput.y);
        rb.velocity = newVelocity.normalized * moveSpeed;
    }
}
