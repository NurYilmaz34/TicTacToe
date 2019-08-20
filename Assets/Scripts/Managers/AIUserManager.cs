using UnityEngine;
using TicTacToe.Data;
using System.Linq;

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

        public int GetAIPlayedSpace(SpaceData[] SpaceDataArray)
        {
            NodeData rootNode = new NodeData
            {
                Depth = CommonConstants.FirstNodeDataDepth,
                SpaceDataListString = GetArrayString(SpaceDataArray),
                ParentNode = null,
                Player = PlayerType.O
            };

            GenerateMinMaxTree(rootNode);
            Debug.Log(rootNode.SpaceDataListString);
            return CurrentSpaceId;
        }

        private string GetArrayString(SpaceData[] spaceDataArray)
        {
            string arrayString = string.Empty;
            for (int i = 0; i < spaceDataArray.Length; i++)
            {
                arrayString += string.IsNullOrEmpty(spaceDataArray[i].Value) ? "-" : spaceDataArray[i].Value;
            }
            return arrayString;
        }

        private SpaceData[] GetArray(string arrayString)
        {
            SpaceData[] spaceDataArray = new SpaceData[arrayString.Length];

            for (int i = 0; i < arrayString.Length; i++)
            {
                spaceDataArray[i] = new SpaceData(i, arrayString[i].ToString() == "-" ? "" : arrayString[i].ToString());
            }

            return spaceDataArray;
        }

        private int GetCurrentDepth(int spaceDataListCount)
        {
            return CommonConstants.StartTotalDepth - spaceDataListCount;
        }

        private void GenerateMinMaxTree(NodeData parentNode)
        {
            SpaceData[] RootCopyDataArray = GetArray(parentNode.SpaceDataListString);

            int remainingDepth = RootCopyDataArray.Where(lstData => string.IsNullOrEmpty(lstData.Value)).ToList().Count;
            int childCount = remainingDepth;
            for (int i = 0; i < childCount; i++)
            {
                if (string.IsNullOrEmpty(RootCopyDataArray[i].Value))
                {
                    RootCopyDataArray = GetArray(parentNode.SpaceDataListString);
                    RootCopyDataArray[i].Value = parentNode.Player.ToString();

                    NodeData childNode = new NodeData
                    {
                        Depth = GetCurrentDepth(remainingDepth),
                        SpaceDataListString = GetArrayString(RootCopyDataArray),
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
                    childCount++;
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
