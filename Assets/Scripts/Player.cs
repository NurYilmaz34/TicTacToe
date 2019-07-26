using TicTacToe.Data;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Image panel;
    [SerializeField]
    private Text playerTxt;
    private Button playerButton;
    public PlayerData PlayerData { get; set; }

    private void Start()
    {
        playerButton = GetComponent<Button>();
    }
}
