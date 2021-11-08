using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Aloha.AI
{
    public class Link
    {
        public Node from;
        public Node to;

        public void PathToNext()
        {
            Debug.Log("Path from : " + from + " to : " + to);
            if (from.IsRunning)
            {
                from.IsRunning = false;
            }
            to.Graph.SetCurrentNode(to);
        }
    }

    public class AutomaticLink : Link
    {
        public float probability = 1.0f;

        public AutomaticLink() : this(1.0f) { }

        public AutomaticLink(float probability)
        {
            this.probability = probability;
        }

        public bool TryLink()
        {
            if (Utils.RandomFloat() <= probability)
            {
                PathToNext();
                return true;
            }
            return false;
        }
    }

    public class EventLink : Link
    {
        public UnityEvent triggerEvent = null;
        public EventLink() : this(null) { }

        public EventLink(UnityEvent triggerEvent)
        {
            this.triggerEvent = triggerEvent;
            triggerEvent?.AddListener(PathToNext);
        }

        ~EventLink()
        {
            triggerEvent?.RemoveListener(PathToNext);
        }
    }
}
