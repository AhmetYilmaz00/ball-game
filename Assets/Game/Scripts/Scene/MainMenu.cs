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

        private UnLoadScene _unLoadScene = new();
        private bool _isNextlevel;

        #endregion

        #region Unity Methods

        private void Start()
        {
            LoadSceneAsync(gameSceneName);
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
            UnLoadSceneAsync(_unLoadScene);
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        public void NextLevel()
        {
            LoadScene(nextLevelSceneName);
        }

        #endregion
    }
}