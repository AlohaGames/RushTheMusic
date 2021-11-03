using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Aloha.Test
{
    public class InventoryTest
    {
        [UnityTest]
        public IEnumerator InventaireTestIterator()
        {

            // Declaration of an hero

            HeroStats stats = ScriptableObject.CreateInstance<HeroStats>();

            stats.attack = 100;
            stats.defense = 0;
            stats.maxHealth = 100;

            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            HeroInstantier.Instance.InstantiateHero(HeroType.Generic);
            Hero hero = GameManager.Instance.GetHero();

            hero.Init(stats);

            Assert.AreEqual(100, hero.GetStats().maxHealth);

            hero.currentHealth = hero.GetStats().maxHealth;

            Assert.AreEqual(100, hero.currentHealth);

            hero.TakeDamage(20);

            yield return null;

            Assert.AreEqual(80, hero.currentHealth);


            // Create 6 health potion

            HealthPotion potion = new HealthPotion();
            HealthPotion potion2 = new HealthPotion();
            HealthPotion potion3 = new HealthPotion();
            HealthPotion potion4 = new HealthPotion();
            HealthPotion potion5 = new HealthPotion();
            HealthPotion potion6 = new HealthPotion();


            // Creation de l'inventaire
            Inventory inventory = new Inventory();
            inventory.items = new Queue<Item>();


            // add 5 potions in my inventory
            inventory.addItem(potion);
            inventory.addItem(potion2);
            inventory.addItem(potion3);
            inventory.addItem(potion4);
            inventory.addItem(potion5);

            Assert.AreEqual(5, inventory.getItems().Count);

            Queue<Item> itemsFull = inventory.getItems();

            //add a sixth one and check if it was drop
            inventory.addItem(potion6);

            Queue<Item> itemsFull2 = inventory.getItems();


            //check if the queue if the same
            Assert.IsTrue(itemsFull == itemsFull2);
            Assert.AreEqual(5, inventory.getItems().Count);


            // Use a potion
            inventory.useItem();

            // there must be one item less and an hero with more lofe
            Assert.AreEqual(4, inventory.getItems().Count);
            Assert.AreEqual(100, hero.currentHealth);

            inventory.useItem();

            Assert.AreEqual(3, inventory.getItems().Count);
            Assert.AreEqual(100, hero.currentHealth);
        }
    }
}

