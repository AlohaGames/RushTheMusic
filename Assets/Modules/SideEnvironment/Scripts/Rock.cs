using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// Class for a rock
    /// </summary>
    public class Rock : SideEnvironment
    {
        float MAX_SIZE = 1f;
        float MIN_SIZE = 0.3f;

        /// <summary>
        /// Initialize a rock
        /// <example> Example(s):
        /// <code>
        ///     sideEnvInstR.Initialize();
        /// </code>
        /// </example>
        /// </summary>
        public override void Initialize()
        {
            // Generate random index
            int index = Utils.RandomInt(0, Sprite.Length);

            // Attribute sprite to prefab
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite[index];

            //Set the size of rock
            Height = Utils.RandomFloat(MIN_SIZE, MAX_SIZE);
            Width = Utils.RandomFloat(MIN_SIZE, MAX_SIZE);
        }
    }
}
