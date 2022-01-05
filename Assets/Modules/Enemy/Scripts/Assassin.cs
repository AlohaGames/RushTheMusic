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
    public class Assassin : Enemy<AssassinStats>
    {
        private Hero hero;
        public Animator Anim;

        /// <summary>
        /// Is called on the frame when a script is enabled just before any of the Update methods are called the first time.
        /// </summary>
        void Start()
        {
            hero = GameManager.Instance.GetHero();
            Anim = GetComponent<Animator>();
        }

        /// <summary>
        /// Function to bump the assassin
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="speed"></param>
        public override IEnumerator GetBump(Vector3 direction, float speed = 2)
        {
            Anim.SetBool("isAttacking", false);
            yield return base.GetBump(direction, speed);
        }
    }
}
