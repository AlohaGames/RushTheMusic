using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// This class manage the inventory
    /// </summary>
    public class Inventory  : Singleton<Inventory>
    {
        private Queue<Item> items = new Queue<Item>();
        private int maxItem = 5;
        /// <summary>
        /// Add an item to the inventory, if the inventory is full, the new item will be dropped
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(Item item)
        {
            if(this.items.Count < this.maxItem)
            {
                this.items.Enqueue(item);
            }
        }

        /// <summary>
        /// We use the firt item of the queue and we delete it after
        /// </summary>
        public void UseItem()
        {
            if(this.items.Count > 0)
            {
                Item item = this.items.Dequeue();
                item.Effect();
            }
        }

        /// <summary>
        /// Get all the items of our inventory. WARNING : it's not a copy, it's the instance of the items
        /// </summary>
        /// <returns>
        /// A queue with all the items in the inventory
        /// </returns>
        public Queue<Item> GetItems()
        {
            return this.items;
        }

        /// <summary>
        /// Get the max size of the inventory
        /// </summary>
        /// <returns>
        /// An integer with the value of the max size of the inventory.
        /// </returns>
        public int GetMaxItems()
        {
            return this.maxItem;
        }
    }
}
