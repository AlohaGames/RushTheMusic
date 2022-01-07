using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// Class for wizard's stats
    /// </summary>
    [CreateAssetMenu(fileName = "WizardStats", menuName = "Stats/Hero/Wizard", order = 1)]
    public class WizardStats : HeroStats
    {
        public int MaxMana;
    }
}