using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            for(int i = 0; i < Directions().Length; i++){
                GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
                newBullet.GetComponent<Bullet>().direction = Directions()[i];
            }
            yield return new WaitForSeconds(delay);
        }
    }

    Vector2[] Directions(){
        List<Vector2> dirs = new List<Vector2>();
        float[] angles = new float[]{0f,45f,90f,135f,180f,225f,270f,315f};
        for(int i = 0; i < angles.Length; i++){
            float x = Mathf.Cos(angles[i] * Mathf.Deg2Rad);
            float y = Mathf.Sin(angles[i] * Mathf.Deg2Rad);
            dirs.Add(new Vector2(x, y));
        }

        return dirs.ToArray();
    }
}
