using System;

namespace Game.BreakoutGame
{
    /// <summary>
    /// Keeps track of the score and other global state for the game.
    /// </summary>
    public interface IGameManager
    {
        int Score { get; set; }

        event EventHandler<ScoreChangedEventArgs> OnScoreChanged;
    }

    /// <inheritdoc />
    public class GameManager : IGameManager
    {
        private int score;

        public int Score
        {
            get => score;
            set
            {
                score = value;

                OnScoreChanged?.Invoke(this, new ScoreChangedEventArgs(Score));
            }
        }

        public event EventHandler<ScoreChangedEventArgs> OnScoreChanged;
    }
}
