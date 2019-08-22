using UnityEngine;
using TicTacToe.Data;
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
        //private int CurrentSpaceId;
        public NodeData NodeData;
        public GameManager GameManager;
        

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
            return 0;//CurrentSpaceId(array1, array2);
        }

        private int CurrentSpaceId(string[] array1, string[] array2)
        {
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

            if (parentNode.ParentNode == null)
            {
                SetMinimaxValue(parentNode);
            }       
            
        }

        private void SetMinimaxValue(NodeData parentNode)
        {
            for (int i = 0; i < parentNode.ChildList.Count + 1; i++)
            {
                if (parentNode.ChildList.Count == 0)
                {
                    parentNode.MinimaxValue = GameManager.Score(GetArray(parentNode.SpaceDataListString), parentNode.Depth);
                }
                else if(i == parentNode.ChildList.Count)
                {
                    //parentNode.MinimaxValue = parentNode.ChildList[i].MinimaxValue;
                    if (parentNode.Player == PlayerType.X)
                        parentNode.MinimaxValue = parentNode.ChildList.Max(lstData => lstData.MinimaxValue);
                    else
                        parentNode.MinimaxValue = parentNode.ChildList.Min(lstData => lstData.MinimaxValue);
                }
                else
                {
                    if (parentNode.ChildList[i].MinimaxValue != 0)
                    {
                        if (parentNode.Player == PlayerType.X)
                        {
                            //parentNode.MinimaxValue = GameManager.Score(parentNode.Depth);
                            NodeData[] maxValueChilds = new NodeData[parentNode.ChildList.Count];
                            int maxValue = parentNode.GetChildNodes().Max(lstData => lstData.MinimaxValue);

                            foreach (NodeData child in parentNode.ChildList)
                            {
                                if (parentNode.MinimaxValue < maxValue)
                                {
                                    parentNode.MinimaxValue = maxValue;

                                    if (child.MinimaxValue == maxValue)
                                    {
                                        for (int k = 0; k < parentNode.ChildList.Count; k++)
                                        {
                                            maxValueChilds[k] = child;
                                        }
                                    }
                                }

                            }
                            Random randomMinimaxValue = new Random();
                            int currentMaxValueIndex = randomMinimaxValue.Next(0, maxValueChilds.Length);
                            NodeData currentMaxValueChild = maxValueChilds[currentMaxValueIndex];
                            parentNode.MinimaxValue = parentNode.ChildList[currentMaxValueIndex].MinimaxValue;
                        }
                        else
                        {
                            //parentNode.MinimaxValue = GameManager.Score(parentNode.Depth);
                            NodeData[] minValueChilds = new NodeData[parentNode.ChildList.Count];    // en küçük aynı değere sahip olan childların dizisi
                            int minValue = parentNode.GetChildNodes().Min(lstData => lstData.MinimaxValue);

                            foreach (NodeData child in parentNode.ChildList)
                            {
                                if (parentNode.MinimaxValue > minValue)
                                {
                                    parentNode.MinimaxValue = minValue;

                                    if (child.MinimaxValue == minValue)
                                    {
                                        for (int k = 0; k < parentNode.ChildList.Count; k++)
                                        {
                                            minValueChilds[k] = child;
                                        }
                                    }
                                }

                            }
                            Random randomMinimaxValue = new Random();
                            int currentMinValueIndex = randomMinimaxValue.Next(0, minValueChilds.Length);
                            NodeData currentMinValueChild = minValueChilds[currentMinValueIndex];
                            parentNode.MinimaxValue = parentNode.ChildList[currentMinValueIndex].MinimaxValue;
                        }

                        
                    }
                    else
                    {
                        SetMinimaxValue(parentNode.ChildList[0]);

                    }
                }
            }
            
            
        }
    }


}
    
