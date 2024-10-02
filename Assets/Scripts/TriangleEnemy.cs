using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleEnemy : Enemy, IDamageable
{
    [SerializeField] int Health;
    [SerializeField] float Speed;
    void Start(){
        health = Health;
        speed = Speed;
    }

    void IDamageable.Hit(int damage)
    {
        health -= damage;
    }
}
