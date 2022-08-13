using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts.Scene
{
    public class SceneSettings : MonoBehaviour
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

        protected void UnLoadSceneAsync(UnLoadScene unLoadScene, GameObject thisGameObject)
        {
            SceneManager.MoveGameObjectToScene(thisGameObject, SceneManager.GetSceneByName(unLoadScene.otherSceneName));
            SceneManager.UnloadSceneAsync(unLoadScene.currentSceneName);
        }

        #endregion
    }
}