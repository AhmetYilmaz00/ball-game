using Cinemachine;
using DG.Tweening;
using Game.Data_SO;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.Scripts.FlagScripts
{
    public class Flag : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Transform movableFlag;
        [SerializeField] private Transform ball;
        [SerializeField] private GameSettings gameSettings;
        [SerializeField] private CinemachineVirtualCamera virtualCamera;
        [SerializeField] private Transform movableWall;

        private MeshRenderer _movableFlagMeshRenderer;
        private Vector2 _distance;
        private Vector2 _flagMinMaxValue;
        private float _resultReMap;
        private bool _gameFinish;
        private Color _gameFinishFlagColor;
        private float _flagColorTransitionTime;
        private float _gameFinishCameraOrthoSize;
        private float _cameraOrthoSizeTransitionTime;

        #endregion

        #region Unity Methods

        private void Start()
        {
            Initialize();
        }

        private void Update()
        {
            FlagPosition();
        }

        #endregion

        #region Methods

        private void Initialize()
        {
            _distance.x = ball.position.z;
            _distance.y = (_distance.x + Vector3.Distance(ball.position, movableFlag.position)) *
                gameSettings.minRequiredPercentComplete / 100;
            _flagMinMaxValue = gameSettings.flagMinMaxValue;
            _movableFlagMeshRenderer = movableFlag.GetComponent<MeshRenderer>();
            _gameFinishFlagColor = new Color(0, 1, 0, 1);
            _flagColorTransitionTime = gameSettings.flagColorTransitionTime;
            _gameFinishCameraOrthoSize = gameSettings.gameFinishCameraOrthoSize;
            _cameraOrthoSizeTransitionTime = gameSettings.cameraOrthoSizeTransitionTime;
        }

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
                    GameFinish();

                    return _flagMinMaxValue.y;
                }
            }

            return _resultReMap;
        }

        private void FlagPosition()
        {
            var localPosition = movableFlag.localPosition;
            localPosition = new Vector3(localPosition.x, Remap(ball.position.z, _distance.x, _distance.y,
                _flagMinMaxValue.x,
                _flagMinMaxValue.y), localPosition.z);
            movableFlag.localPosition = localPosition;
        }

        public void GameFinish()
        {
            if (!_gameFinish)
            {
                _movableFlagMeshRenderer.material.DOColor(_gameFinishFlagColor, _flagColorTransitionTime);

                DOTween.To(() => virtualCamera.m_Lens.OrthographicSize, x => virtualCamera.m_Lens.OrthographicSize = x,
                    _gameFinishCameraOrthoSize, _cameraOrthoSizeTransitionTime);

                movableWall.DOLocalMoveZ(-5.4f, _cameraOrthoSizeTransitionTime);
            }

            _gameFinish = true;
        }

        #endregion
    }
}