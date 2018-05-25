using Game.UnityWrapper;
using UnityEngine;

namespace Game.Unity
{
    class Ball : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("How many units per second the ball should move.")]
        float movementSpeed;

        BreakoutGame.Ball ball;

        void Awake() => 
            ball = new BreakoutGame.Ball(transform.Wrap(), movementSpeed);

        void FixedUpdate() => 
            ball.FixedUpdate(Time.fixedDeltaTime);

        void OnCollisionEnter2D(Collision2D collision) => 
            ball.OnCollisionEnter2D(collision.Wrap());
    }
}
