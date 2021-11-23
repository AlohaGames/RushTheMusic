using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Aloha.EntityStats;

namespace Aloha
{
    /// <summary>
    /// A wall enemy
    /// </summary>
    public class Wall : Enemy<WallStats>
    {
        private Animator anim;
        private bool isTilesStopped;
        private float lastTileSpeed;

        /// <summary>
        /// Is called on the frame when a script is enabled just before any of the Update methods are called the first time.
        /// </summary>
        void Start()
        {
            anim = GetComponent<Animator>();
            lastTileSpeed = 0;
            isTilesStopped = false;
        }

        /// <summary>
        /// Coroutine to start artificial intelligence of the wall
        /// <example> Example(s):
        /// <code>
        ///     StartCoroutine(Wall.AI());
        /// </code>
        /// </example>
        /// </summary>
        protected override IEnumerator AI()
        {
            if (!isTilesStopped) runAndStopTiles();
            yield return null;
        }

        /// <summary>
        /// Stop or run tiles according to current state
        /// <example> Example(s):
        /// <code>
        ///     runAndStopTiles();
        /// </code>
        /// </example>
        /// </summary>
        private void runAndStopTiles()
        {
            if (!isTilesStopped)
            {
                lastTileSpeed = TilesManager.Instance.TileSpeed;
                TilesManager.Instance.ChangeTileSpeed(0);
                isTilesStopped = true;
            } else
            {
                TilesManager.Instance.ChangeTileSpeed(lastTileSpeed);
                isTilesStopped = false;
            }
        }

        /// <summary>
        /// Method called if the wall dies
        /// </summary>
        public override void Die()
        {
            if (isTilesStopped) runAndStopTiles();
            base.Die();
        }
    }
}
