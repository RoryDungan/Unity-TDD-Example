using UnityEngine;

namespace Game.UnityWrapper
{
    class UnityGameObject : IGameObject
    {
        private readonly GameObject gameObject;

        public UnityGameObject(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        public bool CompareTag(string tag) => gameObject.CompareTag(tag);

        public void Destroy() => Object.Destroy(gameObject);

        public T GetComponent<T>() => gameObject.GetComponent<T>();
    }
}
