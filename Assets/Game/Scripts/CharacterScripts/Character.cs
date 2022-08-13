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

        [SerializeField] private bool _isTriggerObstacle;

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

        private void UpdateHp()
        {
            hpTMP.text = hp.ToString();
            hpSliderBar.value = hp / 100;
        }

        private void UpdateHp(bool addHp)
        {
            if (addHp)
            {
                hp += gameSettings.amountPickUpHp;
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