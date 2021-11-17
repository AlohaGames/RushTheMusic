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
    }
}