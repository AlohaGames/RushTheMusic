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

        public virtual void PathToNext()
        {
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

        public override void PathToNext()
        {
            Debug.Log("Path from : " + from + " to : " + to +"\nbecause of : " + this.probability);
            base.PathToNext();
        }

        public bool TryLink(float random)
        {
            if (random <= probability)
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

        public override void PathToNext()
        {
            Debug.Log("Path from : " + from + " to : " + to +"\nbecause of : " + this.triggerEvent);
            base.PathToNext();
        }

        ~EventLink()
        {
            triggerEvent?.RemoveListener(PathToNext);
        }
    }
}
