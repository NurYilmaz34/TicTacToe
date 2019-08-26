using System.Collections.Generic;

namespace TicTacToe.Data
{
    public class NodeData
    {
        public NodeData ParentNode          { get; set; }
        public List<NodeData> ChildList     { get; set; }
        public PlayerType PlayerType        { get; set; }
        public string SpaceDataListString   { get; set; }
        public int MinimaxValue             { get; set; }
        public int Depth                    { get; set; }

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