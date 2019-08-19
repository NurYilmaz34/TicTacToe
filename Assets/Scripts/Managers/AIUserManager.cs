using UnityEngine;
using System.Collections;
using TicTacToe.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.Managers
{
    public class AIUserManager
    {
        public static AIUserManager Instance { get; } = new AIUserManager();
        AIUserManager() { }
        static AIUserManager() { }

        public bool IsGameOver             { get; set; }
        public int Depth                   { get; set; }
        public List<NodeData> FullNodeData { get; set; }
        private int CurrentSpaceId;
        public NodeData NodeData;
        public GameManager GameManager;
        
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
            //GenerateMinMaxTree(SpaceDataList);
            //GenerateMinMaxTree(new NodeData(), Player, Depth);
            GenerateMinMaxTree(new NodeData(), GameManager.PlayerSide, CurrentDepth(NodeData.NodeSpaceDataList));
            for (int i = 0; i < Depth; i++)
            {
                //UpTree();
            }

            //MinusDepth();

            return CurrentSpaceId;
        }

        //private void MinusDepth()
        //{
        //    TotalDepth -= 2;
        //}

        //private void UpTree()
        //{
        //    throw new NotImplementedException();
        //}

        //private void GenerateMinMaxTree(List<SpaceData> SpaceDataList)
        //{
        //    GenerateMinMaxTree(new NodeData(), PlayerType.X, CommonConstants.StartTotalDepth);
        //    throw new NotImplementedException();

        //}

        private int CurrentDepth(List<SpaceData> SpaceDataList)
        {
            int NummberofEmptyData = CommonConstants.StartTotalDepth - SpaceDataList.Count;
            return NummberofEmptyData;
        }

        private void GenerateMinMaxTree(NodeData root, PlayerType player, int currentDepth)
        {
           
            List<SpaceData> RootCopyDataList = GameManager.CopySpaceData();
            currentDepth = CurrentDepth(RootCopyDataList);

            for (int i = 0; i < currentDepth; i++)
            {
                if (string.IsNullOrEmpty(RootCopyDataList[i].Value))
                {
                    RootCopyDataList[i].Value = player.ToString();
                    NodeData newNode = new NodeData();
                    newNode.NodeSpaceDataList = RootCopyDataList;
                    newNode.ParentNode = root;
                    root.Children.Add(newNode);
                    root.Depth++;

                    if (currentDepth == 0)
                        IsGameOver = true;
                    else
                    {
                        if (player == PlayerType.O)
                        {
                            newNode.Player = PlayerType.X;
                            GenerateMinMaxTree(newNode, PlayerType.X, currentDepth - 1);

                        }
                        else if (player == PlayerType.X)
                        {
                            newNode.Player = PlayerType.O;
                            GenerateMinMaxTree(newNode, PlayerType.O, currentDepth - 1);
                        }
                        else
                            return;
                        //List<SpaceData> CurrentFullSpaceData = new List<SpaceData>();
                        //List<SpaceData> RootCopyDataList = CurrentFullSpaceData.ConvertAll(lstSpaceData => new SpaceData(lstSpaceData.Id, lstSpaceData.Value));
                        RootCopyDataList.Add(new SpaceData(i, player.ToString()));
                        FullNodeData.Add(newNode);
                    }
                }
                else
                    currentDepth++;
            }

            if (root.Children.Count == 0)
            {
                root.MinimaxValue = GameManager.Score(Depth);
            }
            else
            {
                if(root.Player == PlayerType.X)
                {
                    int maxValue = root.MinimaxValue;
                    root.MinimaxValue = GameManager.Score(Depth);

                    foreach (NodeData child in root.Children)
                    {
                        if (child.MinimaxValue > maxValue)
                        {
                            maxValue = child.MinimaxValue;
                        }
                    }
                    root.MinimaxValue = maxValue;
                }
                else
                {
                    int minValue = root.MinimaxValue;
                    root.MinimaxValue = GameManager.Score(Depth);

                    foreach (NodeData child in root.Children)
                    {
                        if (child.MinimaxValue < minValue)
                        {
                            minValue = child.MinimaxValue;
                        }
                    }
                    root.MinimaxValue = minValue;
                }
            }

        }
    }

}