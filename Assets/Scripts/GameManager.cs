using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Data;
using TicTacToe.Managers;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SpaceData[] SpaceDataArray { get; set; }
    public List<PlayerData> PlayerDataList { get; set; }
    public PlayerType PlayerSide { get; set; }
    public PlayerType? WinnerPlayer { get; set; }
    public List<float> TimeList { get; set; }
    public float[] TimeArray { get; set; }
    public float Time;

    void Start()
    {
        
        CreateList();
        CreatePlayerList();
        SetPlayerSide(PlayerType.X);
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
        for (int j = 0; j < CommonConstants.PlayerDataListLength; j++)
        {
            PlayerType playerType = j == 0 ? PlayerType.X : PlayerType.O;
            PlayerDataList.Add(new PlayerData(j, playerType));
        }
    }

    public void SetPlayerSide(PlayerType playerType)
    {
        PlayerSide = playerType;
    }

    public void ChangePlayerSide()
    {
        PlayerSide = PlayerSide == PlayerType.X ? PlayerType.O : PlayerType.X;
    }

    public bool WinConditions(SpaceData[] spaceDataArray)
    {
        if (!string.IsNullOrEmpty(spaceDataArray[0].Value) && spaceDataArray[0].Value == spaceDataArray[1].Value && spaceDataArray[1].Value == spaceDataArray[2].Value)
        {
            //print("winn1" + spaceDataArray[0].Value);
            return true;
        }
        else if (!string.IsNullOrEmpty(spaceDataArray[3].Value) && spaceDataArray[3].Value == spaceDataArray[4].Value && spaceDataArray[4].Value == spaceDataArray[5].Value)
        {
            //print("winn2");
            return true;
        }
        else if (!string.IsNullOrEmpty(spaceDataArray[6].Value) && spaceDataArray[6].Value == spaceDataArray[7].Value && spaceDataArray[7].Value == spaceDataArray[8].Value)
        {
            //print("winn3");
            return true;
        }
        else if (!string.IsNullOrEmpty(spaceDataArray[0].Value) && spaceDataArray[0].Value == spaceDataArray[3].Value && spaceDataArray[6].Value == spaceDataArray[3].Value)
        {
            //print("winn4");
            return true;
        }
        else if (!string.IsNullOrEmpty(spaceDataArray[1].Value) && spaceDataArray[1].Value == spaceDataArray[4].Value && spaceDataArray[7].Value == spaceDataArray[4].Value)
        {
            //print("winn5");
            return true;
        }
        else if (!string.IsNullOrEmpty(spaceDataArray[2].Value) && spaceDataArray[2].Value == spaceDataArray[5].Value && spaceDataArray[8].Value == spaceDataArray[5].Value)
        {
            //print("winn6");
            return true;
        }
        else if (!string.IsNullOrEmpty(spaceDataArray[0].Value) && spaceDataArray[0].Value == spaceDataArray[4].Value && spaceDataArray[8].Value == spaceDataArray[4].Value)
        {
            //print("winn7");
            return true;
        }
        else if (!string.IsNullOrEmpty(spaceDataArray[2].Value) && spaceDataArray[2].Value == spaceDataArray[4].Value && spaceDataArray[6].Value == spaceDataArray[4].Value)
        {
            //print("winn8");
            return true;
        }
        else
        {
            //AIUserManager.Instance.IsGameOver = false;
            //OrderPlayers();
            return false;
        }

    }

    public int GetSpaceID(SpaceData[] spaceDataArray)
    {
        return AIUserManager.Instance.GetAIPlayedSpace(spaceDataArray);
    }

    public void GetGameTime(int k)
    {
        // PlayerPrefs.SetFloat("time", TimeList.Count);
        //for (int i = TimeList.Count; i > TimeList.Count - k; i--)
        //{
        //    PlayerPrefs.SetFloat("time", i);
        //    //PlayerPrefs.SetFloat("time" + i, TimeList(i));
        //}
        //return 
        for (int i = 0; i < TimeArray.Length; i++)
        {
            float item = TimeArray[i];
            PlayerPrefs.SetFloat("item",TimeArray[i]);
        }
    }

    public bool IsGameOver()
    {
        if (WinConditions(SpaceDataArray))
        {
            WinnerPlayer = PlayerSide;
            //PlayerPrefs.SetFloat("time", UnityEngine.Time.time);
            //TimeList.Add(UnityEngine.Time.time);
            return true;
        }
        else
        {
            if (IsAllSpaceDataFull(SpaceDataArray))
            {
                WinnerPlayer = null;
                //TimeList.Add(UnityEngine.Time.time);
                return true;
            }
            else
                return false;
        }
    }

    public bool IsAllSpaceDataFull(SpaceData[] spaceDataAray)
    {
        for (int i = 0; i < CommonConstants.SpaceDataListLength; i++)
        {
            if (string.IsNullOrEmpty(spaceDataAray[i].Value))
                return false;
        }

        return true;
    }

    public int GetScore(SpaceData[] spaceDataAray, PlayerType playerType, int Depth)
    {
        if (WinConditions(spaceDataAray))
        {
            if (playerType == PlayerType.X)
                return  - 10;

            else
                return  + 10;
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
