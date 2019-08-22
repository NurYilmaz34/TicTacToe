using System;
using System.Collections.Generic;

namespace TicTacToe.Data
{
    public class NodeData
    {
        public NodeData ParentNode          { get; set; }
        public List<NodeData> ChildList     { get; set; }
        public string SpaceDataListString   { get; set; }
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
}