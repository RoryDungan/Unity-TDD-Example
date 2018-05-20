using Game.BreakoutGame;
using UnityEngine;

namespace Game.Unity
{
    /// <summary>
    /// Wrap our default bounce surface up in a scriptable object so that it can be 
    /// plugged-in elsewhere.
    /// </summary>
    class DefaultBounceSurface : MonoBehaviour, IBounceSurface
    {
        BreakoutGame.DefaultBounceSurface bounceSurface;

        void Awake() => bounceSurface = new BreakoutGame.DefaultBounceSurface();

        public Vector3 Bounce(Vector3 hitPosition, Vector3 hitDirection, Vector3 surfaceNormal)
        {
            return bounceSurface.Bounce(hitPosition, hitDirection, surfaceNormal);
        }
    }
}
