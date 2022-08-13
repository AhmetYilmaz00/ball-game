using UnityEngine;

namespace Game.Data_SO
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "GameSettings")]
    public class GameSettings : ScriptableObject
    {
        [SerializeField] private float MaxHP;
        [SerializeField] private float initialHP ;
    }
}