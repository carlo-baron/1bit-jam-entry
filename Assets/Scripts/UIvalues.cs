using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIvalues : MonoBehaviour
{
    [SerializeField] PlayerMovement player;
    [SerializeField] CellularAutomata tileMaker;

    [SerializeField] TextMeshProUGUI HP;
    [SerializeField] TextMeshProUGUI Mine;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject Winner;

    void Awake(){
        Time.timeScale = 1;
    }

    void Update()
    {
        HP.text = $"HP: {player.PlayerHealth}";
        Mine.text = $"HP: {player.mine}";

        if(player.PlayerHealth <= 0){
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }
        if(tileMaker.objGridLength <= 0){
            Winner.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
