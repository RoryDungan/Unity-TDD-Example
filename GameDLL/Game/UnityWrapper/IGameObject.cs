namespace Game.UnityWrapper
{
    interface IGameObject
    {
        bool CompareTag(string tag);

        T GetComponent<T>();

        void Destroy();
    }
}
