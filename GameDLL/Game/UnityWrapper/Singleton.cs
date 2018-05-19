namespace Game.UnityWrapper
{
    /// <summary>
    /// Base class for singletons.
    /// </summary>
    class Singleton<T> where T : class, new()
    {
        private static T instance;

        /// <summary>
        /// Singleton instance.
        /// </summary>
        public T Instance => instance ?? (instance = new T());
    }
}
