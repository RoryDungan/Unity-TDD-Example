using Game.UnityWrapper;
using UnityEngine;

namespace Game.BreakoutGame
{
    public class Ball
    {
        private readonly ITransform transform;

        public Ball(ITransform transform)
        {
            this.transform = transform;
        }

        public void FixedUpdate(float deltaTime)
        {
            transform.Position += Vector3.up;
        }
    }
}
