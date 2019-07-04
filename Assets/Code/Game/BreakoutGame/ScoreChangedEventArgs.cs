using System;

namespace Game.BreakoutGame
{
    /// <summary>
    /// Event raised when the score changes.
    /// </summary>
    public class ScoreChangedEventArgs : EventArgs
    {
        public readonly int NewScore;

        public ScoreChangedEventArgs(int newScore)
        {
            this.NewScore = newScore;
        }
    }
}