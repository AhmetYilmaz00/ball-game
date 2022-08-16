using Game.Data_SO;
using Game.Scripts.Managers;
using Game.Scripts.Scene;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.Scripts.CharacterScripts
{
    public class Character : MonoBehaviour
    {
        #region Fields

        [SerializeField] private GameManager gameManager;

        [SerializeField] private UnityEvent onUpgradeHp;
        [SerializeField] private UnityEvent onObstacleTriggerEnter;
        [SerializeField] private UnityEvent onObstacleTriggerExit;
        [SerializeField] private UnityEvent onDowngradeHp;
        [SerializeField] private UnityEvent onSaveData;

        private bool _isTriggerObstacle;
        private string _obstacleNearTag;
        private bool _isNextlevel;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            Initialize();
        }


        private void OnTriggerEnter(Collider other)
        {
            BottleHealthTriggerEnter(other);
            ObstacleWallNearTriggerEnter(other);
        }

        private void OnTriggerStay(Collider other)
        {
            LevelFinishButtonTriggerStay(other);
        }

        private void OnTriggerExit(Collider other)
        {
            ObstacleWallNearTriggerExit(other);
        }

        private void OnCollisionEnter(Collision collision)
        {
            ObstacleWallCollisionEnter(collision);
        }

        #endregion

        #region Methods

        private void Initialize()
        {
            _obstacleNearTag = "ObstacleNear";
        }

        private void ObstacleWallNearTriggerEnter(Collider coll)
        {
            if (!coll.CompareTag(_obstacleNearTag))
            {
                return;
            }

            onObstacleTriggerEnter.Invoke();
        }


        private void ObstacleWallCollisionEnter(Collision coll)
        {
            if (!coll.gameObject.CompareTag("ObstacleWall"))
            {
                return;
            }

            onDowngradeHp.Invoke();
        }


        private void ObstacleWallNearTriggerExit(Collider coll)
        {
            if (!coll.CompareTag(_obstacleNearTag))
            {
                return;
            }

            onObstacleTriggerExit.Invoke();
        }

        private void BottleHealthTriggerEnter(Collider coll)
        {
            if (!coll.CompareTag("BottleHealth"))
            {
                return;
            }

            onUpgradeHp.Invoke();

            coll.gameObject.SetActive(false);
        }

        private void LevelFinishButtonTriggerStay(Collider coll)
        {
            if (!coll.CompareTag("LevelFinishButton"))
            {
                return;
            }

            if (!_isNextlevel && GameManager.Instance.levelFinishButtonActive)
            {
                _isNextlevel = true;
                var mainMenu = FindObjectOfType<MainMenu>();
                onSaveData.Invoke();
                mainMenu.NextLevel();
            }
        }

        #endregion
    }
}