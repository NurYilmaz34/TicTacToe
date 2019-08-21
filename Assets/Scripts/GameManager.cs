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

    public bool IsGameOver()
    {
        AIUserManager.Instance.GetAIPlayedSpace(SpaceDataArray);
        if (!string.IsNullOrEmpty(SpaceDataArray[0].Value) && SpaceDataArray[0].Value == SpaceDataArray[1].Value && SpaceDataArray[1].Value == SpaceDataArray[2].Value)
        {
            print("winn1" + SpaceDataArray[0].Value);
            GameOver();
            return false;
        }
        else if (!string.IsNullOrEmpty(SpaceDataArray[3].Value) && SpaceDataArray[3].Value == SpaceDataArray[4].Value && SpaceDataArray[4].Value == SpaceDataArray[5].Value)
        {
            print("winn2");
            GameOver();
            return false;
        }
        else if (!string.IsNullOrEmpty(SpaceDataArray[6].Value) && SpaceDataArray[6].Value == SpaceDataArray[7].Value && SpaceDataArray[7].Value == SpaceDataArray[8].Value)
        {
            print("winn3");
            GameOver();
            return false;
        }
        else if (!string.IsNullOrEmpty(SpaceDataArray[0].Value) && SpaceDataArray[0].Value == SpaceDataArray[3].Value  && SpaceDataArray[6].Value == SpaceDataArray[3].Value)
        {
            print("winn4");
            GameOver();
            return false;
        }
        else if (!string.IsNullOrEmpty(SpaceDataArray[1].Value) && SpaceDataArray[1].Value == SpaceDataArray[4].Value && SpaceDataArray[7].Value == SpaceDataArray[4].Value)
        {
            print("winn5");
            GameOver();
            return false;
        }
        else if (!string.IsNullOrEmpty(SpaceDataArray[2].Value) && SpaceDataArray[2].Value == SpaceDataArray[5].Value && SpaceDataArray[8].Value == SpaceDataArray[5].Value)
        {
            print("winn6");
            GameOver();
            return false;
        }
        else if (!string.IsNullOrEmpty(SpaceDataArray[0].Value) && SpaceDataArray[0].Value == SpaceDataArray[4].Value && SpaceDataArray[8].Value == SpaceDataArray[4].Value)
        {
            print("winn7");
            GameOver();
            return false;
        }
        else if (!string.IsNullOrEmpty(SpaceDataArray[2].Value) && SpaceDataArray[2].Value == SpaceDataArray[4].Value && SpaceDataArray[6].Value == SpaceDataArray[4].Value)
        {
            print("winn8");
            GameOver();
            return false;
        }
        else if (IsAllSpaceDataFull())
        {
            return true;
        }
        else
        {
            AIUserManager.Instance.IsGameOver = false;
            OrderPlayers();
            return true;
        }
        
    }
    
    private bool IsAllSpaceDataFull()
    {
        for (int i = 0; i < CommonConstants.SpaceDataListLength; i++)
        {
            if (string.IsNullOrEmpty(SpaceDataArray[i].Value))
                return false;
        }

        return true;
    }

    public int Score(int Depth)
    {
        if (IsGameOver())
        {
            if (PlayerSide == PlayerType.O)
                return Depth - 10;

            else
                return Depth + 10;
        }
        else
            return Depth;
        
    }
    
}
