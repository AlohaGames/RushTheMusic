using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// Class for the side environment
    /// </summary>
    public abstract class SideEnvironment : MonoBehaviour
    {
        public float Height;

        /// <summary>
        /// Initialize the side environment
        /// <example>
        ///     sideEnvInstR.Initialize();
        /// </example>
        /// </summary>
        public abstract void Initialize();
    }
}
