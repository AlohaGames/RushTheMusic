using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha;

namespace Aloha.AI
{
    /// <summary>
    /// A Node that make the gameObject teleport forward
    /// </summary>
    public class ExperionTeleportation : GONode
    {
        private float maxX = 2.5f;
        private Experion experion;

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public ExperionTeleportation() : base()
        {
            experion = gameObject.GetComponent<Experion>();
        }

        /// <summary>
        /// ExperionTeleportation Node constructor
        /// </summary>
        /// <param name="graph">Graph containing the node</param>
        public ExperionTeleportation(Graph graph) : base(graph)
        {
            experion = gameObject.GetComponent<Experion>();
        }

        /// <summary>
        /// Teleport forward the gameObject
        /// </summary>
        public override IEnumerator Action()
        {
            IsRunning = true;
            if (experion.transform.position.z > 6)
            {
                experion.Anim.ResetTrigger("TeleportBack");
                experion.Anim.SetTrigger("Teleport");
                SoundEffectManager.Instance.Play(
                    SoundEffectManager.Instance.Sounds.experion_teleportation, experion.gameObject
                );
                yield return new WaitForSeconds(0.5f);

                Vector3 newPosition = experion.transform.position;
                Vector3 add = experion.transform.forward * Utils.RandomFloat(5, 10);
                newPosition += add;

                if (newPosition.z < 6)
                {
                    newPosition.z = 6;
                }
                newPosition.x = Utils.RandomFloat(-maxX, maxX);

                gameObject.transform.Translate(-(newPosition - experion.transform.position));

                experion.Anim.ResetTrigger("Teleport");
                experion.Anim.SetTrigger("TeleportBack");
                yield return new WaitForSeconds(0.5f);

                experion.Anim.ResetTrigger("TeleportBack");
            }

            yield return null;

            if (!AutomaticLinks.IsEmpty())
            {
                TryAllLink();
            }
            IsRunning = false;
        }
    }
}
