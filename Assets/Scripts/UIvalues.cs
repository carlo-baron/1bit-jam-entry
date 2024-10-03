using TMPro;
using UnityEngine;

public class UIvalues : MonoBehaviour
{
    [SerializeField] PlayerMovement player;

    [SerializeField] TextMeshProUGUI HP;
    [SerializeField] TextMeshProUGUI Mine;
    void Update()
    {
        HP.text = $"HP: {player.PlayerHealth}";
        Mine.text = $"HP: {player.mine}";
    }
}
