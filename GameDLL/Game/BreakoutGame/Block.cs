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

        public Block(IGameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        public void Smash()
        {
            // TODO: Add score
            gameObject.Destroy();
        }
    }
}
