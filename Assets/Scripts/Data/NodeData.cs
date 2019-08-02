using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NodeData 
{
    //List<NodeData> NodeDatas  { get; set; }
    public NodeData[] NodeDatas { get; set; }
    public int Length           { get; set; }
    public int Id               { get; set; }

    public NodeData(int  length, int id)
    {
        Id = id;
        NodeDatas = new NodeData[length];
    }

}
