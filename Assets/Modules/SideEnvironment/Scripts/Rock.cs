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
            Height = 1;
        }
    }
}
