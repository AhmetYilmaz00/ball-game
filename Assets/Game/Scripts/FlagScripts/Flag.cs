using Game.Data_SO;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.Scripts.FlagScripts
{
    public class Flag : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Transform moveableFlag;
        [SerializeField] private Transform ball;
        [SerializeField] private GameSettings gameSettings;

        private Vector2 _distance;
        private Vector2 _flagMinMaxValue;
        private float _resultReMap;
        private bool _gameFinish;

        #endregion

        #region Unity Methods

        void Start()
        {
            _distance.x = ball.position.z;
            _distance.y = (_distance.x + Vector3.Distance(ball.position, moveableFlag.position)) *
                gameSettings.minRequiredPercentComplete / 100;
            _flagMinMaxValue = gameSettings.flagMinMaxValue;
        }

        void Update()
        {
            FlagPosition();
        }

        #endregion

        #region Methods

        private float Remap(float value, float from1, float to1, float from2, float to2)
        {
            if (!_gameFinish)
            {
                _resultReMap = (value - from1) / (to1 - from1) * (to2 - from2) + from2;
                if (_resultReMap < _flagMinMaxValue.x)
                {
                    return _flagMinMaxValue.x;
                }

                if (_resultReMap > _flagMinMaxValue.y)
                {
                    _gameFinish = true;

                    return _flagMinMaxValue.y;
                }
            }

            return _resultReMap;
        }

        private void FlagPosition()
        {
            var localPosition = moveableFlag.localPosition;
            localPosition = new Vector3(localPosition.x, Remap(ball.position.z, _distance.x, _distance.y,
                _flagMinMaxValue.x,
                _flagMinMaxValue.y), localPosition.z);
            moveableFlag.localPosition = localPosition;
        }

        public void GameFinish()
        {
            _gameFinish = true;
        }

        #endregion
    }
}