using Game.UnityWrapper;
using UnityEngine;

namespace Game.BreakoutGame
{
    /// <summary>
    /// Simulates ball bounces on the paddle. So that the player has control of the ball's
    /// trajectory, the direction the ball heads in after bouncing on the paddle should be
    /// based on where it hit the paddle, not its incoming direction and the surface 
    /// normal like for other objects.
    /// </summary>
    public class PaddleBounceSurface : IBounceSurface
    {
        private ITransform transform;

        public PaddleBounceSurface(ITransform transform)
        {
            this.transform = transform;
        }

        public Vector3 Bounce(Vector3 hitPosition, Vector3 hitDirection, Vector3 surfaceNormal)
        {
            // Direction depends on where the paddle touched the ball, with the edge
            // sending it directly to the left/right, and the middle sending it directly 
            // up.
            var distanceFromCentre = hitPosition.x - transform.Position.x;

            // Ensure that the ball can't get stuck sideways or bounce below the paddle.
            var angle = Mathf.Clamp(
                distanceFromCentre * Mathf.PI / 2f,
                Mathf.Deg2Rad * -70f,
                Mathf.Deg2Rad * 70f
            );

            return new Vector3(
                Mathf.Sin(angle),
                Mathf.Cos(angle),
                0f
            );
        }
    }
}
