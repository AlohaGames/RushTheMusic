using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha
{
    public class ItemContainer : MonoBehaviour
    {
        private Item linkedItem;

        [SerializeField]
        private Image itemDisplayComponent;

        [SerializeField]
        private Sprite sprite;

        public void SetItem(Item item)
        {
            linkedItem = item;
            if (linkedItem != null)
            {
                Color tempColor = itemDisplayComponent.color;
                tempColor.a = 1f;
                itemDisplayComponent.color = tempColor;

                itemDisplayComponent.sprite = sprite;
                // TODO Replace by something like this
                //itemDisplayComponent.sprite = linkedItem.sprite
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
