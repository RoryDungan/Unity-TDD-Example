namespace Game.UnityWrapper
{
    public interface IGameObject
    {
        bool CompareTag(string tag);

        T GetComponent<T>();

        void Destroy();
    }
}
