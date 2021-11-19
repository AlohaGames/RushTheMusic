using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Aloha.Test
{
    // Test the UI of the inventory
    public class InventoryUITest
    {
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator InventoryUIWithEnumeratorPasses()
        {
            // Declaration of a hero
            HeroStats InventoryUiTestherostats = ScriptableObject.CreateInstance<HeroStats>();
            InventoryUiTestherostats.Attack = 100;
            InventoryUiTestherostats.Defense = 0;
            InventoryUiTestherostats.MaxHealth = 100;

            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            HeroInstantier.Instance.InstantiateHero(HeroType.Generic);
            Hero InventoryUiTesthero = GameManager.Instance.GetHero();
            InventoryUiTesthero.Init(InventoryUiTestherostats);
            // The hero take 20 damage that will be heal after
            InventoryUiTesthero.TakeDamage(20);
            Assert.AreEqual(80, InventoryUiTesthero.CurrentHealth);

            GameObject Inventory = new GameObject();
            Inventory.AddComponent<Inventory>();

            GameObject InventoryUI = new GameObject();
            InventoryUI.AddComponent<UIInventory>();

            // The three following code groups are simulating my canvas 
            //Firstitem
            GameObject firstItem = new GameObject();
            firstItem.AddComponent<Image>();
            firstItem.transform.SetParent(InventoryUI.transform);

            //HorizontalLayoutGroup
            GameObject horizontalLayoutGroupObject = new GameObject();
            horizontalLayoutGroupObject.AddComponent<HorizontalLayoutGroup>();
            horizontalLayoutGroupObject.transform.SetParent(InventoryUI.transform);
            HorizontalLayoutGroup horizontalLayoutGroup = horizontalLayoutGroupObject.GetComponent<HorizontalLayoutGroup>();
            horizontalLayoutGroup.spacing = 25;

            // The first image child of horizontalLayoutGroup
            GameObject Image1Object = new GameObject();
            Image1Object.AddComponent<Image>();
            Image1Object.transform.SetParent(horizontalLayoutGroupObject.transform);

            UIInventory inventoryUI = InventoryUI.GetComponent<UIInventory>();
            Inventory inventory = Inventory.GetComponent<Inventory>();

            // Adding three item
            inventory.AddItem(new HealPotion(20));
            inventory.AddItem(new HealPotion(20));
            inventory.AddItem(new HealPotion(20));

            //check if we have three items now
            Queue<Item> items = inventory.GetItems();
            Assert.AreEqual(3, items.Count);

            // start the inventoryUI Starting code (regenrate the Ui)
            inventoryUI.Start();

            // We have 5 max item so i must have 4 child for my horizontalLayoutGroup, the fifth is the firstItem gameobject)
            Assert.AreEqual(4, horizontalLayoutGroupObject.transform.childCount);

            // Inventory have 3 items so we must have 3 blue cases.
            Assert.AreEqual(Color.blue, firstItem.GetComponent<Image>().color);
            Assert.AreEqual(Color.blue, horizontalLayoutGroup.transform.GetChild(0).GetComponent<Image>().color);
            Assert.AreEqual(Color.blue, horizontalLayoutGroup.transform.GetChild(1).GetComponent<Image>().color);
            Assert.AreNotEqual(Color.blue, horizontalLayoutGroup.transform.GetChild(2).GetComponent<Image>().color);
            
            // Using healpotion item
            inventory.UseItem();
            Assert.AreEqual(100, InventoryUiTesthero.CurrentHealth);
            Assert.AreEqual(InventoryUiTesthero.GetStats().MaxHealth, InventoryUiTesthero.CurrentHealth);

            // Now we have only two item
            items = inventory.GetItems();
            Assert.AreEqual(2, items.Count);

            // Now we start the function ShowCurrentInventoryTU
            inventoryUI.ShowCurrentInventoryUI();

            // Now the third case must not be blue
            Assert.AreNotEqual(Color.blue, horizontalLayoutGroup.transform.GetChild(1).GetComponent<Image>().color);

            // Add 2 items
            inventory.AddItem(new HealPotion(20));
            inventory.AddItem(new HealPotion(20));

            // Now we have four object
            items = inventory.GetItems();
            Assert.AreEqual(4, items.Count);

            // refresh the UI
            inventoryUI.ShowCurrentInventoryUI();

            // Check if only our first four cases are blue
            Assert.AreEqual(Color.blue, firstItem.GetComponent<Image>().color);
            Assert.AreEqual(Color.blue, horizontalLayoutGroup.transform.GetChild(0).GetComponent<Image>().color);
            Assert.AreEqual(Color.blue, horizontalLayoutGroup.transform.GetChild(1).GetComponent<Image>().color);
            Assert.AreEqual(Color.blue, horizontalLayoutGroup.transform.GetChild(2).GetComponent<Image>().color);
            Assert.AreNotEqual(Color.blue, horizontalLayoutGroup.transform.GetChild(3).GetComponent<Image>().color);


            GameObject.Destroy(manager);
            GameObject.Destroy(inventory);
            GameObject.Destroy(InventoryUI);
            GameObject.Destroy(firstItem);
            GameObject.Destroy(Image1Object);
            GameObject.Destroy(horizontalLayoutGroupObject);

            yield return null;
        }
    }
}
