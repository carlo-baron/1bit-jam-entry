using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSpawner : MonoBehaviour
{
    [SerializeField] GameObject boost;
    [SerializeField] float delay;
    BoxCollider2D boxCollider;
    bool checkForTiles = false;
    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        if (!checkForTiles)
        {
            Collider2D[] colliders = Physics2D.OverlapBoxAll(boxCollider.bounds.center, boxCollider.bounds.size, 0f);
            int count = 0;
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject.CompareTag("tile"))
                {
                    count++;
                }
            }
            if (count <= 0)
            {
                StartCoroutine(Spawn());
                checkForTiles = true;
            }
        }
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            Instantiate(boost, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(delay);
        }
    }
}
