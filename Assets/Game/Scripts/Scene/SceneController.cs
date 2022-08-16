using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts.Scene
{
    public class SceneController : MonoBehaviour
    {
        #region Fields

        #endregion

        #region Unity Methods

        #endregion


        #region Methods

        public void LoadSceneAsync(string sceneName)
        {
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        }

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }

        protected void UnLoadSceneAsync(UnLoadScene unLoadScene)
        {
            SceneManager.UnloadSceneAsync(unLoadScene.currentSceneName);
        }

        protected void MoveGameObjectToScene(UnLoadScene unLoadScene, GameObject thisGameObject)
        {
            SceneManager.MoveGameObjectToScene(thisGameObject, SceneManager.GetSceneByName(unLoadScene.otherSceneName));
        }

        #endregion
    }
}