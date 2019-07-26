using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Data;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<SpaceData> SpaceDataList   { get; set; }
    public List<PlayerData> PlayerDataList { get; set; }
    public PlayerType PlayerSide           { get; set; }
    private int counter = 0, go = 0;


    void Start()
    {
        CreateList();
        CreatePlayerList();
        WhoStarting(PlayerType.X);
    }

    void Update()
    {
        //OrderPlayers(PlayerType.X);
        //OrderPlayers();
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
        PlayerSide = playerType;
    }

    private PlayerType GetPlayerSide()
    {
        return PlayerSide;
    }

    private void OrderPlayers()
    {

        //counter++;
        //if (counter % 2 == 1)
        //    playerSide = PlayerType.O;
        //else
        //    playerSide = PlayerType.X;
        //    playerSide = PlayerType.X;
        if (PlayerSide == PlayerType.O)
            PlayerSide = PlayerType.X;
        else
            PlayerSide = PlayerType.O;
        //playerSide = (playerSide == PlayerType.X) ? PlayerType.O : PlayerType.X;
        //return playerSide;

    }

    // playerSide = (playerSide == "X") ? "O" : "X";


    public void Run()
    {
        go++;

        for (int i = 0; i < CommonConstants.SpaceDataListLength; i++)
        {
            SpaceData spaceData = SpaceDataList.First(lstSpaceData => lstSpaceData.Id == i);

            if (spaceText[0].text == PlayerSide && spaceText[1].text == PlayerSide && spaceText[2].text == PlayerSide)
            {

            }
            
        }
        OrderPlayers();
    }


}
