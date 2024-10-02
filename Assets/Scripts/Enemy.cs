using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected int health;
    protected float speed;
    GameObject player;
    void Awake(){
        player = GameObject.FindGameObjectWithTag("player");
    }

    void Update(){
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        if(health <= 0) Die();
    }

    void Die(){
        Destroy(gameObject);
    }
}
