using Game.UnityWrapper;
using UnityEngine;

namespace Game.BreakoutGame
{
    public class Ball
    {
        private readonly ITransform transform;

        private Vector3 direction = Vector3.up;

        public Ball(ITransform transform)
        {
            this.transform = transform;
        }

        public void FixedUpdate(float deltaTime)
        {
            transform.Position += direction;
        }

        public void OnCollisionEnter2D(ICollision2D other)
        {
            var contacts = new IContactPoint2D[1];
            other.GetContacts(contacts);

            direction = Vector3.Reflect(direction, contacts[0].Normal);
        }
    }
}
