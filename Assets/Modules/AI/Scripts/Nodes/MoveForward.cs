using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha.AI
{
    /// <summary>
    /// A Node that make the gameObject move forward by one step at speed of Tiles
    /// </summary>
    public class MoveForward : GONode
    {
        /// <summary>
        /// Empty Constructor
        /// </summary>
        public MoveForward() : base() { }

        /// <summary>
        /// MoveForward Node constructor
        /// </summary>
        /// <param name="graph">Graph containing the node</param>
        public MoveForward(Graph graph) : base(graph) { }

        /// <summary>
        /// Move forward the gameObject
        /// </summary>
        public override IEnumerator Action()
        {
            IsRunning = true;

            gameObject.transform.Translate(Vector3.forward * TilesManager.Instance.TileSpeed * Time.deltaTime);
            yield return null;

            if (!AutomaticLinks.IsEmpty())
            {
                TryAllLink();
            }
            IsRunning = false;
        }
    }
}
