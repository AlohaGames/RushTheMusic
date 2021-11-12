using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha.AI
{
    public class BasicNode : Node
    {
        private int waitingTime = 0;
        public BasicNode() : base() { }
        public BasicNode(Graph graph, int waitingTime = 0) : base(graph)
        {
            this.waitingTime = waitingTime;
        }

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
                yield return TryAllLink();
            }
            IsRunning = false;
        }
    }
}
