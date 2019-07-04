using UnityEngine;

namespace Game.UnityWrapper
{
    public class UnityInputManager : Singleton<UnityInputManager>, IInputManager
    {
        public bool GetKey(KeyCode key) => Input.GetKey(key);
    }
}
