using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBullet : Bullet
{
    [SerializeField] int health;

    void Update(){
        if(health <= 0){
            Destroy(gameObject);
        }
    }
    public override void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("enemy")){
            other.GetComponent<IDamageable>().Hit(damage);
            health--;
        }
    }
}
