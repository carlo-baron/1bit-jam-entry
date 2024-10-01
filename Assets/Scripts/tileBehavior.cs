using UnityEngine;

public class tileBehavior : MonoBehaviour
{
    CellularAutomata cellularAutomata;
    Bounds bounds;

    void Awake()
    {
        bounds = transform.parent.GetComponent<Bounds>();
        cellularAutomata = transform.parent.GetComponent<CellularAutomata>();
    }
    void OnMouseDown()
    {
        cellularAutomata.grid[(int)transform.localPosition.x, (int)transform.localPosition.y] = 0;
        bounds.UpdateBounds();
    }
}
