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
    AudioManage audioPlayer;

    void Awake(){
        Time.timeScale = 1;
        audioPlayer = FindObjectOfType<AudioManage>();
    }

    void Update()
    {
        HP.text = $"HP: {player.PlayerHealth}";
        Mine.text = $"Mine: {player.mine}";

        if(player.PlayerHealth <= 0){
            audioPlayer.PlaySFX(audioPlayer.gameOver);
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }
        if(tileMaker.objGridLength <= 0){
            audioPlayer.PlaySFX(audioPlayer.win);
            Winner.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Restart(){
        audioPlayer.PlaySFX(audioPlayer.retry);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
