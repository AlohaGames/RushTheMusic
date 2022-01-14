using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Aloha.EntityStats;

namespace Aloha
{
    /// <summary>
    /// Class that manage utils functions
    /// </summary>
    public class Spider : Enemy<SpiderStats>
    {
        /// public Animator Anim;

        /// <summary>
        /// Is called on the frame when a script is enabled just before any of the Update methods are called the first time.
        /// </summary>
        void Start()
        {
            ///Anim = GetComponent<Animator>();
        }
    }

}