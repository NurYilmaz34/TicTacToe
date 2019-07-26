using TicTacToe.Data;
using UnityEngine;
using UnityEngine.UI;

public class Space : MonoBehaviour
{
    [SerializeField]
    private Text spaceText;
    private Button spaceButton;
    public SpaceData SpaceData      { get; set; }
    public IngameUIManager IngameUIManager  { get; set; }

    void Start()
    {
        spaceButton = GetComponent<Button>();
        spaceButton.onClick.AddListener(() => OnClickSpaceButton());
    }
    
    void Update()
    {

    }

    private void OnClickSpaceButton()
    {
        Debug.Log(SpaceData.Id);
        spaceText.text = IngameUIManager.GameManager.OrderPlayerType == PlayerType.X ? "X" : "O";
    }
}
