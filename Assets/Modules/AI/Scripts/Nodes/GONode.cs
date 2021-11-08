using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha.AI
{
    public abstract class GONode : Node
    {
        protected GameObject gameObject;

        public GONode()
        {
            gameObject = Graph.gameObject;
        }

        public GONode(StateGraph graph) : base(graph)
        {
            gameObject = Graph.gameObject;
        }
    }
}
