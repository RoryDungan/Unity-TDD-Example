using Game.BreakoutGame;
using Game.UnityWrapper;
using UnityEngine;

namespace Game.Unity
{
    class Block : MonoBehaviour, IBlock
    {
        BreakoutGame.Block block;

        void Awake() => block = new BreakoutGame.Block(gameObject.Wrap());

        public void Smash() => block.Smash();
    }
}
