using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Aloha.AI
{
    /// <summary>
    /// Abstract Link class
    /// </summary>
    public abstract class Link
    {
        public Node From;
        public Node To;

        /// <summary>
        /// Make the link between 'From' node and 'To' node
        /// </summary>
        public void PathToNext()
        {
            if (From.IsRunning)
            {
                From.IsRunning = false;
            }
            To.Graph.SetCurrentNode(To);
        }
    }

    /// <summary>
    /// AutomaticLink can be crossed with a define probability
    /// </summary>
    public class AutomaticLink : Link
    {
        public float Probability = 1.0f;

        public AutomaticLink() : this(1.0f) { }

        public AutomaticLink(float probability)
        {
            Probability = probability;
        }

        /// <summary>
        /// Try to path throw this link with a random value
        /// </summary>
        /// <param name="random">A random value between 0 and 1 that will be compare to the probality</param>
        /// <returns>True if the link pass, false otherwise</returns>
        public bool TryLink(float random)
        {
            if (random <= Probability)
            {
                PathToNext();
                return true;
            }
            return false;
        }
    }

    /// <summary>
    /// EventLink can be crossed when a specific Event is raise
    /// </summary>
    public class EventLink : Link
    {
        public UnityEvent TriggerEvent = null;

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public EventLink() : this(null) { }

        /// <summary>
        /// Constructor of EventLink
        /// </summary>
        /// <param name="triggerEvent">UnityEvent that pass to the Node</param>
        public EventLink(UnityEvent triggerEvent)
        {
            TriggerEvent = triggerEvent;
            TriggerEvent?.AddListener(PathToNext);
        }

        /// <summary>
        /// Destructor of EventLink
        /// </summary>
        ~EventLink()
        {
            TriggerEvent?.RemoveListener(PathToNext);
        }
    }
}
