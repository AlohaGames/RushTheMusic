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
        public Animator Anim;
        public List<Item> ItemListPrefab;

        /// <summary>
        /// Initialize the chest
        /// <example> Example(s):
        /// <code>
        ///     chest.Init();
        /// </code>
        /// </example>
        /// </summary>
        public override void Init()
        {
            this.Init(this.stats as ChestStats);
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
            this.item = Instantiate(this.ItemListPrefab[(int)stats.Item]);
            ContainerManager.Instance.AddToContainer(ContainerTypes.Item, this.item.gameObject);
        }

        /// <summary>
        /// Is called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        void Update()
        {
            // Kill the chest if it goes behing the player
            if (transform.position.z < 0)
            {
                Destroy(this.gameObject);
            }
        }

        /// <summary>
        /// Bump the entity in a specific direction and with a speed
        /// <example> Example(s):
        /// <code>
        ///     StartCoroutine(wall.GetBump(new Vector3(0, 0, 2), 2));
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="direction">The direction of enemy bumping</param>
        /// <param name="speed">The speed of enemy bumping</param>
        public override IEnumerator GetBump(Vector3 direction, float speed = 0)
        {
            yield return null;
        }

        /// <summary>
        /// Method called if the chest dies
        /// </summary>
        public override void Die()
        {
            Anim.SetBool("isOpen", true);
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
        manaPotion = 2,
        experiencePotion = 3
    }
}
