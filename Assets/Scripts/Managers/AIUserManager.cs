using UnityEngine;
using TicTacToe.Data;
using System.Linq;
using Random = System.Random;
using System;

namespace TicTacToe.Managers
{
    public class AIUserManager
    {
        public static AIUserManager Instance { get; } = new AIUserManager();
        AIUserManager() { }
        static AIUserManager() { }

        public bool IsGameOver { get; set; }
        //private int CurrentSpaceId;
        public NodeData NodeData;
        public GameManager GameManager;

        public int GetAIPlayedSpace(SpaceData[] SpaceDataArray)
        {
            NodeData rootNode = new NodeData        //nesne oluşturduk.
            {
                Depth = CommonConstants.FirstNodeDataDepth,
                SpaceDataListString = GetArrayString(SpaceDataArray),
                ParentNode = null,
                PlayerType = PlayerType.X
            };

            GenerateMinMaxTree(rootNode);
            int spaceId = CurrentSpaceId(rootNode.SpaceDataListString, GetNextStepDataListString(rootNode));
            return spaceId;    
        }

        private string GetNextStepDataListString(NodeData rootNode)
        {
            NodeData[] childNodeDataArray = rootNode.ChildList.Where(lstChild => lstChild.MinimaxValue == rootNode.MinimaxValue).ToArray();

            Random randomObject = new Random();
            int index = randomObject.Next(0, childNodeDataArray.Length);
            NodeData nodeData = childNodeDataArray[index];
            return nodeData.SpaceDataListString;
        }

        private int CurrentSpaceId(string currentArray, string pcArray)
        {
            for (int i = 0; i < CommonConstants.SpaceDataListLength; i++)
            {
                if (!(currentArray[i] == pcArray[i]))
                    return i;
            }
            return 0;
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

            int remainingDepth = RootCopyDataArray.Where(lstData => string.IsNullOrEmpty(lstData.Value)).ToList().Count;   //value su boş olan kadar daha derine gidebilirim
            int childCount = remainingDepth;
            for (int i = 0; i < childCount; i++)
            {
                if (string.IsNullOrEmpty(RootCopyDataArray[i].Value))
                {
                    RootCopyDataArray = GetArray(parentNode.SpaceDataListString);
                    RootCopyDataArray[i].Value = parentNode.PlayerType == PlayerType.O ? PlayerType.X.ToString() : PlayerType.O.ToString();

                    NodeData childNode = new NodeData
                    {
                        Depth = GetCurrentDepth(remainingDepth),
                        SpaceDataListString = GetArrayString(RootCopyDataArray),
                        ParentNode = parentNode,
                        PlayerType = parentNode.PlayerType == PlayerType.O ? PlayerType.X : PlayerType.O
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

            if (parentNode.ParentNode == null)
            {
                SetMinimaxValue(parentNode);
            }       
            
        }

        private void SetMinimaxValue(NodeData parentNode)
        {
            if (!GameManager.WinConditions(GetArray(parentNode.SpaceDataListString)))
            {
                for (int i = 0; i < parentNode.ChildList.Count + 1; i++)
                {
                    if (i == parentNode.ChildList.Count || !GameManager.WinConditions(GetArray(parentNode.ChildList[i].SpaceDataListString)))
                    {
                        if (parentNode.ChildList.Count == 0)
                        {
                            parentNode.MinimaxValue = GameManager.GetScore(GetArray(parentNode.SpaceDataListString), parentNode.PlayerType, parentNode.Depth);
                        }
                        else if (i == parentNode.ChildList.Count)
                        {
                            if (parentNode.PlayerType == PlayerType.X)
                                parentNode.MinimaxValue = parentNode.ChildList.Max(lstData => lstData.MinimaxValue);
                            else
                                parentNode.MinimaxValue = parentNode.ChildList.Min(lstData => lstData.MinimaxValue);
                        }
                        else
                        {
                            if (parentNode.ChildList[i].MinimaxValue == 0)
                                SetMinimaxValue(parentNode.ChildList[i]);
                            else
                            {

                                //if (parentNode.PlayerType == PlayerType.X)
                                //{
                                //    //parentNode.MinimaxValue = GameManager.Score(parentNode.Depth);
                                //    NodeData[] maxValueChilds = new NodeData[parentNode.ChildList.Count];
                                //    int maxValue = parentNode.GetChildNodes().Max(lstData => lstData.MinimaxValue);

                                //    foreach (NodeData child in parentNode.ChildList)
                                //    {
                                //        if (parentNode.MinimaxValue < maxValue)
                                //            parentNode.MinimaxValue = maxValue;

                                //        if (child.MinimaxValue == maxValue)
                                //        {
                                //            for (int k = 0; k < parentNode.ChildList.Count; k++)
                                //            {
                                //                maxValueChilds[k] = child;
                                //            }
                                //        }
                                //    }
                                //    Random randomMinimaxValue = new Random();
                                //    int currentMaxValueIndex = randomMinimaxValue.Next(0, maxValueChilds.Length);
                                //    parentNode.MinimaxValue = parentNode.ChildList[currentMaxValueIndex].MinimaxValue;
                                //}
                                //else
                                //{
                                //    //parentNode.MinimaxValue = GameManager.Score(parentNode.Depth);
                                //    NodeData[] minValueChilds = new NodeData[parentNode.ChildList.Count];    // en küçük aynı değere sahip olan childların dizisi
                                //    int minValue = parentNode.GetChildNodes().Min(lstData => lstData.MinimaxValue);

                                //    foreach (NodeData child in parentNode.ChildList)
                                //    {
                                //        if (parentNode.MinimaxValue > minValue)
                                //            parentNode.MinimaxValue = minValue;

                                //        if (child.MinimaxValue == minValue)
                                //        {
                                //            for (int k = 0; k < parentNode.ChildList.Count; k++)
                                //            {
                                //                minValueChilds[k] = child;
                                //            }
                                //        }

                                //    }
                                //    Random randomMinimaxValue = new Random();
                                //    int currentMinValueIndex = randomMinimaxValue.Next(0, minValueChilds.Length);
                                //    parentNode.MinimaxValue = parentNode.ChildList[currentMinValueIndex].MinimaxValue;
                                //}
                            }
                        }
                    }
                    else
                    {
                        parentNode.ChildList[i].MinimaxValue = GameManager.GetScore(GetArray(parentNode.ChildList[i].SpaceDataListString), parentNode.ChildList[i].PlayerType, parentNode.ChildList[i].Depth);
                    }
                }
            }
            else
            {
                parentNode.MinimaxValue = GameManager.GetScore(GetArray(parentNode.SpaceDataListString), parentNode.PlayerType, parentNode.Depth);
            }
        }
    }
}
    
