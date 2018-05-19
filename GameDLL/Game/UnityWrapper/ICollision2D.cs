namespace Game.UnityWrapper
{
    interface ICollision2D
    {
        int GetContacts(IContactPoint2D[] contacts);

        IGameObject GameObject { get; }
    }
}
