using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Custom.Directions;

public class HealCannon : MonoBehaviour
{
    [SerializeField] protected GameObject cannon_bullet;
    [SerializeField] protected float delay;
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
            newBullet.GetComponent<Bullet>().direction = DirectionTypes.EightDirections()[Random.Range(0, DirectionTypes.EightDirections().Length - 1)];
            yield return new WaitForSeconds(delay);
        }
    }
}
