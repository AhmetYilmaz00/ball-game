using Game.Data_SO;
using Game.Scripts.CharacterScripts;
using Game.Scripts.Managers;
using TMPro;
using UnityEngine;

namespace Game.Scripts
{
    public class GameData : MonoBehaviour
    {
        [SerializeField] private HealthController healthController;
        [SerializeField] private GameSettings gameSettings;
        [SerializeField] private TextMeshProUGUI timeTMP;

        public void SaveHpAndTime()
        {
            ES3.Save("GameTime", GameManager.Instance.gameTime);
            ES3.Save("Hp", healthController.hp);
        }

        public void LoadHpAndTime()
        {
            timeTMP.text = "Your Playing Time in Seconds: " + ES3.Load("GameTime");
            UIManager.Instance.SetHealthUI((float)ES3.Load("Hp"), gameSettings.maxHp);
        }
    }
}