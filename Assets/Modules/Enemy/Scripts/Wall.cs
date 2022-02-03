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
            this.NearHeroTrigger.AddListener(RunAndStopTiles);
        }

        /// <summary>
        /// Bump the entity in a specific direction and with a speed
        /// <example> Example(s):
        /// <code>
        ///     StartCoroutine(wall.GetBump(new Vector3(0, 0, 2), 2));
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="direction">The direction of enemy bumping</param>
        /// <param name="speed">The speed of enemy bumping</param>
        public override IEnumerator GetBump(Vector3 direction, float speed = 2)
        {
            yield return null;
        }

        /// <summary>
        /// Override take damages function
        /// <example> Example(s):
        /// <code>
        ///     wall.TakeDamage(20);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="damage"></param>
        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            SoundEffectManager.Instance.Play(
                SoundEffectManager.Instance.Sounds.wall_hurt, this.gameObject
            );
        }

        /// <summary>
        /// Stop or run tiles according to current state
        /// <example> Example(s):
        /// <code>
        ///     runAndStopTiles();
        /// </code>
        /// </example>
        /// </summary>
        private void RunAndStopTiles()
        {
            if (!isTilesStopped)
            {
                if (this.CurrentHealth > 0) // Security to avoid this case if the wall is in death animation
                {
                    lastTileSpeed = TilesManager.Instance.TileSpeed;
                    TilesManager.Instance.ChangeTileSpeed(0);
                    isTilesStopped = true;
                }
            }
            else
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
            anim.SetTrigger("isDead");
            if (isTilesStopped) RunAndStopTiles();
            base.Die();
        }

        /// <summary>
        /// Security if the game is loose when the game is stopped
        /// </summary>
        private void OnDestroy()
        {
            if (isTilesStopped) RunAndStopTiles();
        }
    }
}
