using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected float speed;
    [SerializeField] protected int mineValue;
    [SerializeField] protected int damage;
    GameObject player;
    void Awake(){
        player = GameObject.FindGameObjectWithTag("player");
    }

    void Update(){
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        if(health <= 0) Die();
    }

    void Die(){
        PlayerMovement player = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerMovement>();
        player.mine = Mathf.Clamp(player.mine + mineValue, 0, 400);
        Destroy(gameObject);
    }
}
