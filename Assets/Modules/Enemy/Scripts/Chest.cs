using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.EntityStats;

namespace Aloha
{
    /// <summary>
    /// Class of a Chest
    /// </summary>
    public class Chest : Enemy<ChestStats>
    {
        private Item item;
        public List<Item> itemListPrefab;

        public override void Init()
        {
            this.Init(this.stats);
            //this.item = itemListPrefab[(int) ;
            this.item = new HealPotion(100);
        }

        public void Init(ChestStats stats)
        {
            base.Init(stats);
            //this.item = itemListPrefab[(int) ;
            this.item = new HealPotion(100);
        }

        public override void Die()
        {
            Debug.Log("coucou");

            InventoryManager.Instance.AddItem(this.item);
            base.Die();
        }

        //private IEnumerator 
    }

    /// <summary>
    /// Enumerate the list of items listed in Chest
    /// </summary>
    public enum ItemType
    {
        healPotion = 0
    }
}