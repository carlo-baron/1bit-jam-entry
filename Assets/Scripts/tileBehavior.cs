using UnityEngine;

public class tileBehavior : MonoBehaviour
{
    CellularAutomata cellularAutomata;
    PlayerMovement player;

    void Awake()
    {
        cellularAutomata = transform.parent.GetComponent<CellularAutomata>();
        player = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerMovement>();
    }
    void OnMouseOver()
    {
        if(player.mine > 0){
            if(Input.GetMouseButtonDown(1)){
                cellularAutomata.grid[(int)transform.localPosition.x, (int)transform.localPosition.y] = 0;
                player.mine--;
            }
        }
    }
}
