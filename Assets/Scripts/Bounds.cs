using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    CellularAutomata cellularAutomata;
    void Awake()
    {
        cellularAutomata = transform.parent.GetComponent<CellularAutomata>();
    }

    void LateUpdate()
    {
        int x = (int)transform.localPosition.x;
        int y = (int)transform.localPosition.y;
        int state = cellularAutomata.grid[x, y];
        if(y > 0){
            if (state == 1)
            {
                int top = cellularAutomata.grid[x, y + 1];
                int right = cellularAutomata.grid[x + 1, y];
                int left = cellularAutomata.grid[x - 1, y];

                if(top == 0){
                    print("bound");
                }
            }
        }
    }
}
