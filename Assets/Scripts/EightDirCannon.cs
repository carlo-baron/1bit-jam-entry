using System.Collections;
using UnityEngine;
using Custom.Directions;

public class EightDirCannon : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] float delay;
    void Start()
    {
        StartCoroutine(SpawnBullets());
    }

    IEnumerator SpawnBullets(){
        while(true){
            for(int i = 0; i < DirectionTypes.EightDirections().Length; i++){
                GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
                newBullet.GetComponent<Bullet>().direction = DirectionTypes.EightDirections()[i];
            }
            yield return new WaitForSeconds(delay);
        }
    }

    
}
