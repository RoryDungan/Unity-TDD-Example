using Game.BreakoutGame;
using Game.UnityWrapper;
using Moq;
using Xunit;

namespace GameTests
{
    public class BlockTests
    {
        private Block testObject;
        private Mock<IGameObject> mockGameObject;

        void Init()
        {
            mockGameObject = new Mock<IGameObject>();

            testObject = new Block(mockGameObject.Object);
        }

        [Fact]
        void smashing_block_destroys_object()
        {
            Init();

            testObject.Smash();

            mockGameObject.Verify(m => m.Destroy(), Times.Once());
        }
    }
}
