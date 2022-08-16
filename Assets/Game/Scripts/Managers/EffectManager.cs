using UnityEngine;

namespace Game.Scripts.Managers
{
    public class EffectManager : MonoSingleton<EffectManager>
    {
        [SerializeField] private AudioSource bottleHealthSound;
        [SerializeField] private ParticleSystem addHealthParticle;

        public void UpgradeHpEffects()
        {
            bottleHealthSound.Play();
            addHealthParticle.Play();
        }
    }
}