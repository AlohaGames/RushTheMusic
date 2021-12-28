using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;
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


            // Clear the scene
            Utils.ClearCurrentScene(true);
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


            // Clear the scene
            Utils.ClearCurrentScene(true);
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


            // Clear the scene
            Utils.ClearCurrentScene(true);
        }

        /// <summary>
        /// Test the mana regenerate over time
        /// </summary>
        [UnityTest]
        public IEnumerator WizardRegenerationOverTimeTest()
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
            yield return null;

            // Check if mana regenerate
            Assert.Greater(wizard.CurrentMana, 0);
            int currentMana = wizard.CurrentMana;
            yield return new WaitForSeconds(0.1f);

            // Check if mana regenerate another time
            Assert.Greater(wizard.CurrentMana, currentMana);

            // Clear the scene
            Utils.ClearCurrentScene();
            yield return null;
        }

        /// <summary>
        /// Test the bump of the wizard
        /// </summary>
        [UnityTest]
        public IEnumerator WizardBumpTest()
        {
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));

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

            // Instance an enemy
            Enemy enemy = EnemyInstantier.Instance
                .InstantiateEnemy(EnemyType.generic)
                .GetComponent<Enemy>();

            // bump the enemy
            float positionZ = enemy.transform.position.z;
            wizard.BumpEntity(enemy);
            yield return null;

            // Check if the enemy has been bumped
            Assert.AreNotEqual(positionZ, enemy.transform.position.z);

            // Clear the scene
            Utils.ClearCurrentScene();
            yield return null;
        }

        /// <summary>
        /// Test fireball power with wizard mana
        /// </summary>
        [Test]
        public void WizardChargeFireballTest()
        {
            //Instantiate a wizard and his stats
            GameObject wizardGO = new GameObject();
            Wizard wizard = wizardGO.AddComponent<Wizard>();
            WizardStats wizardStats = (WizardStats)ScriptableObject.CreateInstance("WizardStats");
            wizardStats.MaxMana = 300;
            wizardStats.MaxHealth = 10;
            wizardStats.Attack = 10;
            wizardStats.Defense = 10;
            wizardStats.XP = 10;
            wizard.Init(wizardStats);

            // Check if max mana is correct
            Assert.AreEqual(300, wizard.CurrentMana);

            // Charge a complete fireball
            int power = wizard.ChargeFireball();
            Assert.AreEqual(wizard.GetStats().Attack, power);
            Assert.AreEqual(100, wizard.CurrentMana);

            // Charge half of a fireball
            power = wizard.ChargeFireball();
            Assert.AreEqual(wizard.GetStats().Attack / 2, power);
            Assert.AreEqual(0, wizard.CurrentMana);

            // Charge fireball with no power
            power = wizard.ChargeFireball();
            Assert.AreEqual(0, power);
            Assert.AreEqual(0, wizard.CurrentMana);

            // Clear the scene
            Utils.ClearCurrentScene(true);
        }

        /// <summary>
        /// Test fireball power with wizard mana
        /// </summary>
        [Test]
        public void WizardChargeVortexTest()
        {
            //Instantiate a wizard and his stats
            GameObject wizardGO = new GameObject();
            Wizard wizard = wizardGO.AddComponent<Wizard>();
            WizardStats wizardStats = (WizardStats)ScriptableObject.CreateInstance("WizardStats");
            wizardStats.MaxMana = 500;
            wizardStats.MaxHealth = 10;
            wizardStats.Attack = 10;
            wizardStats.Defense = 10;
            wizardStats.XP = 10;
            wizard.Init(wizardStats);

            // Check if max mana is correct
            Assert.AreEqual(500, wizard.CurrentMana);

            // Charge a vortex
            int manaUsed = wizard.ChargeVortex();
            Assert.AreEqual(400, manaUsed);
            Assert.AreEqual(100, wizard.CurrentMana);

            // Charge vortex with no power
            manaUsed = wizard.ChargeVortex();
            Assert.AreEqual(0, manaUsed);
            Assert.AreEqual(100, wizard.CurrentMana);

            // Clear the scene
            Utils.ClearCurrentScene(true);
        }
    }
}
