using UnityEngine;

public class tileBehavior : MonoBehaviour
{
    CellularAutomata cellularAutomata;

    void Awake()
    {
        cellularAutomata = transform.parent.GetComponent<CellularAutomata>();
    }
    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(1)){
            cellularAutomata.grid[(int)transform.localPosition.x, (int)transform.localPosition.y] = 0;
        }
    }
}
