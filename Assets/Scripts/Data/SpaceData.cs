using System;

namespace TicTacToe.Data
{
    public class SpaceData
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public SpaceData(int id)
        {
            Id = id;
        }
    }    
    
}
