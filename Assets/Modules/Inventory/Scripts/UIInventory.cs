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
            nbMaxItems = Inventory.Instance.GetMaxItems();
            items = Inventory.Instance.GetItems();
            Item[] itemsArray = items.ToArray();

            Debug.Log("maxitem : "+nbMaxItems);
            Debug.Log("length : " + itemsArray.Length);

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
        ///  This method construct the UI. it will call once, when this class is loaded in the UIManager
        ///  <example> Example(s):
        /// <code>
        ///     ConstructInventoryUI()
        /// </code>
        /// </example>
        /// </summary>
        public void ConstructInventoryUI()
        {
            nbMaxItems = Inventory.Instance.GetMaxItems();

            // Creation of the dynamic interface
            if (nbMaxItems >= 1)
            {
                for (int i = 0; i < nbMaxItems - 1; i++)
                {
                    ItemContainer itemContainer = Instantiate(itemContainerPrefab);
                    itemContainer.transform.SetParent(inventoryUI.transform);
                    itemContainer.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                }
            }
        }

        public void ShowInGameInventory()
        {
            inventoryUI.SetActive(true);

            // First, contruct the UI
            ConstructInventoryUI();
        }
    }
}
