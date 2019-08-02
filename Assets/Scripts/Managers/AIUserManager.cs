using UnityEngine;
using System.Collections;
using TicTacToe.Data;
using System;
using System.Collections.Generic;

namespace TicTacToe.Managers
{
    public class AIUserManager
    {
        public static AIUserManager Instance { get; } = new AIUserManager();
        AIUserManager() { }
        static AIUserManager() { }

        public bool IsGameOver  { get; set; }
        public int Depth        { get; set; }
        public int TotalDepth   { get; set; }

        private int CurrentSpaceId;
        
        //private int MinimaxScore(int Depth, int SpaceId, PlayerType Maximum, int[] Scores)
        //{
        //    if (!IsGameOver)
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

        public int GetAIPlayedSpace(List<SpaceData> SpaceDataList)
        {
            GenerateMinMaxTree(SpaceDataList);

            for (int i = 0; i < Depth; i++)
            {
                UpTree();
            }

            MinusDepth();

            return CurrentSpaceId;
        }

        private void MinusDepth()
        {
            TotalDepth -= 2;
        }

        private void UpTree()
        {
            throw new NotImplementedException();
        }

        private void GenerateMinMaxTree(List<SpaceData> SpaceDataList)
        {
            throw new NotImplementedException();
        }
    }

}