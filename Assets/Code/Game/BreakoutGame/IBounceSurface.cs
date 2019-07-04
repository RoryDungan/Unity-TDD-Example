using UnityEngine;

namespace Game.BreakoutGame
{
    /// <summary>
    /// A surface the ball can hit, defining how the ball should react to bouncing off it.
    /// </summary>
    public interface IBounceSurface
    {
        /// <summary>
        /// Calculate the new direction the ball should be moving in after hitting this 
        /// surface.
        /// </summary>
        /// <param name="hitPosition">
        /// The position the ball hit this surface, in world space.
        /// </param>
        /// <param name="hitDirection">
        /// Unit vector of the direction the ball was travelling when it hit the surface.
        /// </param>
        /// <param name="surfaceNormal">
        /// The surface normal at the collision point.
        /// </param>
        /// <returns>
        /// Unit vector of the new direction the ball should be moving in.
        /// </returns>
        Vector3 Bounce(Vector3 hitPosition, Vector3 hitDirection, Vector3 surfaceNormal);
    }
}
