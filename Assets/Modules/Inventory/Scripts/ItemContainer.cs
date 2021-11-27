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
        public Image ItemDisplayComponent; 

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
                Color tempColor = ItemDisplayComponent.color;
                tempColor.a = 1f;
                ItemDisplayComponent.color = tempColor;

                ItemDisplayComponent.sprite = item.ItemSprite;
                Debug.Log("Name item sprite: " + item.ItemSprite.name);
            }
            else
            {
                Color tempColor = ItemDisplayComponent.color;
                tempColor.a = 0f;
                ItemDisplayComponent.color = tempColor;
                ItemDisplayComponent.sprite = null;
            }
        }
    }
}
