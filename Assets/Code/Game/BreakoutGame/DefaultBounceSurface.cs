using UnityEngine;

namespace Game.BreakoutGame
{
    public class DefaultBounceSurface : IBounceSurface
    {
        public Vector3 Bounce(Vector3 hitPosition, Vector3 hitDirection, Vector3 surfaceNormal)
        {
            return Vector3.Reflect(hitDirection, surfaceNormal);
        }
    }
}
