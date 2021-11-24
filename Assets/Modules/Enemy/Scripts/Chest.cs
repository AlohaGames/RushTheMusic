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

        private Animator anim;

        public override void Init()
        {
            this.Init(this.stats);
            initialize();
        }

        public void Init(ChestStats stats)
        {
            base.Init(stats);
            initialize();
        }

        private void initialize()
        {
            // Warning : Will change with mapping later, for now chest only gives heal potion
            this.item = new HealPotion(100);
            anim = GetComponent<Animator>();
        }

        public override void Die()
        {
            anim.SetBool("isOpen", true);
            InventoryManager.Instance.AddItem(this.item);
            base.Die();
        }
    }

    /// <summary>
    /// Enumerate the list of items listed in Chest
    /// </summary>
    public enum ItemType
    {
        healPotion = 0
    }
}
