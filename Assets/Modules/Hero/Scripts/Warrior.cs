using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// TODO
    /// </summary>
    public class Warrior : Hero<WarriorStats>
    {
        private int currentRage;

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="stats"></param>
        public void Init(WarriorStats stats)
        {
            base.Init(stats);
            this.currentRage = stats.MaxRage;
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="speed"></param>
        /// <returns>
        /// TODO
        /// </returns>
        public void BumpEntity(Entity entity, float speed)
        {
            Vector3 direction = new Vector3(0, 0, 2);
            StartCoroutine(entity.GetBump(direction, speed));
        }
    }
}
