using UnityEngine;
using NUnit.Framework;

namespace Aloha.Test
{
    public class SecondaryPotionTest
    {
        /// <summary>
        /// Test the effect of mana potion
        /// </summary>
        [Test]
        public void NormalUseManaPotion()
        {
            //Instance a wizard
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            HeroInstantier.Instance.InstantiateHero(HeroType.Wizard);
            Hero hero = GameManager.Instance.GetHero(); 
            Wizard wizard = hero as Wizard;

            //Create a mana potion
            ManaPotion manaPotion = new ManaPotion();

            //Take out mana
            wizard.CurrentMana = 50;

            //Use a mana potion
            manaPotion.Effect();

            //Check wizard's mana
            Assert.AreEqual(250, wizard.CurrentMana);

            //Destroy the GameObjects
            GameObject.DestroyImmediate(hero.gameObject);
            GameObject.DestroyImmediate(manager);
        }

        /// <summary>
        /// Test the effect of mana potion when hero have the maximum of mana
        /// </summary>
        [Test]
        public void UseManaPotionOverMaxManaStats()
        {
            //Instance a wizard
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            HeroInstantier.Instance.InstantiateHero(HeroType.Wizard);
            Hero hero = GameManager.Instance.GetHero(); 
            Wizard wizard = hero as Wizard;

            //Create a mana potion
            ManaPotion manaPotion = new ManaPotion();

            //Use a mana potion
            manaPotion.Effect();

            //Check wizard's mana
            Assert.AreEqual(1000, wizard.CurrentMana);

            //Destroy the GameObjects
            GameObject.DestroyImmediate(hero.gameObject);
            GameObject.DestroyImmediate(manager);
        }

        /// <summary>
        /// Test the effect of rage potion
        /// </summary>
        [Test]
        public void NormalUseRagePotion()
        {
            //Instance a warrior
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            HeroInstantier.Instance.InstantiateHero(HeroType.Warrior);
            Hero hero = GameManager.Instance.GetHero(); 
            Warrior warrior = hero as Warrior;

            //Create a rage potion
            RagePotion ragePotion = new RagePotion();

            //Add rage
            warrior.CurrentRage = 50;

            //Use a rage potion
            ragePotion.Effect();

            //Check warrior's rage
            Assert.AreEqual(60, warrior.CurrentRage);

            //Destroy the GameObjects
            GameObject.DestroyImmediate(hero.gameObject);
            GameObject.DestroyImmediate(manager);
        }

        /// <summary>
        /// Test the effect of rage potion when hero have the maximum of rage
        /// </summary>
        [Test]
        public void UseManaPotionOverMaxRageStats()
        {
            //Instance a warrior
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            HeroInstantier.Instance.InstantiateHero(HeroType.Warrior);
            Hero hero = GameManager.Instance.GetHero(); 
            Warrior warrior = hero as Warrior;
            Debug.Log("Max rage: " + warrior.GetStats().MaxRage);

            //Create a rage potion
            RagePotion ragePotion = new RagePotion();

            //Add rage
            warrior.CurrentRage = warrior.GetStats().MaxRage;

            //Use a rage potion
            ragePotion.Effect();

            //Check warrior's rage
            Assert.AreEqual(100, warrior.CurrentRage);

            //Destroy the GameObjects
            GameObject.DestroyImmediate(hero.gameObject);
            GameObject.DestroyImmediate(manager);
        }
    }
}