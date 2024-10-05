using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IDamageable
{
    Vector2 moveInput;
    public float moveSpeed;
    Rigidbody2D rb;
    [SerializeField] int health;
    public int mine = 0;

    AudioManage audioPlayer;

    public int PlayerHealth
    {
        get { return health; }
        private set { health = value; }
    }
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioPlayer = FindObjectOfType<AudioManage>();
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
        health = Mathf.Clamp(health-damage, 0, 100);
        mine = Mathf.Clamp(mine-damage, 0, 100);
        audioPlayer.PlaySFX(audioPlayer.playerHit);
    }

    public void Heal(int heal){
        if(health < 100){
            health = Mathf.Clamp(health+heal, 0, 100);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("boost")){
            Destroy(other.gameObject);
            audioPlayer.PlaySFX(audioPlayer.boostCollect);
            StartCoroutine(GetComponentInChildren<Gun>().MegaBullet());
        }
    }
}
