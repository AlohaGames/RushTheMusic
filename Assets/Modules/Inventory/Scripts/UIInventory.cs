using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha
{
    public class UIInventory : MonoBehaviour
    {
        private int nbItems;
        private int itemsCount;
        private GameObject horizontalLayout;
        private RectTransform horizontalLayoutTransform;
        // Start is called before the first frame update
        void Start()
        {
            // First, I contruct the UI
            ConstructInventoryUI();
            // Then, i refresh it with the current Items;
            ShowCurrentInventoryUI();
        }

        /*
         * This function show the current UI. It will be invoke each time we use an item or collect one
         * */
        void ShowCurrentInventoryUI()
        {
            nbItems = Inventory.Instance.getMaxItems();
            itemsCount = Inventory.Instance.GetItems().Count;
            for (int i = 0; i < nbItems; i++)
            {

                if (i < itemsCount){
                    if (i == 0){
                        this.gameObject.transform.GetChild(0).GetComponent<Image>().color = Color.blue;
                    }else{
                        this.gameObject.transform.GetChild(1).transform.GetChild(i - 1).GetComponent<Image>().color = Color.blue;
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

        /*
         * This method construct the UI. it will call once, when this class is loaded in the UIManager
         */
        void ConstructInventoryUI()
        {
            nbItems = Inventory.Instance.getMaxItems();
            horizontalLayout = this.gameObject.transform.GetChild(1).gameObject;
            horizontalLayoutTransform = horizontalLayout.GetComponent<RectTransform>();

            // Creation of the dynamic interface
            if (nbItems == 1)
            {
                Destroy(horizontalLayout);
            }
            else if (nbItems >= 3)
            {
                for (int i = 2; i < nbItems; i++)
                {
                    /*horizontalLayoutTransform.sizeDelta = new Vector2(horizontalLayoutTransform.sizeDelta.x + 75, horizontalLayoutTransform.sizeDelta.y);
                    Debug.Log(horizontalLayoutTransform.sizeDelta.x);
                    Debug.Log(horizontalLayoutTransform.sizeDelta.y);*/
                    GameObject image = new GameObject();
                    image.AddComponent<Image>();
                    image.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(50, 50);
                    image.transform.SetParent(horizontalLayoutTransform);
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

