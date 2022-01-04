using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Aloha;

namespace Aloha.AI
{
    /// <summary>
    /// A Node is a state of the Graph,
    /// it is define by a specific Action and different Link to other Node
    /// </summary>
    public abstract class Node
    {
        public bool IsRunning = false;
        public List<EventLink> EventLinks = new List<EventLink>();
        public List<AutomaticLink> AutomaticLinks = new List<AutomaticLink>();
        public Graph Graph;

        /// <summary>
        /// The Action to be run when Node is active
        /// </summary>
        public virtual IEnumerator Action()
        {
            IsRunning = true;
            yield return null;
            if (!AutomaticLinks.IsEmpty())
            {
                TryAllLink();
            }
            IsRunning = false;
        }

        /// <summary>
        /// Try to pass throw all AutomaticLink
        /// </summary>
        protected void TryAllLink()
        {
            int count = AutomaticLinks.Count;
            float random = Utils.RandomFloat();
            foreach (AutomaticLink link in AutomaticLinks)
            {
                if (link.TryLink(random))
                {
                    break;
                }
                else
                {
                    random = random - link.Probability;
                }
            }
        }

        /// <summary>
        /// Add an AutomaticLink to another Node
        /// </summary>
        /// <param name="next">The node that need to be connect to</param>
        /// <param name="probability">The probability to use this link</param>
        public void AddAutomaticLink(Node next, float probability)
        {
            AutomaticLink link = new AutomaticLink(probability);
            link.From = this;
            link.To = next;
            AutomaticLinks.Add(link);
        }

        /// <summary>
        /// Add an EventLink to another Node
        /// </summary>
        /// <param name="next">The node that need to be connect to</param>
        /// <param name="trigger">The UnityEvent the link need to listen</param>
        public void AddEventLink(Node next, UnityEvent trigger)
        {
            EventLink link = new EventLink(trigger);
            link.From = this;
            link.To = next;
            EventLinks.Add(link);
        }

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public Node() { }

        /// <summary>
        /// Node Constructor
        /// </summary>
        /// <param name="graph">Graph containing the node</param>
        public Node(Graph graph)
        {
            this.Graph = graph;
        }

    }
}
