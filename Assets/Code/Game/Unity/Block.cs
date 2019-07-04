using Game.BreakoutGame;
using Game.UnityWrapper;
using UnityEngine;

namespace Game.Unity
{
    public class Block : MonoBehaviour, IBlock
    {
        [SerializeField]
        int score = 1;

        BreakoutGame.Block block;

        void Awake()
        {
            block = new BreakoutGame.Block(
                gameObject.Wrap(),
                GameManagerSingleton.Instance,
                score
            );
        }

        public void Smash() => block.Smash();
    }
}
