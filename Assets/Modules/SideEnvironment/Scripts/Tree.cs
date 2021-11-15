using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// TODO
    /// </summary>
    public class Tree : SideEnvironment
    {
        [SerializeField]
        float MAX_TREE_HEIGHT;

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
        public override void Initialize()
        {
            Height = Utils.RandomFloat(1, MAX_TREE_HEIGHT);
        }
    }
}
