using System;
using System.Linq;
using TicTacToe.Data;
using UnityEngine;

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

    void Start()
    {
        SetSpaceData();
        SetPlayerData();
    }

    public void ChangeOrderPlayer()
    {
        GameManager.IsGameOver();
    }

    private void SetSpaceData()
    {
        for (int i = 0; i < CommonConstants.SpaceDataListLength; i++)
        {
            Spaces[i].SpaceData = GameManager.SpaceDataList.First(lstData => lstData.Id == i);
            Spaces[i].IngameUIManager = this;
        }
    }

    private void SetPlayerData()
    {
        PlayerX.PlayerData = GameManager.PlayerDataList.First(lstPlayerData => lstPlayerData.PlayerType == PlayerType.X);
        PlayerO.PlayerData = GameManager.PlayerDataList.First(lstPlayerData => lstPlayerData.PlayerType == PlayerType.O);
    }
    

}
