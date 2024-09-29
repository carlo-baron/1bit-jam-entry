using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cell : MonoBehaviour
{
    int camSize = 1000;
    int cellSize = 100;
    public int[,] grid;
    GameObject[,] objGrid;
    int rows;
    int cols;


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
                grid[i, j] = 0;
                Vector3 newPos = new Vector2(i, j);
                objGrid[i, j] = Instantiate(Tile, transform.position + newPos, Quaternion.identity, transform);
            }
        }

        StartCoroutine(DelayedUpdate(0.5f));
    }

    private IEnumerator DelayedUpdate(float delay)
    {
        while (true)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Color temp = objGrid[i, j].GetComponent<SpriteRenderer>().color;
                    temp.a = grid[i, j];
                    objGrid[i, j].GetComponent<SpriteRenderer>().color = temp;
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
