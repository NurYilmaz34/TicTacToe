using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TicTacToe.Data;

public class NodeData 
{
    public NodeData ParentNode { get; set; }
    public List<NodeData> Children;
    public List<SpaceData> NodeSpaceDataList;
    public int MinimaxValue;
    public int Depth;
    public PlayerType Player;

    public NodeData()
    {
        Children = new List<NodeData>();
    }
    
    public void AddNode(NodeData node)
    {
        Children.Add(node);
    }

    public List<NodeData> getChildNodes()
    {
        return Children;
    }
    
}
