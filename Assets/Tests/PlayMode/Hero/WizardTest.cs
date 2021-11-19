using UnityEngine;
using NUnit.Framework;

namespace Aloha.Test
{
    public class WizardTest
    {
        /// <summary>
        /// Test the mana potion regeneration
        /// </summary>
        [Test]
        public void WizardRegenerationManaPotionTest()
        {
            //Instantiate a wizard and his stats
            GameObject wizardGO = new GameObject();
            Wizard wizard = wizardGO.AddComponent<Wizard>();
            WizardStats wizardStats = (WizardStats)ScriptableObject.CreateInstance("WizardStats");
            wizardStats.MaxMana = 100;
            wizardStats.MaxHealth = 10;
            wizardStats.Attack = 10;
            wizardStats.Defense = 10;
            wizardStats.XP = 10;
            wizard.Init(wizardStats);

            //Check if max mana is correct
            Assert.AreEqual(100, wizard.CurrentMana);

            //Take out mana
            wizard.CurrentMana = 0;

            //Regenerate 10% of mana max
            wizard.RegenerateSecondary(0.1f);
            Assert.AreEqual(10, wizard.CurrentMana);

            //Regenerate 55% of mana max
            wizard.RegenerateSecondary(0.55f);
            Assert.AreEqual(65, wizard.CurrentMana);

            //Take out mana
            wizard.CurrentMana = 0;

            //Regenerate 100% of mana max
            wizard.RegenerateSecondary(1f);
            Assert.AreEqual(100, wizard.CurrentMana);

            //Destroy all GameObjects
            GameObject.Destroy(wizardGO);
        }

        /// <summary>
        /// Test the mana potion regeneration effect over max mana
        /// </summary>
        [Test]
        public void WizardRegenerationManaPotionOverMaxManaTest()
        {
            //Instantiate a wizard and his stats
            GameObject wizardGO = new GameObject();
            Wizard wizard = wizardGO.AddComponent<Wizard>();
            WizardStats wizardStats = (WizardStats)ScriptableObject.CreateInstance("WizardStats");
            wizardStats.MaxMana = 100;
            wizardStats.MaxHealth = 10;
            wizardStats.Attack = 10;
            wizardStats.Defense = 10;
            wizardStats.XP = 10;
            wizard.Init(wizardStats);

            //Check if max mana is correct
            Assert.AreEqual(100, wizard.CurrentMana);

            //Regenerate 10% of mana max
            wizard.RegenerateSecondary(0.1f);
            Assert.AreEqual(100, wizard.CurrentMana);

            //Regenerate 100% of mana max
            wizard.RegenerateSecondary(1f);
            Assert.AreEqual(100, wizard.CurrentMana);

            //Destroy all GameObjects
            GameObject.Destroy(wizardGO);
        }

        /// <summary>
        /// Test the mana potion regeneration effect with negative regen
        /// </summary>
        [Test]
        public void WizardNegativeRegenerationManaPotionTest()
        {
            //Instantiate a wizard and his stats
            GameObject wizardGO = new GameObject();
            Wizard wizard = wizardGO.AddComponent<Wizard>();
            WizardStats wizardStats = (WizardStats)ScriptableObject.CreateInstance("WizardStats");
            wizardStats.MaxMana = 100;
            wizardStats.MaxHealth = 10;
            wizardStats.Attack = 10;
            wizardStats.Defense = 10;
            wizardStats.XP = 10;
            wizard.Init(wizardStats);

            //Check if max mana is correct
            Assert.AreEqual(100, wizard.CurrentMana);

            //Regenerate -10% of mana max
            wizard.RegenerateSecondary(-0.1f);
            Assert.AreEqual(100, wizard.CurrentMana);

            //Regenerate -100% of mana max
            wizard.RegenerateSecondary(-1f);
            Assert.AreEqual(100, wizard.CurrentMana);

            //Destroy all GameObjects
            GameObject.Destroy(wizardGO);
        }
    }
}
