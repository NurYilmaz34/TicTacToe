using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TicTacToe.Data;

public class NodeData 
{
    public NodeData ParentNode { get; set; }
    public List<NodeData> ChildList;
    public List<SpaceData> NodeSpaceDataList;
    public int MinimaxValue;
    public int Depth;
    public PlayerType Player;

    public NodeData()
    {
        ChildList = new List<NodeData>();
    }
    
    public List<NodeData> GetChildNodes()
    {
        return ChildList;
    }
    
}
