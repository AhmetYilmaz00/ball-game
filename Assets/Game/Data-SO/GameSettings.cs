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
    }
}