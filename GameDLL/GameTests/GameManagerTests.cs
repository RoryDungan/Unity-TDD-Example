using Game.BreakoutGame;
using Xunit;

namespace GameTests
{
    public class GameManagerTests
    {
        GameManager testObject;

        void Init()
        {
            testObject = new GameManager();
        }

        [Fact]
        void initial_score_is_0()
        {
            Init();

            Assert.Equal(0f, testObject.Score);
        }

        [Fact]
        void updating_score_stores_new_score()
        {
            Init();

            const int expectedScore = 10;

            testObject.Score = expectedScore;

            Assert.Equal(expectedScore, testObject.Score);
        }

        [Fact]
        void updating_score_sends_score_changed_event()
        {
            Init();

            var newScore = -1;
            const int expectedScore = 10;

            testObject.OnScoreChanged += (obj, evt) =>
            {
                newScore = evt.NewScore;
            };

            testObject.Score = expectedScore;

            Assert.Equal(expectedScore, newScore);
        }
    }
}
