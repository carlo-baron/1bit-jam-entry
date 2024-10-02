using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CellularAutomata : MonoBehaviour
{
    int camSize = 1000;
    int cellSize = 50;
    public int[,] grid;
    public GameObject[,] objGrid { get; private set; }
    int rows;
    int cols;

    public float delay;
    public GameObject Tile;
    void Start()
    {
        rows = camSize / cellSize;
        cols = camSize / cellSize;
        grid = makeGrid(rows, cols);
        objGrid = new GameObject[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                grid[i, j] = 1;
            }
        }

        StartCoroutine(DelayedUpdate(delay));
    }

    private IEnumerator DelayedUpdate(float delay)
    {
        while (true)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i, j] == 0)
                    {
                        Destroy(objGrid[i, j]);
                    }
                    else if (grid[i, j] == 1)
                    {
                        if (objGrid[i, j] == null)
                        {
                            Vector3 newPos = new Vector2(i, j);
                            objGrid[i, j] = Instantiate(Tile, transform.position + newPos, Quaternion.identity, transform);
                        }
                    }
                }
            }

            int[,] nextGrid = makeGrid(rows, cols);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int currentState = grid[i, j];
                    if (currentState == 1)
                    {
                        if (j > 0)
                        {
                            int below = grid[i, j - 1];
                            if (below == 0)
                            {
                                nextGrid[i, j - 1] = 1;
                            }
                            else
                            {
                                nextGrid[i, j] = 1;
                            }
                        }
                        else
                        {
                            nextGrid[i, j] = 1;
                        }
                    }
                }
            }

            grid = nextGrid;
            yield return new WaitForSeconds(delay);
        }
    }

    int[,] makeGrid(int rows, int cols)
    {
        int[,] array = new int[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                array[i, j] = 0;
            }
        }

        return array;
    }
}
