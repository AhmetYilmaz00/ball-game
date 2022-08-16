using Game.Data_SO;
using Game.Scripts.Managers;
using Game.Scripts.Scene;
using UnityEngine;

namespace Game.Scripts.CharacterScripts
{
    public class HealthController : MonoBehaviour
    {
        [SerializeField] private GameSettings gameSettings;

        public float hp;
        private float _maxHp;
        private float _amountPickUpHp;
        private float _subtractObstacleHp;
        private bool _isTriggerObstacle;
        private float _obstacleTriggerTimer;
        private bool _isFailGame;

        void Start()
        {
            Initialize();
        }

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
            hp = gameSettings.initialHp;
            _maxHp = gameSettings.maxHp;
            _amountPickUpHp = gameSettings.amountPickUpHp;
            _subtractObstacleHp = gameSettings.subtractObstacleHp;
            SetHealth();
        }

        public void SetHealth()
        {
            if (hp > 100)
            {
                hp = 100;
            }
            else if (hp <= 0)
            {
                hp = 0;
                if (!_isFailGame)
                {
                    _isFailGame = true;
                    var mainMenu = FindObjectOfType<MainMenu>();
                    mainMenu.FailScene();
                }
            }

            UIManager.Instance.SetHealthUI(hp, _maxHp);
        }

        public void UpgradeHp()
        {
            hp += _amountPickUpHp;
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
            hp -= _subtractObstacleHp;
            SetHealth();
        }
    }
}