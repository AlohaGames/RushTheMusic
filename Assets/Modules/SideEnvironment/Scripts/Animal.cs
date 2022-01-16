using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// Class for animals
    /// </summary>
    public class Animal : SideEnvironment
    {

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

            //Set the size of animal
            Height = 1;
            Width = 1;
        }
    }
}