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

        void Init(float velocity = 1f)
        {
            mockTransform = new Mock<ITransform>();
            testObject = new Ball(mockTransform.Object, velocity);
        }

        private static Mock<ICollision2D> SetupMockCollision(Vector3 surfaceNormal)
        {
            var mockContact = new Mock<IContactPoint2D>();
            mockContact
                .SetupGet(m => m.Normal)
                .Returns(surfaceNormal);

            var mockCollision = new Mock<ICollision2D>();
            mockCollision
                .Setup(m => m.GetContacts(It.IsAny<IContactPoint2D[]>()))
                .Callback<IContactPoint2D[]>(c => c[0] = mockContact.Object)
                .Returns(1);

            mockCollision
                .Setup(m => m.GameObject)
                .Returns(new Mock<IGameObject>().Object);
            return mockCollision;
        }

        [Fact]
        void initial_movement_direction_is_up()
        {
            Init();

            testObject.FixedUpdate(1f);

            mockTransform.VerifySet(m => m.Position = Vector3.up, Times.Once());
        }

        [Fact]
        void movement_is_relative_to_previous_position()
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
        void movement_is_scaled_relative_to_time()
        {
            Init();

            testObject.FixedUpdate(0.5f);

            mockTransform.VerifySet(
                m => m.Position = new Vector3(0f, 0.5f, 0f), 
                Times.Once()
            );
        }

        [Fact]
        void movement_is_multiplied_by_velocity()
        {
            Init(10f);

            testObject.FixedUpdate(1f);

            mockTransform.VerifySet(
                m => m.Position = new Vector3(0f, 10f, 0f), 
                Times.Once()
            );
        }

        [Fact]
        void smashes_block_on_contact()
        {
            Init();

            var mockBlock = new Mock<IBlock>();

            var mockBlockObject = new Mock<IGameObject>();
            mockBlockObject
                .Setup(m => m.GetComponent<IBlock>())
                .Returns(mockBlock.Object);

            var mockCollision = SetupMockCollision(Vector3.down);
            mockCollision
                .SetupGet(m => m.GameObject)
                .Returns(mockBlockObject.Object);

            testObject.OnCollisionEnter2D(mockCollision.Object);

            mockBlock.Verify(m => m.Smash(), Times.Once());
        }
    }
}
