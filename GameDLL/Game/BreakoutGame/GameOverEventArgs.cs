using System;

namespace Game.BreakoutGame
{
    /// <summary>
    /// Event raised when the game finishes.
    /// </summary>
    public class GameOverEventArgs : EventArgs
    {
        /// <summary>
        /// Did the player win or lose the game?
        /// </summary>
        public readonly bool Won;

        public GameOverEventArgs(bool won)
        {
            this.Won = won;
        }
    }
}