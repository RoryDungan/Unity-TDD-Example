using Game.UnityWrapper;
using UnityEngine;

namespace Game.BreakoutGame
{
    /// <summary>
    /// Process input and move the paddle.
    /// </summary>
    public class PaddleController
    {
        readonly IInputManager inputManager;
        readonly ITransform transform;

        /// <summary>
        /// The number of units to move per second.
        /// </summary>
        readonly float movementSpeed;

        public PaddleController(
            IInputManager inputManager, 
            ITransform transform, 
            float movementSpeed
        )
        {
            this.inputManager = inputManager;
            this.transform = transform;
            this.movementSpeed = movementSpeed;
        }

        public void Update(float deltaTime)
        {
            var newPosition = transform.Position;

            if (inputManager.GetKey(KeyCode.LeftArrow) || inputManager.GetKey(KeyCode.A))
            {
                newPosition += Vector3.left * deltaTime * movementSpeed;
            }
            if (inputManager.GetKey(KeyCode.RightArrow) || inputManager.GetKey(KeyCode.D))
            {
                newPosition += Vector3.right * deltaTime * movementSpeed;
            }

            if (transform.Position != newPosition)
            {
                transform.Position = newPosition;
            }
        }
    }
}
