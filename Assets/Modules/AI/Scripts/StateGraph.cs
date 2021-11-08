using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Aloha.AI
{
    public class StateGraph : MonoBehaviour
    {
        public IEnumerator currentCoroutine = null;
        public List<Node> Nodes = new List<Node>();

        public Graph BehaviorGraph;

        public int EntryNode = 0;
        int currentNode;

        [SerializeField]
        private bool isRunning = false;

        public void StartGraph()
        {
            isRunning = true;
            Nodes[currentNode].IsRunning = isRunning;
            StartNodeAction();
        }

        public void Pause()
        {
            isRunning = false;
            Nodes[currentNode].IsRunning = isRunning;
            StopCoroutine(currentCoroutine);
        }

        public void Resume()
        {
            isRunning = true;
            Nodes[currentNode].IsRunning = isRunning;
            StartCoroutine(currentCoroutine);
        }

        public void StopGraph()
        {
            isRunning = false;
            Nodes[currentNode].IsRunning = isRunning;
            StopCoroutine(currentCoroutine);
        }

        private void StartNodeAction()
        {
            currentCoroutine = Nodes[currentNode].Action();
            StartCoroutine(currentCoroutine);
        }

        private void StopNodeAction()
        {
            StopCoroutine(currentCoroutine);
        }

        public void SetCurrentNode(Node node)
        {
            StopNodeAction();
            this.currentNode = Nodes.IndexOf(node);
            StartNodeAction();
        }
    }
}
