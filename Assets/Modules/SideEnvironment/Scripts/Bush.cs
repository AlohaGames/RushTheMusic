using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// Class for a bush
    /// </summary>
    public class Bush : SideEnvironment
    {
        float MAX_SIZE = 1f;
        float MIN_SIZE = 0.4f;

        /// <summary>
        /// Initialize bush
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

            //Set the size of bush
            Height = Utils.RandomFloat(MIN_SIZE, MAX_SIZE);
            Width = Utils.RandomFloat(MIN_SIZE, MAX_SIZE);
        }
    }
}