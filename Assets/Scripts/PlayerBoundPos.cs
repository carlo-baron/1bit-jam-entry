using UnityEngine;

public class PlayerBoundPos : MonoBehaviour
{
    CellularAutomata cells;
    void Awake()
    {
        cells = transform.parent.GetComponent<CellularAutomata>();
    }

    public void UpdatePos()
    {
        int x = (int)transform.localPosition.x;
        int y = (int)transform.localPosition.y;

        if (x >= 0 && x < cells.grid.GetLength(0) && y >= 0 && y < cells.grid.GetLength(1) && cells.grid[x, y] == 0)
        {
            transform.position = FindAvailablePos();
        }
    }

    Vector2 FindAvailablePos(){
        int randomX = Random.Range(0, cells.grid.GetLength(0));
        int randomY = Random.Range(0, cells.grid.GetLength(1));
        int attempt = cells.grid.Length;

        while(attempt > 0){
            GameObject obj = cells.objGrid[randomX, randomY];
            if(obj != null){
                return obj.transform.position;
            }
            attempt--;
        }
        return Vector2.zero;
    }

}
