using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TicTacToe.Data;

public class Score : MonoBehaviour
{

    [SerializeField]
    private Text ScoreText;
    private Button ScoreButton;
    public ScoreData ScoreData { get; set; }

    void Start()
    {
        ScoreButton = GetComponent<Button>();
    }

    void Update()
    {

    }
}
