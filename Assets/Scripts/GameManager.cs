using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Data;
using TicTacToe.Managers;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<SpaceData> SpaceDataList     { get; set; }
    public List<PlayerData> PlayerDataList   { get; set; }
    public PlayerType PlayerSide             { get; set; }
    public PlayerType AISide                 { get; set; }
    public PlayerType HumanSide              { get; set; }
    private int Depth = 0;
    [SerializeField]
    public GameObject GameOverPanel;

    void Start()
    {
        CreateList();
        CreatePlayerList();
        WhoStarting(PlayerType.X);
    }

    private void CreateList()
    {
        SpaceDataList = new List<SpaceData>();
        for (int i = 0; i < CommonConstants.SpaceDataListLength; i++)
        {
            string spaceValue = GetPlayerSide().ToString();
            SpaceDataList.Add(new SpaceData(i, spaceValue));
            //string[] SpaceDataList = new string[CommonConstants.SpaceDataListLength];
        }     
    }

    public List<SpaceData> CopySpace()
    {
        List<SpaceData> CopySpaceDataList = SpaceDataList.ConvertAll(lstSpaceData => new SpaceData(lstSpaceData.Id, lstSpaceData.Value));

        return CopySpaceDataList;
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
        if (SpaceDataList[0].Value == SpaceDataList[1].Value && SpaceDataList[1].Value == SpaceDataList[2].Value)
        {
            print("winn1" + SpaceDataList[0].Value);
            GameOver();
            return false;
        }
        else if (SpaceDataList[3].Value == SpaceDataList[4].Value && SpaceDataList[4].Value == SpaceDataList[5].Value)
        {
            print("winn2");
            GameOver();
            return false;
        }
        else if (SpaceDataList[6].Value == SpaceDataList[7].Value && SpaceDataList[7].Value == SpaceDataList[8].Value)
        {
            print("winn3");
            GameOver();
            return false;
        }
        else if (SpaceDataList[0].Value == SpaceDataList[3].Value  && SpaceDataList[6].Value == SpaceDataList[3].Value)
        {
            print("winn4");
            GameOver();
            return false;
        }
        else if (SpaceDataList[1].Value == SpaceDataList[4].Value && SpaceDataList[7].Value == SpaceDataList[4].Value)
        {
            print("winn5");
            GameOver();
            return false;
        }
        else if (SpaceDataList[2].Value == SpaceDataList[5].Value && SpaceDataList[8].Value == SpaceDataList[5].Value)
        {
            print("winn6");
            GameOver();
            return false;
        }
        else if (SpaceDataList[0].Value == SpaceDataList[4].Value && SpaceDataList[8].Value == SpaceDataList[4].Value)
        {
            print("winn7");
            GameOver();
            return false;
        }
        else if (SpaceDataList[2].Value == SpaceDataList[4].Value && SpaceDataList[6].Value == SpaceDataList[4].Value)
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
            if (string.IsNullOrEmpty(SpaceDataList[i].Value))
                return false;
        }

        return true;
    }

    private int Score(int Depth)
    {
        if (IsGameOver())
        {
            if (PlayerSide == PlayerType.O)
                return Depth + 10;

            else
                return Depth - 10;
        }
        else
            return 0;
        
    }

    //public PlayerType Maximum()
    //{
    //    if (PlayerSide == PlayerType.O)
    //        return GetAiSide();
    //    else
    //        return GetHumanSide();
    //}

    //private int MinimaxScore(int Depth, int SpaceId, PlayerType Maximum, int[] Scores)
    //{
    //     if (!IsGameOver())
    //    {
    //        if (Depth == CommonConstants.StartTotalDepth)
    //            return Score(SpaceId);
             
    //        if (Maximum == GetAiSide())
    //            return Math.Max(MinimaxScore(Depth + 1, SpaceId, GetHumanSide(), Scores), MinimaxScore(Depth + 1, SpaceId, GetHumanSide(), Scores));

    //        else
    //            return Math.Min(MinimaxScore(Depth + 1, SpaceId, GetAiSide(), Scores), MinimaxScore(Depth + 1, SpaceId, GetAiSide(), Scores));
    //    }
    //    else
    //        return Score(SpaceId);
    //}
    //private void Minimax(int state, int depth, PlayerType PlayerSide)
    //{

    //    if (depth == 0)
    //}

    



}
