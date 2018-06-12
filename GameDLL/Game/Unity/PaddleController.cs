using Game.UnityWrapper;
using UnityEngine;

namespace Game.Unity
{
    class PaddleController : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The number of units per second to move.")]
        float movementSpeed = 3f;

        BreakoutGame.PaddleController paddleController;

        void Awake()
        {
            paddleController = new BreakoutGame.PaddleController(
                UnityInputManager.Instance,
                transform.Wrap(),
                movementSpeed
            );
        }

        void Update() => paddleController.Update(Time.deltaTime);
    }
}
