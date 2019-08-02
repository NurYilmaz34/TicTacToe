using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Data;
using TicTacToe.Managers;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<SpaceData> SpaceDataList   { get; set; }
    public List<PlayerData> PlayerDataList { get; set; }
    public List<ScoreData> ScoreDataList   { get; set; }
    public PlayerType PlayerSide           { get; set; }
    public PlayerType AISide               { get; set; }
    public PlayerType HumanSide            { get; set; }
    public SpaceData SpaceData             { get; set; }
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
    //private void CreateScoreList()
    //{
    //    ScoreDataList = new List<ScoreData>();
    //    for (int j = 0; j < CommonConstants.ScoreDataListLength; j++)
    //    {
            
    //    }
    //}

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
        else if (SpaceDataList[3].Value == GetPlayerSide().ToString() && SpaceDataList[4].Value == GetPlayerSide().ToString() && SpaceDataList[5].Value == GetPlayerSide().ToString())
        {
            print("winn2");
            GameOver();
            return false;
        }
        else if (SpaceDataList[6].Value == GetPlayerSide().ToString() && SpaceDataList[7].Value == GetPlayerSide().ToString() && SpaceDataList[8].Value == GetPlayerSide().ToString())
        {
            print("winn3");
            GameOver();
            return false;
        }
        else if (SpaceDataList[0].Value == GetPlayerSide().ToString() && SpaceDataList[3].Value == GetPlayerSide().ToString() && SpaceDataList[6].Value == GetPlayerSide().ToString())
        {
            print("winn4");
            GameOver();
            return false;
        }
        else if (SpaceDataList[1].Value == GetPlayerSide().ToString() && SpaceDataList[4].Value == GetPlayerSide().ToString() && SpaceDataList[7].Value == GetPlayerSide().ToString())
        {
            print("winn5");
            GameOver();
            return false;
        }
        else if (SpaceDataList[2].Value == GetPlayerSide().ToString() && SpaceDataList[5].Value == GetPlayerSide().ToString() && SpaceDataList[8].Value == GetPlayerSide().ToString())
        {
            print("winn6");
            GameOver();
            return false;
        }
        else if (SpaceDataList[0].Value == GetPlayerSide().ToString() && SpaceDataList[4].Value == GetPlayerSide().ToString() && SpaceDataList[8].Value == GetPlayerSide().ToString())
        {
            print("winn7");
            GameOver();
            return false;
        }
        else if (SpaceDataList[2].Value == GetPlayerSide().ToString() && SpaceDataList[4].Value == GetPlayerSide().ToString() && SpaceDataList[6].Value == GetPlayerSide().ToString())
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
            if (string.IsNullOrEmpty(SpaceDataList.ToString()))
                return false;
            else
                return true;
        
        //for (int i = 0; i < CommonConstants.SpaceDataListLength; i++)
        //{
        //    if (SpaceDataList[i].Value != null)
        //        return true;
        //    else
        //        return false;
        //}

    }

    private int Score(int Depth)
    {
        if (PlayerSide == PlayerType.O)
            return Depth+1;

        else
            return Depth-1;
    }

    //public PlayerType Maximum()
    //{
    //    if (PlayerSide == PlayerType.O)
    //        return GetAiSide();
    //    else
    //        return GetHumanSide();
    //}

    private int MinimaxScore(int Depth, int SpaceId, PlayerType Maximum, int[] Scores)
    {
         if (!IsGameOver())
        {
            if (Depth == CommonConstants.StartTotalDepth)
                return Score(SpaceId);
             
            if (Maximum == GetAiSide())
                return Math.Max(MinimaxScore(Depth + 1, SpaceId, GetHumanSide(), Scores), MinimaxScore(Depth + 1, SpaceId, GetHumanSide(), Scores));

            else
                return Math.Min(MinimaxScore(Depth + 1, SpaceId, GetAiSide(), Scores), MinimaxScore(Depth + 1, SpaceId, GetAiSide(), Scores));
        }
        else
            return Score(SpaceId);
    }
    //private void Minimax(int state, int depth, PlayerType PlayerSide)
    //{

    //    if (depth == 0)
    //}

    



}
