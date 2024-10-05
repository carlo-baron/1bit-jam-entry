using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] protected int damage;
    public Vector2 direction = new Vector2();
    public virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void Start(){

        rb.velocity = direction.normalized * speed;
    }

    void OnBecameInvisible(){
        Destroy(gameObject);
    }

    public virtual void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("enemy")){
            other.GetComponent<IDamageable>().Hit(damage);
            Destroy(gameObject);
        }
    }
}
