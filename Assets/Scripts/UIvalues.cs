using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIvalues : MonoBehaviour
{
    [SerializeField] PlayerMovement player;

    [SerializeField] TextMeshProUGUI HP;
    [SerializeField] TextMeshProUGUI Mine;
    [SerializeField] GameObject gameOver;

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
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
