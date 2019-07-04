using UnityEngine;

namespace Game.UnityWrapper
{
    class UnityContactPoint2D : IContactPoint2D
    {
        private readonly ContactPoint2D contactPoint;

        public UnityContactPoint2D(ContactPoint2D contactPoint)
        {
            this.contactPoint = contactPoint;
        }

        public Vector2 Normal => contactPoint.normal;
    }
}
