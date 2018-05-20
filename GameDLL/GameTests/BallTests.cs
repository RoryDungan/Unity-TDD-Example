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

            mockTransform
                .SetupGet(m => m.Position)
                .Returns(initialPosiiton);

            testObject.FixedUpdate(1f);

            mockTransform.VerifySet(m => m.Position = endPosition, Times.Once());
        }

        [Fact]
        public void direction_changes_when_ball_hits_object()
        {
            Init();

            var initialPosiiton = new Vector3(3f, 2f, 0f);
            var surfaceNormal = new Vector3(1f, -1f, 0f).normalized;
            var endPosition = new Vector3(4f, 2f, 0f);

            mockTransform
                .SetupGet(m => m.Position)
                .Returns(initialPosiiton);

            var mockContact = new Mock<IContactPoint2D>();
            mockContact
                .SetupGet(m => m.Normal)
                .Returns(surfaceNormal);

            var mockCollision = new Mock<ICollision2D>();
            mockCollision
                .Setup(m => m.GetContacts(It.IsAny<IContactPoint2D[]>()))
                .Callback<IContactPoint2D[]>(c => c[0] = mockContact.Object)
                .Returns(1);

            testObject.OnCollisionEnter2D(mockCollision.Object);

            testObject.FixedUpdate(1f);

            mockTransform.VerifySet(m => m.Position = endPosition, Times.Once());
        }
    }
}
