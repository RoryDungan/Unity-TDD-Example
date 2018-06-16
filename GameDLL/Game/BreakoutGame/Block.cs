using Game.UnityWrapper;

namespace Game.BreakoutGame
{
    public interface IBlock
    {
        /// <summary>
        /// Smash the block.
        /// </summary>
        void Smash();
    }

    public class Block : IBlock
    {
        private readonly IGameObject gameObject;
        private readonly IGameManager gameManager;
        private readonly int scoreValue;

        public Block(IGameObject gameObject, IGameManager gameManager, int scoreValue)
        {
            this.gameObject = gameObject;
            this.gameManager = gameManager;
            this.scoreValue = scoreValue;
        }

        public void Smash()
        {
            gameManager.Score += scoreValue;
            gameObject.Destroy();
        }
    }
}
