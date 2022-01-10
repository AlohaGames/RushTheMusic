using System.Collections;
using UnityEngine;
using Aloha.EntityStats;

namespace Aloha
{
    /// <summary>
    /// Class for the bat
    /// </summary>
    public class Bat : Enemy<BatStats>
    {
        public Animator Anim;

        /// <summary>
        /// Is called on the frame when a script is enabled just before any of the Update methods are called the first time.
        /// </summary>
        void Start()
        {
            Anim = GetComponent<Animator>();
        }
    }
}
