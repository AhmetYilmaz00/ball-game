using UnityEngine;

namespace Game.Scripts.Scene
{
    public class MainMenu : SceneSettings
    {
        #region Fields

        [SerializeField] private string currentSceneName;
        [SerializeField] private string otherSceneName;

        private UnLoadScene _unLoadScene = new();

        #endregion

        #region Unity Methods

        void Start()
        {
            LoadSceneAsync(otherSceneName);
        }

        #endregion

        #region Methods

        public void StartGame()
        {
            _unLoadScene.currentSceneName = currentSceneName;
            _unLoadScene.otherSceneName = otherSceneName;
            UnLoadSceneAsync(_unLoadScene, gameObject);
        }

        public void ExitGame()
        {
        }

        #endregion
    }
}