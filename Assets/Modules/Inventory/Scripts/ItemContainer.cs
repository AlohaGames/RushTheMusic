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

        private void Start()
        {
            HealPotion hp = new HealPotion(20);
            //SetItem(hp);
        }

        public void SetItem(Item item)
        {
            linkedItem = item;
            if (linkedItem != null)
            {
                itemDisplayComponent.sprite = sprite;
                // TODO Replace by something like this
                //itemDisplayComponent.sprite = linkedItem.sprite
            }
            else
            {
                itemDisplayComponent.sprite = null;
            }
        }
    }
}
