using Game.BreakoutGame;
using NUnit.Framework;

namespace GameTests
{
    public class GameManagerTests
    {
        GameManager testObject;

        void Init()
        {
            testObject = new GameManager();
        }

        [Test]
        public void initial_score_is_0()
        {
            Init();

            Assert.That(testObject.Score, Is.EqualTo(0f));
        }

        [Test]
        public void updating_score_stores_new_score()
        {
            Init();

            const int expectedScore = 10;

            testObject.Score = expectedScore;

            Assert.That(testObject.Score, Is.EqualTo(expectedScore));
        }

        [Test]
        public void updating_score_sends_score_changed_event()
        {
            Init();

            var newScore = -1;
            const int expectedScore = 10;

            testObject.OnScoreChanged += (obj, evt) =>
            {
                newScore = evt.NewScore;
            };

            testObject.Score = expectedScore;

            Assert.That(testObject.Score, Is.EqualTo(expectedScore));
        }

        [Test]
        public void triggering_lose_condition_raises_game_over_event()
        {
            // Arrange
            Init();

            var gameOverTriggered = false;

            testObject.OnGameOver += (obj, evt) =>
            {
                Assert.IsFalse(evt.Won);

                gameOverTriggered = true;
            };

            // Act
            testObject.TriggerLoseCondition();

            // Assert
            Assert.IsTrue(gameOverTriggered);
        }
    }
}
