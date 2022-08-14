using System;
using System.Linq.Expressions;
using Game.Data_SO;
using Game.Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

namespace Game.Scripts.CharacterScripts
{
    public class Character : MonoBehaviour
    {
        #region Fields

        [SerializeField] private GameSettings gameSettings;
        [SerializeField] private TextMeshProUGUI hpTMP;
        [SerializeField] private Slider hpSliderBar;
        [SerializeField] private AudioSource bottleHealthSound;
        [SerializeField] private ParticleSystem addHealthParticle;
        [SerializeField] private OnCollisionBallFlagPlatform OnCollisionBallFlagPlatform;

        private float _hp;
        private float _timer;
        private bool _isTriggerObstacle;
        private string _obstacleNearTag;
        private float _amountPickUpHp;
        private float _subtractObstacleHp;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            _hp = gameSettings.initialHp;
            UpdateHp();
            _obstacleNearTag = "ObstacleNear";
            _amountPickUpHp = gameSettings.amountPickUpHp;
            _subtractObstacleHp = gameSettings.subtractObstacleHp;
        }

        void Update()
        {
            if (_isTriggerObstacle)
            {
                _timer += Time.deltaTime;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            BottleHealthTriggerEnter(other);
        }

        private void OnTriggerStay(Collider collider)
        {
            ObstacleWallNearTriggerStay(collider);
        }

        private void OnTriggerExit(Collider collider)
        {
            ObstacleWallNearTriggerExit(collider);
        }

        private void OnCollisionEnter(Collision collision)
        {
            ObstacleWallCollisionEnter(collision);
            FlagPlatformCollisionEnter(collision);
        }

        #endregion

        #region Methods

        private void ObstacleWallNearTriggerStay(Collider coll)
        {
            if (!coll.CompareTag(_obstacleNearTag))
            {
                return;
            }

            UpdateHp(false, true);
        }

        private void ObstacleWallCollisionEnter(Collision coll)
        {
            if (!coll.gameObject.CompareTag("ObstacleWall"))
            {
                return;
            }

            UpdateHp(false, false);
        }

        private void FlagPlatformCollisionEnter(Collision coll)
        {
            if (!coll.gameObject.CompareTag("FlagPlatform"))
            {
                return;
            }

            OnCollisionBallFlagPlatform.Invoke();
        }


        private void ObstacleWallNearTriggerExit(Collider coll)
        {
            if (!coll.CompareTag(_obstacleNearTag))
            {
                return;
            }

            _isTriggerObstacle = false;
            _timer = 0;
        }

        private void BottleHealthTriggerEnter(Collider coll)
        {
            if (!coll.CompareTag("BottleHealth"))
            {
                return;
            }

            UpdateHp(true, true);
            bottleHealthSound.Play();
            addHealthParticle.Play();
            coll.gameObject.SetActive(false);
        }

        private void UpdateHp()
        {
            if (_hp > 100)
            {
                _hp = 100;
            }

            hpTMP.text = _hp.ToString();
            hpSliderBar.value = _hp / gameSettings.maxHp;
        }

        private void UpdateHp(bool addHp, bool isTrigger)
        {
            if (addHp)
            {
                _hp += _amountPickUpHp;
                UpdateHp();
            }
            else
            {
                _isTriggerObstacle = true;
            }

            if (isTrigger && _timer >= 1)
            {
                _timer = 0;
                ReduceHp();
            }
            else if (!isTrigger)
            {
                ReduceHp();
            }
        }

        private void ReduceHp()
        {
            _hp -= _subtractObstacleHp;
            UpdateHp();
        }

        #endregion
    }
}