using UnityEngine;

public class tileBehavior : MonoBehaviour
{
    CellularAutomata cellularAutomata;
    PlayerMovement player;
    AudioManage audioPlayer;

    void Awake()
    {
        cellularAutomata = transform.parent.GetComponent<CellularAutomata>();
        player = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerMovement>();
        audioPlayer = FindObjectOfType<AudioManage>();
    }
    void OnMouseOver()
    {
        if(player.mine > 0){
            if(Input.GetMouseButtonDown(1)){
                audioPlayer.PlaySFX(audioPlayer.tileBreak);
                cellularAutomata.grid[(int)transform.localPosition.x, (int)transform.localPosition.y] = 0;
                player.mine--;
            }
        }
    }
}
