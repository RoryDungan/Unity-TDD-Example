using UnityEngine;

namespace Game.UnityWrapper
{
    /// <summary>
    /// Extension methods for easily converting from Unity objects to our wrapped 
    /// versions.
    /// </summary>
    static class Wrappers
    {
        public static ITransform Wrap(this Transform unityObject) => 
            new UnityTransform(unityObject);

        public static IGameObject Wrap(this GameObject unityObject) => 
            new UnityGameObject(unityObject);

        public static ICollision2D Wrap(this Collision2D unityObject) => 
            new UnityCollision2D(unityObject);
    }
}
