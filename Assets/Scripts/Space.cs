using TicTacToe.Data;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Space : MonoBehaviour
{
    [SerializeField]
    private Text spaceText;
    private Button spaceButton;
    public SpaceData SpaceData              { get; set; }
    public IngameUIManager IngameUIManager  { get; set; }
    
    void Start()
    {
        spaceButton = GetComponent<Button>();
        spaceButton.onClick.AddListener(() => OnClickSpaceButton());
    }
    
    void Update()
    {
        
        //if (IngameUIManager.GameManager.PlayerSide == PlayerType.O)
        //    spaceButton.interactable = false;
        //else
        //    spaceButton.interactable = true;
    }

    public void Write()
    {
        spaceText.text =  "O";
        SpaceData.Value = "O";
    }

    public void OnClickSpaceButton()
    {
        if (!string.IsNullOrEmpty(spaceText.text))
            return;

        spaceText.text = IngameUIManager.GameManager.PlayerSide == PlayerType.X ? "X" : "O";
        SpaceData.Value = IngameUIManager.GameManager.PlayerSide.ToString();
        spaceButton.interactable = false;
        IngameUIManager.ChangeUI();
    }
}
