using System.Collections;
using UnityEngine;
using Custom.Directions;

public class EightDirCannon : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] float delay;
    BoxCollider2D boxCollider;
    bool checkForTiles = false;
    AudioManage audioPlayer;

    void Awake(){
        boxCollider = GetComponent<BoxCollider2D>();
        audioPlayer = FindObjectOfType<AudioManage>();
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
                StartCoroutine(SpawnBullets());
                checkForTiles = true;
            }
        }
    }


    IEnumerator SpawnBullets(){
        while(true){
            audioPlayer.PlaySFX(audioPlayer.bullet);
            for(int i = 0; i < DirectionTypes.EightDirections().Length; i++){
                GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
                newBullet.GetComponent<Bullet>().direction = DirectionTypes.EightDirections()[i];
            }
            yield return new WaitForSeconds(delay);
        }
    }

    
}
