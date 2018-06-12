using Game.BreakoutGame;
using Game.UnityWrapper;
using Moq;
using UnityEngine;
using Xunit;

namespace GameTests
{
    public class PaddleBounceSurfaceTests
    {
        private PaddleBounceSurface testObject;
        private Mock<ITransform> mockTransform;

        void Init()
        {
            mockTransform = new Mock<ITransform>();
            testObject = new PaddleBounceSurface(mockTransform.Object);
        }

        [Fact]
        void hitting_middle_of_paddle_bounces_up()
        {
            Init();

            var inputDirection = new Vector3(0f, -1f, 0f);
            var hitPosition = Vector3.zero;
            var surfaceNormal = new Vector3(0f, 1f, 0f);

            var expectedDirection = new Vector3(0f, 1f, 0f);
            var actualDirection = 
                testObject.Bounce(hitPosition, inputDirection, surfaceNormal);

            Assert.Equal(expectedDirection, actualDirection);
        }

        [Fact]
        void hitting_side_of_paddle_bounces_to_that_side()
        {
            Init();

            var inputDirection = new Vector3(0f, -1f, 0f);
            var hitPosition = new Vector3(0.5f, 0f, 0f);
            var surfaceNormal = new Vector3(0f, 1f, 0f);

            var expectedDirection = (new Vector3(1f, 1f, 0f)).normalized;
            var actualDirection = 
                testObject.Bounce(hitPosition, inputDirection, surfaceNormal);

            Utils.AssertEqual(expectedDirection, actualDirection);
        }

        [Fact]
        void hit_position_is_relative_to_paddle_position()
        {
            Init();

            var paddlePosition = new Vector3(10f, 0f, 0f);

            mockTransform
                .SetupGet(m => m.Position)
                .Returns(paddlePosition);

            var inputDirection = new Vector3(0f, -1f, 0f);
            var hitPosition = new Vector3(0.5f, 0f, 0f) + paddlePosition;
            var surfaceNormal = new Vector3(0f, 1f, 0f);

            var expectedDirection = (new Vector3(1f, 1f, 0f)).normalized;
            var actualDirection = 
                testObject.Bounce(hitPosition, inputDirection, surfaceNormal);

            Utils.AssertEqual(expectedDirection, actualDirection);
        }

        [Fact]
        void maximum_angle_is_70_degrees()
        {
            Init();

            var inputDirection = new Vector3(0f, -1f, 0f);
            var hitPosition = new Vector3(1f, 0f, 0f);
            var surfaceNormal = new Vector3(0f, 1f, 0f);

            var angle = Mathf.Deg2Rad * 70f;
            var expectedDirection = new Vector3(
                Mathf.Sin(angle),
                Mathf.Cos(angle),
                0f
            );

            var actualDirection = 
                testObject.Bounce(hitPosition, inputDirection, surfaceNormal);

            Utils.AssertEqual(expectedDirection, actualDirection);
        }
    }
}
