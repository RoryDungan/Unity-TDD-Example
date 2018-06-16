using Game.BreakoutGame;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace Game.Unity
{
    public class ScoreUI : MonoBehaviour
    {
        private Text scoreText;
        private IGameManager gameManager;

        void Awake()
        {
            scoreText = GetComponentInChildren<Text>();
            Assert.IsNotNull(
                scoreText, 
                "ScoreUI could not find Text component in children."
            );

            gameManager = GameManagerSingleton.Instance;
            gameManager.OnScoreChanged += GameManager_OnScoreChanged;
        }

        void OnDestroy()
        {
            gameManager.OnScoreChanged -= GameManager_OnScoreChanged;
        }

        private void GameManager_OnScoreChanged(object sender, ScoreChangedEventArgs e)
        {
            UpdateScore(e.NewScore);
        }

        void Start()
        {
            UpdateScore(gameManager.Score);
        }

        void UpdateScore(int newScore)
        {
            scoreText.text = newScore.ToString();
        }
    }
}
