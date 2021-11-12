using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Aloha.AI
{
    public class Graph : ScriptableObject
    {
        public GraphRunner Runner;

        public List<Node> Nodes = new List<Node>();

        public int EntryNode = 0;

        public virtual void Start() {

        }

        public void StartGraph()
        {
            Runner.StartGraph();
        }

        public void Pause()
        {
            Runner.Pause();
        }

        public void Resume()
        {
            Runner.Resume();
        }

        public void StopGraph()
        {
            Runner.StopGraph();
        }

        public void SetCurrentNode(Node node)
        {
            Runner.SetCurrentNode(node);
        }

    }
}
