using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha
{
    /// <summary>
    /// This class manage the inventory item container 
    public class ItemContainer : MonoBehaviour
    {
        public Image itemDisplayComponent; 

        /// <summary>
        /// Set the item in inventory container
        /// <example> Example(s): 
        /// <code>
        ///     RagePotion ragePotion = new RagePotion();
        ///     itemContainer.SetItem(null);
        ///     itemContainer.SetItem(ragePotion);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="hpGain"></param>
        public void SetItem(Item item)
        {
            if (item != null)
            {
                Color tempColor = itemDisplayComponent.color;
                tempColor.a = 1f;
                itemDisplayComponent.color = tempColor;

                itemDisplayComponent.sprite = item.itemSprite;
                Debug.Log("Name item sprite: " + item.itemSprite.name);
            }
            else
            {
                Color tempColor = itemDisplayComponent.color;
                tempColor.a = 0f;
                itemDisplayComponent.color = tempColor;
                itemDisplayComponent.sprite = null;
            }
        }
    }
}
