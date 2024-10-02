using UnityEngine;

public class tileBehavior : MonoBehaviour
{
    CellularAutomata cellularAutomata;

    void Awake()
    {
        cellularAutomata = transform.parent.GetComponent<CellularAutomata>();
    }
    void OnMouseDown()
    {
        cellularAutomata.grid[(int)transform.localPosition.x, (int)transform.localPosition.y] = 0;
    }
}
