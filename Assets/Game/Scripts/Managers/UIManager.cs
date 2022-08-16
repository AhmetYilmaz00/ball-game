using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Managers
{
    public class UIManager : MonoBehaviour
    {
        #region Fields

        [SerializeField] private TextMeshProUGUI hpTMP;
        [SerializeField] private Slider hpSliderBar;

        #endregion

        #region Methods

        public void SetHealthUI(float _hp, float maxHp)
        {
            hpTMP.text = _hp.ToString();
            hpSliderBar.value = _hp / maxHp;
            //Todo: ui manager yap. dethealth ı oraya yaz.
        }

        #endregion
    }
}