using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Aloha.Events;

namespace Aloha
{
    /// <summary>
    /// This class manages the inventory
    /// </summary>
    public class InventoryManager : Singleton<InventoryManager>
    {
        private Queue<Item> items = new Queue<Item>();
        private int maxItem = 5;

        /// <summary>
        /// Is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        {
            GlobalEvent.GameStop.AddListener(Reset);
        }

        /// <summary>
        /// Add an item to the inventory, if the inventory is full, the new item will be dropped
        /// <example> Example(s):
        /// <code>
        ///     AddItem(item);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(Item item)
        {
            if (this.items.Count < this.maxItem)
            {
                this.items.Enqueue(item);
                UIManager.Instance.UIInventory.UpdateInventoryUI();
            }
        }

        /// <summary>
        /// Use the first item of the queue and delete it after
        /// <example> Example(s):
        /// <code>
        ///     AddItem(item);
        /// </code>
        /// </example>
        /// </summary>
        public void UseItem()
        {
            if (this.items.Count > 0)
            {
                Item item = this.items.Dequeue();
                item.Effect();
            }
            UIManager.Instance.UIInventory.UpdateInventoryUI();
            ContainerManager.Instance.ClearContainer(ContainerTypes.Item);
        }

        /// <summary>
        /// Get all the items of our inventory. WARNING : it's not a copy, it's the instance of the items
        /// <example> Example(s):
        /// <code>
        ///     Inventory inventory = new Inventory();
        ///     Queue(item) items = inventory.GetItems();
        /// </code>
        /// </example>
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
        /// <example> Example(s):
        /// <code>
        ///     Inventory inventory = new Inventory();
        ///     int maxItems = inventory.GetMaxItems();
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>
        /// An integer with the value of the max size of the inventory.
        /// </returns>
        public int GetMaxItems()
        {
            return this.maxItem;
        }

        /// <summary>
        /// Reset the inventory
        /// </summary>
        public void Reset()
        {
            this.items.Clear();
        }

        /// <summary>
        /// Is called when a Scene or game ends.
        /// </summary>
        void OnDestroy()
        {
            GlobalEvent.GameStop.RemoveListener(Reset);
        }
    }
}
