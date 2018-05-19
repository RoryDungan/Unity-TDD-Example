using Game.BreakoutGame;
using Game.UnityWrapper;
using Moq;
using UnityEngine;
using Xunit;

namespace BreakoutTests
{
    public class BallTests
    {
        private Ball testObject;
        private Mock<ITransform> mockTransform;

        void Init()
        {
            mockTransform = new Mock<ITransform>();
            testObject = new Ball(mockTransform.Object);
        }

        [Fact]
        public void initial_movement_direction_is_up()
        {
            Init();

            testObject.FixedUpdate(1f);

            mockTransform.VerifySet(m => m.Position = Vector3.up, Times.Once());
        }

        [Fact]
        public void movement_is_relative_to_previous_position()
        {
            Init();

            var initialPosiiton = new Vector3(3f, 2f, 0f);
            var endPosition = new Vector3(3f, 3f, 0f);

            mockTransform.SetupGet(m => m.Position)
                .Returns(initialPosiiton);

            testObject.FixedUpdate(1f);

            mockTransform.VerifySet(m => m.Position = endPosition, Times.Once());
        }
    }
}
