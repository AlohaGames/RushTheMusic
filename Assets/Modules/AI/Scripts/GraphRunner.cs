using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Aloha.AI
{
    public class GraphRunner : MonoBehaviour
    {
        public Graph BGraph;
        public IEnumerator currentCoroutine = null;

        int currentNode;

        [SerializeField]
        private bool isRunning = false;

        private void Start() {
            BGraph = Instantiate(BGraph);
            BGraph.Runner = this;
            BGraph.Start();
        }

        public void StartGraph()
        {
            isRunning = true;
            BGraph.Nodes[BGraph.EntryNode].IsRunning = isRunning;
            StartNodeAction();
        }

        public void Pause()
        {
            isRunning = false;
            BGraph.Nodes[currentNode].IsRunning = isRunning;
            StopCoroutine(currentCoroutine);
        }

        public void Resume()
        {
            isRunning = true;
            BGraph.Nodes[currentNode].IsRunning = isRunning;
            StartCoroutine(currentCoroutine);
        }

        public void StopGraph()
        {
            isRunning = false;
            BGraph.Nodes[currentNode].IsRunning = isRunning;
            StopCoroutine(currentCoroutine);
        }

        private void StartNodeAction()
        {
            currentCoroutine = BGraph.Nodes[currentNode].Action();
            StartCoroutine(currentCoroutine);
        }

        private void StopNodeAction()
        {
            StopCoroutine(currentCoroutine);
        }

        public void SetCurrentNode(Node node)
        {
            StopNodeAction();
            this.currentNode = BGraph.Nodes.IndexOf(node);
            StartNodeAction();
        }
    }
}
