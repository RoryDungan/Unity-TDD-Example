using Game.UnityWrapper;
using UnityEngine;

namespace Game.BreakoutGame
{
    public class Ball
    {
        private readonly ITransform transform;
        private readonly IGameManager gameManager;

        /// <summary>
        /// Units to move per second.
        /// </summary>
        private readonly float velocity;

        /// <summary>
        /// The current movement direction.
        /// </summary>
        private Vector3 direction = Vector3.up;

        public Ball(ITransform transform, IGameManager gameManager, float velocity)
        {
            this.transform = transform;
            this.gameManager = gameManager;
            this.velocity = velocity;
        }

        public void FixedUpdate(float deltaTime)
        {
            transform.Position += direction * deltaTime * velocity;
        }

        public void OnCollisionEnter2D(ICollision2D other)
        {
            if (other.GameObject.CompareTag("death"))
            {
                gameManager.TriggerLoseCondition();
            }

            var bounceSurface = other.GameObject.GetComponent<IBounceSurface>();
            if (bounceSurface != null)
            {
                var contacts = new IContactPoint2D[1];
                other.GetContacts(contacts);

                direction = bounceSurface.Bounce(
                    transform.Position,
                    direction,
                    contacts[0].Normal
                );
            }

            // Break any blocks we come into contact with.
            other.GameObject.GetComponent<IBlock>()?.Smash();
        }
    }
}
