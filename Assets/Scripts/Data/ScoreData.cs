using System;

namespace TicTacToe.Data
{
    public class ScoreData
    {
        public int Id { get; set; }
        public int Score { get; set; }

        public ScoreData(int id, int score)
        {
            Id = id;
            Score = score;
        }
    }
}

