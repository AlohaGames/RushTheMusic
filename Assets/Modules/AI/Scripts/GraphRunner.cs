using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Aloha.AI
{
    /// <summary>
    /// Runner of Graph
    /// </summary>
    public class GraphRunner : MonoBehaviour
    {
        private int currentNode;
        private IEnumerator currentCoroutine;

        [SerializeField]
        private bool isRunning = false;

        [SerializeField]
        private bool isAutomaticStart;

        public Graph BGraph;

        /// <summary>
        /// Call at the instantiation
        /// </summary>
        void Start()
        {
            if (BGraph)
            {
                BGraph = Instantiate(BGraph);
                BGraph.Runner = this;
                BGraph.Start();
                if (isAutomaticStart)
                {
                    StartGraph();
                }
            }
        }

        /// <summary>
        /// Start the Graph
        /// </summary>
        public void StartGraph()
        {
            isRunning = true;
            BGraph.Nodes[BGraph.EntryNode].IsRunning = isRunning;
            StartNodeAction();
        }

        /// <summary>
        /// Pause the graph
        /// </summary>
        public void Pause()
        {
            isRunning = false;
            BGraph.Nodes[currentNode].IsRunning = isRunning;
            StopCoroutine(currentCoroutine);
        }

        /// <summary>
        /// Resume the graph
        /// </summary>
        public void Resume()
        {
            isRunning = true;
            BGraph.Nodes[currentNode].IsRunning = isRunning;
            StartCoroutine(currentCoroutine);
        }

        /// <summary>
        /// Stop running the graph
        /// </summary>
        public void StopGraph()
        {
            isRunning = false;
            BGraph.Nodes[currentNode].IsRunning = isRunning;
            StopCoroutine(currentCoroutine);
        }

        /// <summary>
        /// Start the current Node Action
        /// </summary>
        void StartNodeAction()
        {
            if (BGraph.Nodes.Count > currentNode)
            {
                Debug.Log(BGraph.Nodes[currentNode]);
                currentCoroutine = BGraph.Nodes[currentNode].Action();
                StartCoroutine(currentCoroutine);
            }
        }

        /// <summary>
        /// Stop the current node Action
        /// </summary>
        void StopNodeAction()
        {
            StopCoroutine(currentCoroutine);
        }

        /// <summary>
        /// Define the new current node
        /// </summary>
        /// <param name="node">The new current Node</param>
        public void SetCurrentNode(Node node)
        {
            StopNodeAction();
            this.currentNode = BGraph.Nodes.IndexOf(node);
            StartNodeAction();
        }
    }
}
