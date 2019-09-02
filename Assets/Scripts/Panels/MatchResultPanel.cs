using TicTacToe.Data;
using UnityEngine;
using UnityEngine.UI;

public class MatchResultPanel : MonoBehaviour
{
    [SerializeField]
    private Text MatchResultText;
    [SerializeField]
    private Button RestartButton;
    private IngameUIManager IngameUIManager;
    //[SerializeField]
    //private Space Space;

    private void Start()
    {
        RestartButton.onClick.AddListener(() => OnClickRestartButton());
    }

    public void OnClickRestartButton()
    {
        gameObject.SetActive(false);
        //Space.ResetSpace();
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
