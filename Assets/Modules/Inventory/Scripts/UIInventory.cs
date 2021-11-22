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
        private GameObject horizontalLayout;
        private RectTransform horizontalLayoutTransform;

        /// <summary>
        ///  Start is called before the first frame update
        /// </summary>
        public void Start()
        {
            // First, contruct the UI
            ConstructInventoryUI();
            // Then, refresh it with the current Items
            ShowCurrentInventoryUI();
        }

        /// <summary>
        /// This function show the current UI. It will be invoke each time we use an item or collect one
        /// <example> Example(s):
        /// <code>
        ///     ShowCurrentInventoryUI()
        /// </code>
        /// </example>
        /// </summary>
        public void ShowCurrentInventoryUI()
        {
            // TODO Change this by the new potion assets
            nbMaxItems = Inventory.Instance.GetMaxItems();
            items = Inventory.Instance.GetItems();
            Item[] itemsArray = items.ToArray();
            Color color = Color.white;
            for (int i = 0; i < nbMaxItems; i++)
            {
                if (i < itemsArray.Length){
                    if (itemsArray[i] is HealPotion) color = Color.blue;
                    if (i == 0){
                        this.gameObject.transform.GetChild(0).GetComponent<Image>().color = color;
                    }else{
                        this.gameObject.transform.GetChild(1).transform.GetChild(i - 1).GetComponent<Image>().color = color;
                    }
                }else{
                    if (i == 0){
                        this.gameObject.transform.GetChild(0).GetComponent<Image>().color = Color.white;
                    }else{
                        this.gameObject.transform.GetChild(1).transform.GetChild(i - 1).GetComponent<Image>().color = Color.white;
                    }
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
            horizontalLayout = this.gameObject.transform.GetChild(1).gameObject;
            horizontalLayoutTransform = horizontalLayout.GetComponent<RectTransform>();

            // Creation of the dynamic interface
            if (nbMaxItems == 1)
            {
                Destroy(horizontalLayout);
            }
            else if (nbMaxItems >= 3)
            {
                for (int i = 2; i < nbMaxItems; i++)
                {
                    GameObject image = new GameObject();
                    image.AddComponent<Image>();
                    image.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(50, 50);
                    image.transform.SetParent(horizontalLayoutTransform);
                }
            }
        }
    }
}
