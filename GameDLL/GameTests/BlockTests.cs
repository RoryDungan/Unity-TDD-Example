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
        private Mock<IGameManager> mockGameManager;

        void Init(int score = 1)
        {
            mockGameObject = new Mock<IGameObject>();
            mockGameManager = new Mock<IGameManager>();

            testObject = new Block(mockGameObject.Object, mockGameManager.Object, score);
        }

        [Fact]
        void smashing_block_destroys_object()
        {
            Init();

            testObject.Smash();

            mockGameObject.Verify(m => m.Destroy(), Times.Once());
        }

        [Fact]
        void smashing_block_adds_score_to_GameManager()
        {
            const int expectedScore = 10;

            Init(expectedScore);

            testObject.Smash();

            mockGameManager.VerifySet(m => m.Score += expectedScore, Times.Once());
        }
    }
}
