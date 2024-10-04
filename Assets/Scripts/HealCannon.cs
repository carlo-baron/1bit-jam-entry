using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Custom.Directions;

public class HealCannon : GiantCannon
{
    public override IEnumerator SpawnCannonBullet()
    {
        while(true){
            GameObject newBullet = Instantiate(cannon_bullet, transform.position, Quaternion.identity);
            newBullet.GetComponent<Bullet>().direction = DirectionTypes.EightDirections()[Random.Range(0, DirectionTypes.EightDirections().Length - 1)];
            yield return new WaitForSeconds(delay);
        }
    }
}
