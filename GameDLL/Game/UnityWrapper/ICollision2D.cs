namespace Game.UnityWrapper
{
    public interface ICollision2D
    {
        int GetContacts(IContactPoint2D[] contacts);

        IGameObject GameObject { get; }
    }
}
