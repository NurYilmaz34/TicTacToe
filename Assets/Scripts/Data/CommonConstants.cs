using System;

namespace TicTacToe.Data
{
    public enum PlayerType : byte
    {
        X = 1,
        O = 2
    }
    

    public class CommonConstants
    {
        public const int SpaceDataListLength = 9;
        public const int PlayerDataListLength = 2;
        public const int StartTotalDepth = 9;
    }
    
}
