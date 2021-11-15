using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

//TODO: explain your FUNCKING TEST (like youyou in Tests/PlayMode/Enemy/ActionZoneTest)

namespace Aloha.Test
{
    /// <summary>
    /// TODO
    /// </summary>
    public class InventoryTest
    {
        /// <summary>
        /// TODO
        /// </summary>
        [Test]
        public void InventaireTest()
        {
            // Declaration of a hero
            HeroStats stats = ScriptableObject.CreateInstance<HeroStats>();
            stats.Attack = 100;
            stats.Defense = 0;
            stats.MaxHealth = 100;

            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            HeroInstantier.Instance.InstantiateHero(HeroType.Generic);
            Hero hero = GameManager.Instance.GetHero();
            hero.Init(stats);

            //premier test pour voir si tout est bien initialis�
            Assert.AreEqual(100, hero.GetStats().MaxHealth);
            hero.CurrentHealth = hero.GetStats().MaxHealth;
            Assert.AreEqual(100, hero.CurrentHealth);
            hero.TakeDamage(20);
            Assert.AreEqual(80, hero.CurrentHealth);

            // Create 6 health potion
            int gain = 20;
            HealPotion potion = new HealPotion(gain);
            HealPotion potion2 = new HealPotion(gain);
            HealPotion potion3 = new HealPotion(gain);
            HealPotion potion4 = new HealPotion(gain);
            HealPotion potion5 = new HealPotion(gain);
            HealPotion potion6 = new HealPotion(gain);

            // Creation de l'inventaire
            Inventory inventory = new Inventory();
            // add 5 potions in my inventory
            inventory.AddItem(potion);
            inventory.AddItem(potion2);
            inventory.AddItem(potion3);
            inventory.AddItem(potion4);
            inventory.AddItem(potion5);
            Assert.AreEqual(5, inventory.GetItems().Count);
            Queue<Item> itemsFull = inventory.GetItems();
            //add a sixth one and check if it was drop
            inventory.AddItem(potion6);
            Queue<Item> itemsFull2 = inventory.GetItems();
            //check if the queue if the same
            Assert.IsTrue(itemsFull == itemsFull2);
            Assert.AreEqual(5, inventory.GetItems().Count);

            // Use a potion
            inventory.UseItem();
            // there must be one item less and an hero with more lofe
            Assert.AreEqual(4, inventory.GetItems().Count);
            Assert.AreEqual(100, hero.CurrentHealth);
            inventory.UseItem();
            Assert.AreEqual(3, inventory.GetItems().Count);
            Assert.AreEqual(100, hero.CurrentHealth);

            GameObject.Destroy(manager);
            GameObject.Destroy(hero);
            inventory = null;
            stats = null;
            
            Aloha.Utils.ClearCurrentScene(true);
        }
    }
}
