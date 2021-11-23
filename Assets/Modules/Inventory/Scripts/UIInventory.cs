using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha
{
    /// <summary>
    /// This class manage the inventory canvas
    /// </summary>
    public class UIInventory : MonoBehaviour
    {
        private int nbMaxItems;
        private Queue<Item> items;

        [SerializeField]
        private GameObject inventoryUI;

        [SerializeField]
        private ItemContainer itemContainerPrefab;

        /// <summary>
        /// This function show the current UI. It will be invoke each time we use an item or collect one
        /// <example> Example(s):
        /// <code>
        ///     UpdateInventoryUI()
        /// </code>
        /// </example>
        /// </summary>
        public void UpdateInventoryUI()
        {
            nbMaxItems = InventoryManager.Instance.GetMaxItems();
            items = InventoryManager.Instance.GetItems();
            Item[] itemsArray = items.ToArray();

            for (int i = 0; i < nbMaxItems; i++)
            {
                ItemContainer itemContainer = inventoryUI.transform.GetChild(i).GetComponent<ItemContainer>();
                if (i < itemsArray.Length)
                {
                    itemContainer.SetItem(itemsArray[i]);
                }
                else
                {
                    itemContainer.SetItem(null);
                }
            }
        }

        /// <summary>
        /// This method construct the UI to store items
        /// <example> Example(s):
        /// <code>
        ///     ConstructInventoryUI()
        /// </code>
        /// </example>
        /// </summary>
        public void ConstructInventoryUI()
        {
            nbMaxItems = InventoryManager.Instance.GetMaxItems();

            ItemContainer firstItemContainer = inventoryUI.transform.GetChild(0).GetComponent<ItemContainer>();
            firstItemContainer.SetItem(null);

            // Creation of the dynamic interface
            if (nbMaxItems >= 1)
            {
                for (int i = 0; i < nbMaxItems - 1; i++)
                {
                    ItemContainer itemContainer = Instantiate(itemContainerPrefab);
                    itemContainer.SetItem(null);
                    itemContainer.transform.SetParent(inventoryUI.transform);
                    itemContainer.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                }
            }
        }

        /// <summary>
        /// Display UI of inventory
        /// <example> Example(s):
        /// <code>
        ///     ShowInGameInventory()
        /// </code>
        /// </example>
        /// </summary>
        public void ShowInGameInventory()
        {
            inventoryUI.SetActive(true);

            ConstructInventoryUI();

            InventoryManager.Instance.AddItem(new HealPotion(20));
            InventoryManager.Instance.AddItem(new HealPotion(20));
        }
    }
}
