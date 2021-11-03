using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    public class Inventory
    {

        public Queue<Item> items;

        private int maxItem = 5;


        public void addItem(Item item)
        {
            if(this.items.Count < this.maxItem)
            {
                this.items.Enqueue(item);
            }
        }

        public void useItem()
        {
            if(this.items.Count > 0)
            {
                Item item = this.items.Dequeue();
                item.effect();
            }

        }

        public Queue<Item> getItems()
        {
            return this.items;
        }
    }
}

