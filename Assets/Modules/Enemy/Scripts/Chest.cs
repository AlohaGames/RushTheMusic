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
        private Animator anim;

        public List<Item> itemListPrefab;

        /// <summary>
        /// Initialize the chest
        /// <example> Example(s):
        /// <code>
        ///     warrior.Init();
        /// </code>
        /// </example>
        /// </summary>
        public override void Init()
        {
            this.Init(this.stats);
            initialize();
        }

        /// <summary>
        /// Initialize the chest with stats
        /// <example> Example(s):
        /// <code>
        ///     chest.Init(chestStats);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="stats"></param>
        public void Init(ChestStats stats)
        {
            base.Init(stats);
            initialize();
        }

        /// <summary>
        /// Initialize chest variables
        /// <example> Example(s):
        /// <code>
        ///     this.initialize();
        /// </code>
        /// </example>
        /// </summary>
        private void initialize()
        {
            // TODO  Warning : Will change with mapping later, for now chest only gives heal potion
            this.item = Instantiate(this.itemListPrefab[0]);
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

        /// <summary>
        /// Method called if the chest dies
        /// </summary>
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
        healPotion = 0,
        ragePotion = 1,
        manaPotion = 2
    }
}
