using System;

namespace TicTacToe.Data
{
    public enum MatchResultType : byte
    {
        Draw = 0,
        Win = 1,
        Lose = 2
    }

    public enum PanelType : byte
    {
        MenuPanel = 1,
        MatchResultPanel = 2
    }

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
        public const int FirstNodeDataDepth = 0;
        public const int RecordingTime = 10;
    }
    
}
