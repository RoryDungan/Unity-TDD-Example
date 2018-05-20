namespace Game.BreakoutGame
{
    public interface IBlock
    {
        /// <summary>
        /// Smash the block.
        /// </summary>
        void Smash();
    }

    class Block : IBlock
    {
        public void Smash()
        {
            throw new System.NotImplementedException();
        }
    }
}
