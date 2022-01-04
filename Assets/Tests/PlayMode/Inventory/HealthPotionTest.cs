using UnityEngine;
using NUnit.Framework;

namespace Aloha.Test
{
    public class HealthPotionTest
    {
        /// <summary>
        /// Test the effect of health potion
        /// </summary>
        [Test]
        public void NormalUseHealthPotion()
        {
            //Instance a wizard
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            HeroInstantier.Instance.InstantiateHero(HeroType.Wizard);
            Hero hero = GameManager.Instance.GetHero(); 
            Wizard wizard = hero as Wizard;

            //Create a health potion
            HealPotion healthPotion = new HealPotion(5);

            //Take out health
            wizard.CurrentHealth = 5;

            //Use a health potion
            healthPotion.Effect();

            //Check wizard's mana
            Assert.AreEqual(10, wizard.CurrentHealth);

            //Destroy the GameObjects
            Utils.ClearCurrentScene(true);
        }

        /// <summary>
        /// Test the effect of health potion when hero have the maximum of health
        /// </summary>
        [Test]
        public void UseHealPotionOverMaxHealStats()
        {
            //Instance a wizard
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            HeroInstantier.Instance.InstantiateHero(HeroType.Wizard);
            Hero hero = GameManager.Instance.GetHero(); 
            Wizard wizard = hero as Wizard;

            //Create a health potion
            HealPotion healPotion = new HealPotion(1000);

            //Use a health potion
            healPotion.Effect();

            //Check wizard's health
            Assert.AreEqual(wizard.GetStats().MaxHealth, wizard.CurrentHealth);

            //Destroy the GameObjects
            Utils.ClearCurrentScene(true);
        }

    }
}
