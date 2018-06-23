
using Game.BreakoutGame;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace Game.Unity
{
    public class GameOverUI : MonoBehaviour
    {
        private IGameManager gameManager;

        void Awake()
        {
            gameManager = GameManagerSingleton.Instance;
            gameManager.OnGameOver += GameManager_OnGameOver;

            gameObject.SetActive(false);
        }

        void OnDestroy()
        {
            gameManager.OnGameOver -= GameManager_OnGameOver;
        }

        private void GameManager_OnGameOver(object sender, GameOverEventArgs e)
        {
            gameObject.SetActive(true);
        }
    }
}
