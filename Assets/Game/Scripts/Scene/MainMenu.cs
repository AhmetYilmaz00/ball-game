using System;
using Game.Scripts.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts.Scene
{
    public class MainMenu : SceneController
    {
        #region Fields

        [SerializeField] private string menuSceneName;
        [SerializeField] private string gameSceneName;
        [SerializeField] private string nextLevelSceneName;
        [SerializeField] private string failSceneName;
        [SerializeField] private GameData gameData;

        private UnLoadScene _unLoadScene = new();
        private bool _isNextlevel;

        #endregion

        #region Unity Methods

        private void Start()
        {
            ControlActiveScene();
        }

        #endregion

        #region Methods

        public void StartGame()
        {
            _unLoadScene.currentSceneName = menuSceneName;
            _unLoadScene.otherSceneName = gameSceneName;
            MoveGameObjectToScene(_unLoadScene, GameManager.Instance.gameObject);
            MoveGameObjectToScene(_unLoadScene, gameObject);
            GameManager.Instance.isStartGame = true;
            UIManager.Instance.HpGameObjectActive();

            UnLoadSceneAsync(_unLoadScene);
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        public void NextLevel()
        {
            GameManager.Instance.isFinishGame = true;
            LoadScene(nextLevelSceneName);
        }

        public void RestartGame()
        {
            LoadScene(menuSceneName);
        }


        public void FailScene()
        {
            GameManager.Instance.isStartGame = false;
            LoadSceneAsync(failSceneName);
        }

        private void ControlActiveScene()
        {
            if (GetActiveScene() == menuSceneName)
            {
                LoadSceneAsync(gameSceneName);
            }
            else if (GetActiveScene() == nextLevelSceneName)
            {
                GameManager.Instance.isStartGame = true;
                gameData.LoadHpAndTime();
            }
        }

        #endregion
    }
}