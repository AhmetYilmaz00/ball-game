using UnityEngine;

namespace Game.Scripts.CharacterScripts
{
    public class Follower : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Transform character;

        #endregion

        #region Unity Methods

        private void FixedUpdate()
        {
            transform.position = character.position;
        }

        #endregion
    }
}