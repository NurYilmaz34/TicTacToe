using TicTacToe.Data;
using UnityEngine;
using UnityEngine.UI;

public class MatchResultPanel : MonoBehaviour
{
    [SerializeField]
    private Text MatchResultText;
    [SerializeField]
    private Button RestartButton;
    [SerializeField]
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
        ResetSpace();
    }

    private void ResetSpace()
    {
        for (int i = 0; i < CommonConstants.SpaceDataListLength; i++)
        {
            IngameUIManager.Spaces[i].ResetSpace();
        }
    }

    public void SetText(MatchResultType matchResultType)
    {
        switch (matchResultType)
        {
            case MatchResultType.Draw:
                MatchResultText.text = LocalizationConstants.DRAW.ToUpper();
                break;
            case MatchResultType.Win:
                MatchResultText.text = LocalizationConstants.WIN.ToUpper();
                break;
            case MatchResultType.Lose:
                MatchResultText.text = LocalizationConstants.LOSE.ToUpper();
                break;
            default:
                break;
        } 
    }
}
