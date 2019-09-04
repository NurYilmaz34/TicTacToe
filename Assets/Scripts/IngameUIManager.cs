using System;
using System.Linq;
using System.Collections;
using TicTacToe.Data;
using TicTacToe.Managers;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class IngameUIManager : MonoBehaviour
{
    [SerializeField]
    private Player PlayerX;
    [SerializeField]
    private Player PlayerO;
    [SerializeField]
    public Space[] Spaces;
    [SerializeField]
    public GameManager GameManager;
    [SerializeField]
    private MatchResultPanel MatchResultPanel;
    [SerializeField]
    private GameObject ProcessingPanel;

    void Start()
    {
        SetUI();
        SetSpaceData();
        SetPlayerData();
    }
    private void SetUI()
    {
        PlayerX.Panel.GetComponent<Image>().color = Color.white;
        PlayerO.Panel.GetComponent<Image>().color = Color.red;
    }
    public void GetGameState()
    {
        MatchResultPanel.gameObject.SetActive(true);
        GameManager.SetPlayerSide(PlayerType.X);

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

            ProcessingPanel.gameObject.SetActive(true);
            PlayerX.Panel.GetComponent<Image>().color = Color.red;
            PlayerO.Panel.GetComponent<Image>().color = Color.white;
            StartCoroutine(WaitAIUser());       
        }
    }

    public IEnumerator WaitAIUser()
    {
        yield return new WaitForSeconds(1.5f);

        int spaceId = GameManager.GetSpaceID(GameManager.SpaceDataArray);
        Spaces[spaceId].Write();
        Spaces[spaceId].spaceButton.interactable = false;
        ProcessingPanel.gameObject.SetActive(false);
        PlayerO.Panel.GetComponent<Image>().color = Color.red;
        PlayerX.Panel.GetComponent<Image>().color = Color.white;

        if (GameManager.IsGameOver())
            GetGameState();  
        else
            GameManager.ChangePlayerSide();
    }
    
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


    public void OpenPanel(PanelType panelType)
    {
        CloseAllPanels();
        switch (panelType)
        {
            case PanelType.MenuPanel:
                MatchResultPanel.gameObject.SetActive(true);
                break;
            case PanelType.MatchResultPanel:
                MatchResultPanel.gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }

    private void CloseAllPanels()
    {
        MatchResultPanel.gameObject.SetActive(false);
        MatchResultPanel.gameObject.SetActive(false);
        MatchResultPanel.gameObject.SetActive(false);
        MatchResultPanel.gameObject.SetActive(false);
    }
}
