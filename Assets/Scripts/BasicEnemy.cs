using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy, IDamageable
{
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("player")){
            other.gameObject.GetComponent<IDamageable>().Hit(damage);
        }
    }

    void IDamageable.Hit(int damage)
    {
        health -= damage;
    }
}
