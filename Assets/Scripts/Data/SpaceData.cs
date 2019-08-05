using System;

namespace TicTacToe.Data
{
    public class SpaceData
    {
        public int Id       { get; set; }
        public string Value { get; set; }
       

        public SpaceData(int id, string value)
        {
            Id = id;
            Value = value;
        }
    }    
    
}
