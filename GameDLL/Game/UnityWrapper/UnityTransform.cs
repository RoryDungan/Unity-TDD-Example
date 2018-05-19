using UnityEngine;

namespace Game.UnityWrapper
{
    class UnityTransform : ITransform
    {
        private readonly Transform transform;

        UnityTransform(Transform transform)
        {
            this.transform = transform;
        }

        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }
    }
}
