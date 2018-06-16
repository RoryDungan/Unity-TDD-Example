using Game.BreakoutGame;
using Game.UnityWrapper;
using UnityEngine;

namespace Game.Unity
{
    class PaddleBounceSurface : MonoBehaviour, IBounceSurface
    {
        BreakoutGame.PaddleBounceSurface bounceSurface;

        void Awake()
        {
            bounceSurface = new BreakoutGame.PaddleBounceSurface(transform.Wrap());
        }

        public Vector3 Bounce(Vector3 hitPosition, Vector3 hitDirection, Vector3 surfaceNormal)
        {
            return bounceSurface.Bounce(hitPosition, hitDirection, surfaceNormal);
        }
    }
}
