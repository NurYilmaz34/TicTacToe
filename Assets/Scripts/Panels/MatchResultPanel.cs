using TicTacToe.Data;
using UnityEngine;
using UnityEngine.UI;

public class MatchResultPanel : MonoBehaviour
{
    [SerializeField]
    private Text MatchResultText;

    private void Start()
    {

    }

    private void Update()
    {

    }

    public void SetText(MatchResultType matchResultType)
    {
        switch (matchResultType)
        {
            case MatchResultType.Draw:
                MatchResultText.text = LocalizationConstants.DRAW;
                break;
            case MatchResultType.Win:
                MatchResultText.text = LocalizationConstants.WIN;
                break;
            case MatchResultType.Lose:
                MatchResultText.text = LocalizationConstants.LOSE;
                break;
            default:
                break;
        } 
    }
}
