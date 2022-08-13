using System;
using Game.Data_SO;
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
        [SerializeField] private float hp;
        [SerializeField] private TextMeshProUGUI hpTMP;
        [SerializeField] private float timer;
        [SerializeField] private Slider hpSliderBar;
        [SerializeField] private AudioSource bottleHealthSound;
        private bool _isTriggerObstacle;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            hp = gameSettings.initialHp;
            UpdateHp();
        }

        void Update()
        {
            if (_isTriggerObstacle)
            {
                timer += Time.deltaTime;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            BottleHealthTriggerEnter(other);
        }

        private void OnTriggerStay(Collider collider)
        {
            ObstacleWallTriggerStay(collider);
        }

        private void OnTriggerExit(Collider collider)
        {
            ObstacleWallTriggerExit(collider);
        }

        #endregion

        #region Methods

        private void ObstacleWallTriggerStay(Collider coll)
        {
            if (!coll.CompareTag("Obstacle"))
            {
                return;
            }

            UpdateHp(false);
        }

        private void ObstacleWallTriggerExit(Collider coll)
        {
            if (!coll.CompareTag("Obstacle"))
            {
                return;
            }

            _isTriggerObstacle = false;
            Debug.Log("71.Satırrr");
            timer = 0;
        }

        private void BottleHealthTriggerEnter(Collider coll)
        {
            if (!coll.CompareTag("BottleHealth"))
            {
                return;
            }

            UpdateHp(true);
            bottleHealthSound.Play();
            coll.gameObject.SetActive(false);
        }

        private void UpdateHp()
        {
            if (hp > 100)
            {
                hp = 100;
            }

            hpTMP.text = hp.ToString();
            hpSliderBar.value = hp / gameSettings.maxHp;
        }

        private void UpdateHp(bool addHp)
        {
            if (addHp)
            {
                hp += gameSettings.amountPickUpHp;
                UpdateHp();
            }
            else
            {
                _isTriggerObstacle = true;
            }

            if (timer >= 1)
            {
                timer = 0;
                Debug.Log("95.Satırrr");
                hp -= gameSettings.subtractObstacleHp;
                UpdateHp();
            }
        }

        #endregion
    }
}