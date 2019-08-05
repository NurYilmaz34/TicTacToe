using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TicTacToe.Data;

public class NodeData 
{
   // public SpaceData currentSpace;
    public NodeData ParentNode { get; set; }
    public List<NodeData> children;
    public int minimaxValue;
    public Player player;


    public NodeData()
    {
        //currentSpace = new SpaceData();
        children = new List<NodeData>();

    }
    
    public void AddNode(NodeData node)
    {
        children.Add(node);
    }

    public List<NodeData> getChildNodes()
    {
        return children;
    }
    
    ////List<NodeData> NodeDatas  { get; set; }
    //public NodeData[] NodeDatas { get; set; }
    ////public NodeData[] childrenNode;
    //public List<NodeData> childNode { get; set; }
    //public int Length           { get; set; }
    //public int Id               { get; set; }


    //public NodeData(int  length, int id)
    //{
    //    Id = id;
    //    NodeDatas = new NodeData[length];
    //}



}
