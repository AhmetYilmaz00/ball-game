using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Managers
{
    public class UIManager : MonoSingleton<UIManager>
    {
        #region Fields

        [SerializeField] private TextMeshProUGUI hpTMP;
        [SerializeField] private Slider hpSliderBar;
        [SerializeField] private GameObject hpGameObject;

        #endregion

       

        #region Methods

        public void SetHealthUI(float _hp, float maxHp)
        {
            hpTMP.text = _hp.ToString();
            hpSliderBar.value = _hp / maxHp;
        }

        public void HpGameObjectActive()
        {
            hpGameObject.SetActive(true);
        }
        
       
        
        #endregion
    }
}