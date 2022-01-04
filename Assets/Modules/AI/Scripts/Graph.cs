using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha.AI
{
    /// <summary>
    /// Behaviour Graph that manage AI behaviour
    /// </summary>
    public class Graph : ScriptableObject
    {
        public GraphRunner Runner;
        public List<Node> Nodes = new List<Node>();
        public int EntryNode = 0;

        /// <summary>
        /// Method call during GraphRunner Start()
        /// </summary>
        public virtual void Start() { }

        /// <summary>
        /// Start Running the graph
        /// </summary>
        public void StartGraph()
        {
            Runner.StartGraph();
        }

        /// <summary>
        /// Pause the execution of Graph
        /// </summary>
        public void Pause()
        {
            Runner.Pause();
        }

        /// <summary>
        /// Resume the execution
        /// </summary>
        public void Resume()
        {
            Runner.Resume();
        }

        /// <summary>
        /// Stop the Graph
        /// </summary>
        public void StopGraph()
        {
            Runner.StopGraph();
        }

        /// <summary>
        /// Define the current running node
        /// </summary>
        /// <param name="node">The new node to run</param>
        public void SetCurrentNode(Node node)
        {
            Runner.SetCurrentNode(node);
        }

    }
}
