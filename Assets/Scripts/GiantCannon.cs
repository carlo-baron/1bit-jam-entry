using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantCannon : MonoBehaviour
{
    [SerializeField] protected GameObject cannon_bullet;
    [SerializeField] protected float delay;
    void Start()
    {
        StartCoroutine(SpawnCannonBullet());
    }

    public virtual IEnumerator SpawnCannonBullet()
    {
        while(true){
            GameObject newBullet = Instantiate(cannon_bullet, transform.position, Quaternion.identity);
            newBullet.GetComponent<Bullet>().direction = Vector2.down;
            yield return new WaitForSeconds(delay);
        }
    }
}
