using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IDamageable
{
    Vector2 moveInput;
    public float moveSpeed;
    Rigidbody2D rb;
    [SerializeField] int health;
    public int mine = 0;

    public int PlayerHealth
    {
        get { return health; }
        private set { health = value; }
    }
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        Vector2 newVelocity = new Vector2(moveInput.x, moveInput.y);
        rb.velocity = newVelocity.normalized * moveSpeed;
    }

    public void Hit(int damage)
    {
        health -= damage;
    }

    public void Heal(int heal){
        if(health < 100){
            health = Mathf.Clamp(health+heal, 0, 100);
        }
    }
}
