using UnityEngine;

namespace Game.UnityWrapper
{
    class UnityCollision2D : ICollision2D
    {
        private readonly Collision2D collision;

        public UnityCollision2D(Collision2D collision)
        {
            this.collision = collision;
            GameObject = new UnityGameObject(collision.gameObject);
        }

        public IGameObject GameObject { get; }

        public int GetContacts(IContactPoint2D[] contacts)
        {
            ContactPoint2D[] unityContacts = new ContactPoint2D[contacts.Length];
            var numContacts = collision.GetContacts(unityContacts);

            for (var i = 0; i < numContacts; i++)
            {
                contacts[i] = new UnityContactPoint2D(unityContacts[i]);
            }

            return numContacts;
        }
    }
}
