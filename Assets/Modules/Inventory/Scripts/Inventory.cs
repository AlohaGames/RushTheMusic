using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    public class Inventory  : Singleton<Inventory>
    {

        private Queue<Item> items = new Queue<Item>();
        private int maxItem = 5;
        public void AddItem(Item item)
        {
            if(this.items.Count < this.maxItem)
            {
                this.items.Enqueue(item);
            }
        }

        public void UseItem()
        {
            if(this.items.Count > 0)
            {
                Item item = this.items.Dequeue();
                item.Effect();
            }

        }

        public Queue<Item> GetItems()
        {
            return this.items;
        }

        public int getMaxItems()
        {
            return this.maxItem;
        }
    }
}

