using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha.AI
{
    /// <summary>
    /// A Node that do nothing during a define time (can be 0)
    /// </summary>
    public class BasicNode : Node
    {
        private float waitingTime = 0;

        /// <summary>
        /// Empty constructor
        /// </summary>
        public BasicNode() : base() { }

        /// <summary>
        /// Constructor with Graph and waitingTime
        /// </summary>
        /// <param name="graph">Graph containing the node</param>
        /// <param name="waitingTime">Time to wait in this Node</param>
        public BasicNode(Graph graph, float waitingTime = 0) : base(graph)
        {
            this.waitingTime = waitingTime;
        }

        /// <summary>
        /// Wait a time (can be 0)
        /// </summary>
        public override IEnumerator Action()
        {
            IsRunning = true;
            if (waitingTime > 0)
            {
                yield return new WaitForSeconds(waitingTime);
            }
            else
            {
                yield return null;
            }
            if (!AutomaticLinks.IsEmpty())
            {
                TryAllLink();
            }
            IsRunning = false;
        }
    }
}
