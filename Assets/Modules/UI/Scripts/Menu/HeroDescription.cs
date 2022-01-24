using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Aloha.UI
{
    /// <summary>
    /// Class for the hero description UI
    /// </summary>
    public class HeroDescription : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI heroName;

        [SerializeField]
        private TextMeshProUGUI health;

        [SerializeField]
        private TextMeshProUGUI attack;

        [SerializeField]
        private TextMeshProUGUI defense;

        [SerializeField]
        private TextMeshProUGUI secondary;

        [SerializeField]
        private HeroStats[] heroStats;

        /// <summary>
        /// Show UI according to parameters
        /// <example> Example(s):
        /// <code>
        ///     heroDescription.Show();
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="opacity"></param>
        public void Show(HeroType heroType)
        {
            gameObject.SetActive(true);
            HeroStats heroStat = heroStats[(int)heroType];

            heroName.text = heroType.ToString();
            health.text = "HP : " + heroStat.MaxHealth.ToString();
            attack.text = "ATK : " + heroStat.Attack.ToString();
            defense.text = "DEF : " + heroStat.Defense.ToString();

            if (heroType.ToString() == "Warrior")
            {
                WarriorStats warriorStat = heroStats[(int)heroType] as WarriorStats;
                secondary.text = "RAGE : " + warriorStat.MaxRage.ToString();
            } else if (heroType.ToString() == "Wizard")
            {
                WizardStats wizardStat = heroStats[(int)heroType] as WizardStats;
                secondary.text = "MANA : " + wizardStat.MaxMana.ToString();
            }
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
