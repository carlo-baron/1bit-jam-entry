using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject megaBullet;
    [SerializeField] Transform firePoint;
    [SerializeField] float megaBulletDelay;
    GameObject bullet;

    void Start(){
        bullet = bulletPrefab;
    }

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = mousePos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,angle);

        if(Input.GetMouseButtonDown(0)){
            GameObject newBullet = Instantiate(bullet, firePoint.position, transform.rotation);
            newBullet.GetComponent<Bullet>().direction = direction;
        }
    }

    public IEnumerator MegaBullet(){
        bullet = megaBullet;
        yield return new WaitForSeconds(megaBulletDelay);
        bullet = bulletPrefab;
    }

    
}
