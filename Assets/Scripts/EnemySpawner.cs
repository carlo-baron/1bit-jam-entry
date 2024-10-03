using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;

    [SerializeField] float mapSize;
    [SerializeField] float enemyDelay;

    void Start()
    {
        mapSize /= 2;
        StartCoroutine(RandomEnemy());
    }

    IEnumerator RandomEnemy(){
        while(true){
            int chance = Random.Range(0, 100);

            switch(chance){
                case <= 60:
                    SpawnRandomEnemy(enemies[0], IsChunk(), 5);
                    break;
                case <= 90:
                    SpawnRandomEnemy(enemies[1], IsChunk(), 3);
                    break;
                case <= 100:
                    SpawnRandomEnemy(enemies[2]);
                    break;
            }

            yield return new WaitForSeconds(enemyDelay);
        }
    }

    bool IsChunk(){
        int randomChance = Random.Range(0, 100);
        return randomChance <= 75 ? false : true;
    }

    void SpawnRandomEnemy(GameObject enemy, bool chunk = false, int chunkSize = 0){
        if(chunk){
            Vector2 spawnPoint = SpawnLocation();
            for(int i = 0; i < chunkSize; i++){
                Instantiate(enemy, spawnPoint, Quaternion.identity);
            }
        }else{
            Instantiate(enemy, SpawnLocation(), Quaternion.identity);
        }
    }

    Vector2 SpawnLocation(){
        Vector2 location = new Vector2();
        int randomSide = Random.Range(0,4);

        switch(randomSide){
            case 0:
                //top
                location = new Vector2(Random.Range(-mapSize, mapSize), transform.position.y + mapSize);
                break;
            case 1:
                //right
                location = new Vector2(transform.position.x + mapSize, Random.Range(-mapSize, mapSize));
                break;
            case 2:
                //bottom
                location = new Vector2(Random.Range(-mapSize, mapSize), transform.position.y - mapSize);
                break;
            case 3:
                //left
                location = new Vector2(transform.position.x - mapSize, Random.Range(-mapSize, mapSize));
                break;
        }
        
        return location;
    }
}
