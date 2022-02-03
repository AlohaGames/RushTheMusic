using UnityEngine;
using UnityEngine.UI;

namespace Aloha
{
    /// <summary>
    /// Class for a panel sign
    /// </summary>
    public class Panel : SideEnvironment
    {
        /// <summary>
        /// Initialize animal
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
            this.gameObject.GetComponentInChildren<Image>().sprite = Sprite[index];

            //Set the size of Panel
            Height = 0.7f;
            Width = 0.7f;
        }
    }
}