using UnityEngine;
using System.Collections;
using TicTacToe.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Random = System.Random;

namespace TicTacToe.Managers
{
    public class AIUserManager
    {
        public static AIUserManager Instance { get; } = new AIUserManager();
        AIUserManager() { }
        static AIUserManager() { }

        public bool IsGameOver { get; set; }
        public int Depth { get; set; }
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
            NodeData rootNode = new NodeData
            {
                Depth = CommonConstants.FirstNodeDataDepth,
                NodeSpaceDataList = SpaceDataList,
                ParentNode = null,
                Player = PlayerType.O
            };

            GenerateMinMaxTree(rootNode);
            Debug.Log(rootNode.Player.ToString());
            //for (int i = 0; i < Depth; i++)
            //{
            //    //UpTree();
            //}

            //MinusDepth();
            //CurrentSpaceId = 

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

        private int GetCurrentDepth(int spaceDataListCount)
        {
            return CommonConstants.StartTotalDepth - spaceDataListCount;
        }

        private void GenerateMinMaxTree(NodeData parentNode)
        {
            List<SpaceData> RootCopyDataList = GameManager.CopySpaceData();
            int remainingDepth = RootCopyDataList.Where(lstData => string.IsNullOrEmpty(lstData.Value)).ToList().Count;

            for (int i = 0; i < remainingDepth; i++)
            {
                if (string.IsNullOrEmpty(RootCopyDataList[i].Value))
                {
                    RootCopyDataList[i].Value = parentNode.Player.ToString();

                    NodeData childNode = new NodeData
                    {
                        Depth = GetCurrentDepth(remainingDepth),
                        NodeSpaceDataList = RootCopyDataList,
                        ParentNode = parentNode,
                        Player = parentNode.Player == PlayerType.O ? PlayerType.X : PlayerType.O
                    };

                    parentNode.ChildList.Add(childNode);

                    if (remainingDepth == 0)
                        return;
                    else
                        GenerateMinMaxTree(childNode);
                }
                else
                    continue;
            }

            //if (parentNode.ChildList.Count == 0)
            //{
            //    //FullNodeData.First(lstData => lstData.MinimaxValue == Depth);
            //    parentNode.MinimaxValue = GameManager.Score(parentNode.Depth);

            //}
            //else
            //{
            //    if (parentNode.Player == PlayerType.X)
            //    {
            //        parentNode.MinimaxValue = GameManager.Score(parentNode.Depth);
            //        int maxvalue = parentNode.MinimaxValue;

            //        //foreach (nodedata child in root.child)
            //        //{
            //        //    if (child.minimaxvalue > maxvalue)
            //        //    {
            //        //        maxvalue = child.minimaxvalue;
            //        //    }
            //        //}
            //        //root.minimaxvalue = maxvalue;

            //        int maxValue = NodeData.GetChildNodes().Max(lstData => lstData.MinimaxValue);
            //        if (maxValue > parentNode.MinimaxValue)
            //            parentNode.MinimaxValue = maxValue;


            //        List<NodeData> Values = new List<NodeData>();
            //        Values.Add(parentNode.ParentNode);
            //        int ultimateValue = Random.Next(Values);
            //    }
            //    else
            //    {
            //        parentNode.MinimaxValue = GameManager.Score(parentNode.Depth);
            //        int minValue = parentNode.MinimaxValue;

            //        foreach (NodeData child in parentNode.ChildList)
            //        {
            //            if (child.MinimaxValue < minValue)
            //            {
            //                minValue = child.MinimaxValue;
            //            }
            //        }
            //        parentNode.MinimaxValue = minValue;

            //        //int minValue = NodeData.GetChildNodes().Where(lstData => lstData.Depth == NodeData.ParentNode.Depth + 1).Min(lstData => lstData.MinimaxValue);
            //    }
            }


        }
    }
