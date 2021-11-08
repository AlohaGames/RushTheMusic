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

        public StateGraph Graph;

        public virtual IEnumerator Action()
        {
            IsRunning = true;
            yield return null;
            if (!AutomaticLinks.IsEmpty())
            {
                yield return TryAllLink();
            }
            IsRunning = false;
        }

        protected IEnumerator TryAllLink()
        {
            Debug.Log("TryAllLink");
            // TODO Améliorer je pense pas que ce soit vraiment ouf comme méthode
            int i = 0;
            int count = AutomaticLinks.Count;
            while (IsRunning && !AutomaticLinks[i].TryLink())
            {
                i = (i + 1) % count;
            }
            yield return null;
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
        public Node(StateGraph graph) { 
            this.Graph = graph;
        }

    }
}
