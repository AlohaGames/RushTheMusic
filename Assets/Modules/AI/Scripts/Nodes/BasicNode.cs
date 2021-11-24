using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha.AI
{
    /// <summary>
    /// A Node that do nothing during a define time (can be )
    /// </summary>
    public class BasicNode : Node
    {
        private int waitingTime = 0;
        public BasicNode() : base() { }
        public BasicNode(Graph graph, int waitingTime = 0) : base(graph)
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
