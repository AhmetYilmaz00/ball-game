using System;
using Game.Scripts.Managers;
using UnityEngine;
using UnityEngine.Windows.Speech;

namespace Game.Scripts.CharacterMove
{
    public class Move : MonoBehaviour
    {
        #region Fields

        [SerializeField] private float movementForce;
        private Rigidbody _rigidbody;

        #endregion

        #region Unity Methods

        private void Awake() => _rigidbody = GetComponent<Rigidbody>();

        private void FixedUpdate()
        {
            if (GameManager.Instance.isStartGame)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    _rigidbody.AddForce(movementForce * Vector3.forward);
                }

                if (Input.GetKey(KeyCode.S))
                {
                    _rigidbody.AddForce(movementForce * Vector3.back);
                }

                if (Input.GetKey(KeyCode.D))
                {
                    _rigidbody.AddForce(movementForce * Vector3.right);
                }

                if (Input.GetKey(KeyCode.A))
                {
                    _rigidbody.AddForce(movementForce * Vector3.left);
                }
            }
        }

        #endregion
    }
}