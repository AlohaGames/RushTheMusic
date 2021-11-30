using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Aloha.Test
{
    public class UserItemTest
    {
        /// <summary>
        /// Check if the itemUser use the last item of the inventory
        /// </summary>
        [UnityTest]
        public IEnumerator UseItemTest()
        {
            // Instance Chest
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            HeroInstantier.Instance.InstantiateHero(HeroType.Warrior);

            GameObject itemUserGO = new GameObject();
            ItemUser itemUser = itemUserGO.AddComponent<ItemUser>();
            itemUser.transform.position = new Vector3(0, 0, 1);
            itemUser.transform.eulerAngles = new Vector3(0, 0, 45);
            yield return null;

            // Get item list
            Queue<Item> items = InventoryManager.Instance.GetItems();
            Assert.AreEqual(0, items.Count);

            GameObject healthPotionGO = new GameObject();
            HealPotion healthPotion = healthPotionGO.AddComponent<HealPotion>();
            InventoryManager.Instance.AddItem(healthPotion);

            items = InventoryManager.Instance.GetItems();
            Assert.AreEqual(1, items.Count);

            itemUser.transform.position = new Vector3(0, 0, 0.5f);
            yield return null;

            itemUser.transform.position = new Vector3(0, 0, 0);
            itemUser.transform.eulerAngles = new Vector3(0, 0, 0);
            yield return null;

            items = InventoryManager.Instance.GetItems();
            Assert.AreEqual(0, items.Count);

            // Clear the scene
            Utils.ClearCurrentScene();
            yield return null;
        }
    }
}
