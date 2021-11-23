using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Aloha;

namespace Aloha.AI
{
    public abstract class Node
    {
        public bool IsRunning = false;
        public List<EventLink> EventLinks = new List<EventLink>();
        public List<AutomaticLink> AutomaticLinks = new List<AutomaticLink>();

        public Graph Graph;

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
                    random = random - link.probability;
                }
            }
        }

        public void AddAutomaticLink(Node next, float probability)
        {
            AutomaticLink link = new AutomaticLink(probability);
            link.from = this;
            link.to = next;
            AutomaticLinks.Add(link);
        }

        public void AddEventLink(Node next, UnityEvent trigger)
        {
            EventLink link = new EventLink(trigger);
            link.from = this;
            link.to = next;
            EventLinks.Add(link);
        }

        public Node() { }
        public Node(Graph graph)
        {
            this.Graph = graph;
        }

    }
}
