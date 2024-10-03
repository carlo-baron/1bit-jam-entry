using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy, IDamageable
{
    [SerializeField] int Health;
    [SerializeField] float Speed;
    [SerializeField] int MineValue;
    [SerializeField] int Damage;
    void Start(){
        health = Health;
        speed = Speed;
        mineValue = MineValue;
        damage = Damage;
    }

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
