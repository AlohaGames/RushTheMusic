using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{

    public class Inventory
    {
        /// <summary>
        /// TODO
        /// </summary>
        private Queue<Item> items = new Queue<Item>();
        private int maxItem = 5;

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
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
        /// TODO
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
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
        /// TODO
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>
        /// TODO
        /// </returns>
        public Queue<Item> GetItems()
        {
            return this.items;
        }
    }
}
