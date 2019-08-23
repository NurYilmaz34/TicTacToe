using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Data;
using TicTacToe.Managers;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SpaceData[] SpaceDataArray         { get; set; }
    public List<PlayerData> PlayerDataList   { get; set; }
    public PlayerType PlayerSide             { get; set; }
    public PlayerType AISide                 { get; set; }
    public PlayerType HumanSide              { get; set; }
    [SerializeField]
    public GameObject GameOverPanel;

    void Start()
    {
        CreateList();
        CreatePlayerList();
        WhoStarting(PlayerType.X);
        AIUserManager.Instance.GameManager = this;
    }

    public void CreateList()
    {
        SpaceDataArray = new SpaceData[CommonConstants.SpaceDataListLength];
        for (int i = 0; i < CommonConstants.SpaceDataListLength; i++)
        {
            SpaceDataArray[i] = new SpaceData(i, string.Empty);
        }     
    }

    private void CreatePlayerList()
    {
        PlayerDataList = new List<PlayerData>(); 
        for(int j = 0; j < CommonConstants.PlayerDataListLength; j++)
        {
            PlayerType playerType = j == 0 ? PlayerType.X : PlayerType.O;
            PlayerDataList.Add(new PlayerData(j, playerType));
        }
    }
  

    private void WhoStarting(PlayerType playerType)
    {
        PlayerSide = playerType;
    }

    private PlayerType GetPlayerSide()
    {
        return PlayerSide;
    }

    private PlayerType GetAiSide()
    {
        return AISide = PlayerType.O;
    }

    private PlayerType GetHumanSide()
    {
        return HumanSide = PlayerType.X;
    }

    private void OrderPlayers()
    {
        PlayerSide = (PlayerSide == PlayerType.O) ? PlayerType.X : PlayerType.O;
    }

    public void GameOver()
    {
        GameOverPanel.gameObject.SetActive(true);
        AIUserManager.Instance.IsGameOver = true;
    }

    public bool WinConditions(SpaceData[] spaceDataArray)
    {
        if (!string.IsNullOrEmpty(spaceDataArray[0].Value) && spaceDataArray[0].Value == spaceDataArray[1].Value && spaceDataArray[1].Value == spaceDataArray[2].Value)
        {
            print("winn1" + spaceDataArray[0].Value);
            return true;
        }
        else if (!string.IsNullOrEmpty(spaceDataArray[3].Value) && spaceDataArray[3].Value == spaceDataArray[4].Value && spaceDataArray[4].Value == spaceDataArray[5].Value)
        {
            print("winn2");
            return true;
        }
        else if (!string.IsNullOrEmpty(spaceDataArray[6].Value) && spaceDataArray[6].Value == spaceDataArray[7].Value && spaceDataArray[7].Value == spaceDataArray[8].Value)
        {
            print("winn3");
            return true;
        }
        else if (!string.IsNullOrEmpty(spaceDataArray[0].Value) && spaceDataArray[0].Value == spaceDataArray[3].Value  && spaceDataArray[6].Value == spaceDataArray[3].Value)
        {
            print("winn4");
            return true;
        }
        else if (!string.IsNullOrEmpty(spaceDataArray[1].Value) && spaceDataArray[1].Value == spaceDataArray[4].Value && spaceDataArray[7].Value == spaceDataArray[4].Value)
        {
            print("winn5");
            return true;
        }
        else if (!string.IsNullOrEmpty(spaceDataArray[2].Value) && spaceDataArray[2].Value == spaceDataArray[5].Value && spaceDataArray[8].Value == spaceDataArray[5].Value)
        {
            print("winn6");
            return true;
        }
        else if (!string.IsNullOrEmpty(spaceDataArray[0].Value) && spaceDataArray[0].Value == spaceDataArray[4].Value && spaceDataArray[8].Value == spaceDataArray[4].Value)
        {
            print("winn7");
            return true;
        }
        else if (!string.IsNullOrEmpty(spaceDataArray[2].Value) && spaceDataArray[2].Value == spaceDataArray[4].Value && spaceDataArray[6].Value == spaceDataArray[4].Value)
        {
            print("winn8");
            return true;
        }
        else
        {
            //AIUserManager.Instance.IsGameOver = false;
            //OrderPlayers();
            return false;
        }
        
    }

    private bool IsGameOver()
    {
        //if (IsAllSpaceDataFull())
        //{
        //    GameOver();
        //    return true;
        //}
        //else
     return false;
    }

    private bool IsAllSpaceDataFull(SpaceData[] spaceDataAray)
    {
        for (int i = 0; i < CommonConstants.SpaceDataListLength; i++)
        {
            if (string.IsNullOrEmpty(spaceDataAray[i].Value))
                return false;
        }

        return true;
    }

    public int Score(SpaceData[] spaceDataAray, int Depth)
    {
        if (WinConditions(spaceDataAray))
        {
            if (PlayerSide == PlayerType.O)
                return  Depth - 10;

            else
                return  Depth + 10;
        }
        else
        {
            if (IsAllSpaceDataFull(spaceDataAray))
                return Depth;
            else
                return 0;
        }
            
    }
    
}
