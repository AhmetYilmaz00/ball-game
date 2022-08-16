using Game.Data_SO;
using Game.Scripts.Managers;
using UnityEngine;

namespace Game.Scripts.CharacterScripts
{
    public class HealthController : MonoBehaviour
    {
        [SerializeField] private GameSettings gameSettings;
        [SerializeField] private UIManager uiManager;

        private float _hp;
        private float _maxHp;
        private float _amountPickUpHp;
        private float _subtractObstacleHp;
        private bool _isTriggerObstacle;
        private float _obstacleTriggerTimer;

        void Start()
        {
            Initialize();
        }

        // Update is called once per frame
        void Update()
        {
            if (_isTriggerObstacle)
            {
                _obstacleTriggerTimer += Time.deltaTime;
                DowngradeHpTimerControl();
            }
        }

        private void Initialize()
        {
            _hp = gameSettings.initialHp;
            _maxHp = gameSettings.maxHp;
            _amountPickUpHp = gameSettings.amountPickUpHp;
            _subtractObstacleHp = gameSettings.subtractObstacleHp;
            SetHealth();
        }

        public void SetHealth()
        {
            if (_hp > 100)
            {
                _hp = 100;
            }

            uiManager.SetHealthUI(_hp, _maxHp);
        }

        public void UpgradeHp()
        {
            _hp += _amountPickUpHp;
            SetHealth();
        }


        public void ObstacleTriggerEnter()
        {
            _isTriggerObstacle = true;
        }

        public void ObstacleTriggerExit()
        {
            _isTriggerObstacle = false;
            _obstacleTriggerTimer = 0;
        }


        private void DowngradeHpTimerControl()
        {
            if (_obstacleTriggerTimer >= 1)
            {
                _obstacleTriggerTimer = 0;
                DowngradeHp();
            }
        }

        public void DowngradeHp()
        {
            _hp -= _subtractObstacleHp;
            SetHealth();
        }
    }
}