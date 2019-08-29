using System;
using System.Linq;
using System.Collections;
using TicTacToe.Data;
using TicTacToe.Managers;
using UnityEngine;
using UnityEngine.UI;

public class IngameUIManager : MonoBehaviour
{
    [SerializeField]
    private Player PlayerX;
    [SerializeField]
    private Player PlayerO;
    [SerializeField]
    private Space[] Spaces;
    [SerializeField]
    public GameManager GameManager;
    [SerializeField]
    private MatchResultPanel MatchResultPanel;
    [SerializeField]
    private GameObject DusunPanel;

    void Start()
    {
        SetUI();
        SetSpaceData();
        SetPlayerData();
    }

    private void SetUI()
    {
        PlayerX.Panel.GetComponent<Image>().color = Color.blue;
    }

    public void GetGameState()
    {
        MatchResultPanel.gameObject.SetActive(true);

        if (GameManager.WinnerPlayer == PlayerType.X)
            MatchResultPanel.SetText(MatchResultType.Win);
        else if (GameManager.WinnerPlayer == PlayerType.O)
            MatchResultPanel.SetText(MatchResultType.Lose);
        else if (GameManager.WinnerPlayer == null)
            MatchResultPanel.SetText(MatchResultType.Draw);
    }
    
    public void ChangeUI()
    {
        if (GameManager.IsGameOver())
        {
            GetGameState();
        }
        else
        {
            GameManager.ChangePlayerSide();

            DusunPanel.gameObject.SetActive(true);
            PlayerX.Panel.GetComponent<Image>().color = Color.white;
            PlayerO.Panel.GetComponent<Image>().color = Color.blue;
            StartCoroutine(WaitAIUser());       
        }
    }

    public IEnumerator WaitAIUser()
    {
        yield return new WaitForSeconds(1.5f);

         int spaceId = GameManager.GetSpaceID(GameManager.SpaceDataArray);
         Spaces[spaceId].Write();

         DusunPanel.gameObject.SetActive(false);
         PlayerO.Panel.GetComponent<Image>().color = Color.white;
         PlayerX.Panel.GetComponent<Image>().color = Color.blue;

        if (GameManager.IsGameOver())
            GetGameState();
        else
            GameManager.ChangePlayerSide();
    }

    //IEnumerator ChangeColor()
    //{
    //    yield return 
    //}

    private void SetSpaceData()
    {
        for (int i = 0; i < CommonConstants.SpaceDataListLength; i++)
        {
            Spaces[i].SpaceData = GameManager.SpaceDataArray.First(lstData => lstData.Id == i);
            Spaces[i].IngameUIManager = this;
        }
    }

    private void SetPlayerData()
    {
        PlayerX.PlayerData = GameManager.PlayerDataList.First(lstPlayerData => lstPlayerData.PlayerType == PlayerType.X);
        PlayerO.PlayerData = GameManager.PlayerDataList.First(lstPlayerData => lstPlayerData.PlayerType == PlayerType.O);
    }
    

}
