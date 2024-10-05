using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantCannon : MonoBehaviour
{
    [SerializeField] GameObject cannon_bullet;
    [SerializeField] float delay;
    BoxCollider2D boxCollider;
    bool checkForTiles = false;

    void Awake(){
        boxCollider = GetComponent<BoxCollider2D>();
    }
    
    void Update(){
        if(!checkForTiles){
            Collider2D[] colliders = Physics2D.OverlapBoxAll(boxCollider.bounds.center, boxCollider.bounds.size, 0f);
            int count = 0;
            foreach (Collider2D collider in colliders){
                if(collider.gameObject.CompareTag("tile")){
                    count++;
                }
            }
            if(count <= 0){
                StartCoroutine(SpawnCannonBullet());
                checkForTiles = true;
            }
        }
    }

    IEnumerator SpawnCannonBullet()
    {
        while(true){
            GameObject newBullet = Instantiate(cannon_bullet, transform.position, Quaternion.identity);
            newBullet.GetComponent<Bullet>().direction = Vector2.down;
            yield return new WaitForSeconds(delay);
        }
    }
}
