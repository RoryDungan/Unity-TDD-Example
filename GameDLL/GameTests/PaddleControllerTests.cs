using Game.BreakoutGame;
using Game.UnityWrapper;
using Moq;
using UnityEngine;
using Xunit;

namespace GameTests
{
    public class PaddleControllerTests
    {
        PaddleController testObject;

        Mock<IInputManager> mockInputManager;
        Mock<ITransform> mockTransform;

        void Init(float movementSpeed = 1f)
        {
            mockInputManager = new Mock<IInputManager>();
            mockTransform = new Mock<ITransform>();

            testObject = new PaddleController(
                mockInputManager.Object, 
                mockTransform.Object,
                movementSpeed
            );
        }

        [Fact]
        void does_not_move_when_no_key_pressed()
        {
            Init();

            testObject.Update(1f);

            mockTransform.VerifySet(
                m => m.Position = It.IsAny<Vector3>(), 
                Times.Never()
            );
        }

        private void VerifyPaddleMovesAtCorrectSpeed(
            float movementSpeed, 
            float deltaTime,
            KeyCode keyPressed, 
            Vector3 expectedPosition
        )
        {
            Init(movementSpeed);

            mockInputManager
                .Setup(m => m.GetKey(keyPressed))
                .Returns(true);

            testObject.Update(deltaTime);

            mockTransform.VerifySet(
                m => m.Position = expectedPosition,
                Times.Once()
            );
        }

        [Fact]
        void pressing_left_moves_paddle_at_correct_speed()
        {
            VerifyPaddleMovesAtCorrectSpeed(
                10f, 
                0.5f, 
                KeyCode.LeftArrow, 
                new Vector3(-5f, 0f, 0f)
            );
        }

        [Fact]
        void pressing_right_moves_paddle_at_correct_speed()
        {
            VerifyPaddleMovesAtCorrectSpeed(
                10f, 
                0.5f, 
                KeyCode.RightArrow, 
                new Vector3(5f, 0f, 0f)
            );
        }

        [Fact]
        void pressing_a_moves_paddle_at_correct_speed()
        {
            VerifyPaddleMovesAtCorrectSpeed(
                10f, 
                0.5f, 
                KeyCode.A, 
                new Vector3(-5f, 0f, 0f)
            );
        }

        [Fact]
        void pressing_d_moves_paddle_at_correct_speed()
        {
            VerifyPaddleMovesAtCorrectSpeed(
                10f, 
                0.5f, 
                KeyCode.D, 
                new Vector3(5f, 0f, 0f)
            );
        }

        [Fact]
        void pressing_opposite_directions_cancels_out()
        {
            Init(1f);

            mockInputManager
                .Setup(m => m.GetKey(KeyCode.LeftArrow))
                .Returns(true);
            mockInputManager
                .Setup(m => m.GetKey(KeyCode.RightArrow))
                .Returns(true);

            testObject.Update(1f);

            mockTransform.VerifySet(
                m => m.Position = It.IsAny<Vector3>(),
                Times.Never()
            );
        }
    }
}
