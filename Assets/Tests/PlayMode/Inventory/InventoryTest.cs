using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Aloha.Test
{
    /// <summary>
    /// Tests for the inventory
    /// </summary>
    public class InventoryTest
    {
        /// <summary>
        /// Check if item can be added to inventory
        /// </summary>
        [Test]
        public void InventoryAddItemTest()
        {
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));

            Assert.AreEqual(0, InventoryManager.Instance.GetItems().Count);
            HealPotion healthPotion = new HealPotion(5);
            InventoryManager.Instance.AddItem(healthPotion);

            Assert.AreEqual(1, InventoryManager.Instance.GetItems().Count);

            Utils.ClearCurrentScene(true);
        }

        /// <summary>
        /// Check if item can be added to inventory and used
        /// </summary>
        [Test]
        public void InventoryMaxItemTest()
        {
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));

            Assert.AreEqual(5, InventoryManager.Instance.GetMaxItems());

            Utils.ClearCurrentScene(true);
        }

    }
}
