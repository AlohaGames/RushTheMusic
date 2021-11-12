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
            gameObject = Graph.Runner.gameObject;
        }

        public GONode(Graph graph) : base(graph)
        {
            gameObject = Graph.Runner.gameObject;
        }
    }
}
