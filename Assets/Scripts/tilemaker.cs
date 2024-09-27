using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class tilemaker : MonoBehaviour
{
    public GameObject tile;
    private float cellSize = 1f;
    private uint size = 20;
    void Start()
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Vector3 position = new Vector2(i * cellSize, j * cellSize);
                Instantiate(tile, transform.position + position, Quaternion.identity, transform);
            }
        }

    }


}
