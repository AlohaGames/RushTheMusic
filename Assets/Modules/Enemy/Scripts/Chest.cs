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

        /// <summary>
        /// Bump the entity in a specific direction and with a speed
        /// <example> Example(s):
        /// <code>
        ///     wall.GetBump(new Vector3(0, 0, 2), 2);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="speed"></param>
        public override IEnumerator GetBump(Vector3 direction, float speed = 2)
        {
            yield return null;
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
