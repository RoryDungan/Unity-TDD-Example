using Game.BreakoutGame;
using Game.UnityWrapper;
using UnityEngine;

namespace Game.Unity
{
    public class Ball : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("How many units per second the ball should move.")]
        float movementSpeed = 3f;

        BreakoutGame.Ball ball;

        void Awake()
        {
            ball = new BreakoutGame.Ball(
                transform.Wrap(),
                GameManagerSingleton.Instance,
                movementSpeed
            );
        }

        void FixedUpdate()
        {
            ball.FixedUpdate(Time.fixedDeltaTime);
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            ball.OnCollisionEnter2D(collision.Wrap());
        }
    }
}
