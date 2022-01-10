using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// Class for a tree
    /// </summary>
    public class Tree : SideEnvironment
    {
        [SerializeField]
        float MAX_TREE_HEIGHT;

        /// <summary>
        /// Initilize a tree
        /// <example> Example(s):
        /// <code>
        ///     sideEnvInstR.Initialize();
        /// </code>
        /// </example>
        /// </summary>
        public override void Initialize()
        {
            Height = Utils.RandomFloat(1, MAX_TREE_HEIGHT);
        }
    }
}
