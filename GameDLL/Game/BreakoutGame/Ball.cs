using Game.UnityWrapper;
using UnityEngine;

namespace Game.BreakoutGame
{
    public class Ball
    {
        private readonly ITransform transform;

        /// <summary>
        /// Units to move per second.
        /// </summary>
        private readonly float velocity;

        /// <summary>
        /// The current movement direction.
        /// </summary>
        private Vector3 direction = Vector3.up;

        public Ball(ITransform transform, float velocity)
        {
            this.transform = transform;
            this.velocity = velocity;
        }

        public void FixedUpdate(float deltaTime)
        {
            transform.Position += direction * deltaTime * velocity;
        }

        public void OnCollisionEnter2D(ICollision2D other)
        {
            var contacts = new IContactPoint2D[1];
            other.GetContacts(contacts);

            direction = Vector3.Reflect(direction, contacts[0].Normal);

            // Break any blocks we come into contact with.
            other.GameObject.GetComponent<IBlock>()?.Smash();
        }
    }
}
