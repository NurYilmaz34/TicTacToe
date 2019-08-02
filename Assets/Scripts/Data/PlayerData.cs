using System;

namespace TicTacToe.Data
{
    public class PlayerData
    {
        public int Order             { get; set; }
        public int Score             { get; set; }
        public PlayerType PlayerType { get; set; }
               
        public PlayerData(int order, PlayerType playerType)
        {
            Order = order;
            PlayerType = playerType;
        }
    }
}

