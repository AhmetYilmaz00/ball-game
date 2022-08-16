using UnityEngine;

namespace Game.Data_SO
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "GameSettings")]
    public class GameSettings : ScriptableObject
    {
        [SerializeField] public float maxHp;
        [SerializeField] public float initialHp;
        [SerializeField] public float amountPickUpHp;
        [SerializeField] public float subtractObstacleHp;
        [SerializeField] public Vector2 flagMinMaxValue;
        [SerializeField] public float minRequiredPercentComplete;
        [SerializeField] public float flagColorTransitionTime;
        [SerializeField] public float gameFinishCameraOrthoSize;
        [SerializeField] public float cameraOrthoSizeTransitionTime;

// TODO: Gamemanager yap boolla oyun başladı mı bitti mi onları tut .
    }
}