using System;
using System.Collections;
using System.Collections.Generic;
using TicTacToe.Data;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<SpaceData> SpaceDataList   { get; set; }
    public List<PlayerData> PlayerDataList { get; set; }
    public PlayerType OrderPlayerType      { get; set; }
    private string playerSide;
    private string aiSide;
    private int counter = 0;

    void Start()
    {
        CreateList();
        CreatePlayerList();
        WhoStarting(PlayerType.X);
    }

    void Update()
    {

    }

    private void CreateList()
    {
        SpaceDataList = new List<SpaceData>();
        for (int i = 0; i < CommonConstants.SpaceDataListLength; i++)
        {
            SpaceDataList.Add(new SpaceData(i));
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
        OrderPlayerType = playerType;
    }
    
    private void OrderPlayers()
    {
        counter++;
        int tempVale = 0;
        if (counter % 2 == 1)
            tempVale = 1;
    }

    //private void Game()
    //{
    //    for (int i = 0; i < buttonTxt.Length; i++)
    //    {
    //        if (buttonTxt[0].text == playerSide && buttonTxt[1].text == playerSide && buttonTxt[2].text == playerSide)
    //        {

    //        }
    //        else if (buttonTxt[3].text == playerSide && buttonTxt[4].text == playerSide && buttonTxt[5].text == playerSide)
    //        {

    //        }
    //        else if (buttonTxt[6].text == playerSide && buttonTxt[7].text == playerSide && buttonTxt[8].text == playerSide)
    //        {

    //        }



    // }
    //}


}
