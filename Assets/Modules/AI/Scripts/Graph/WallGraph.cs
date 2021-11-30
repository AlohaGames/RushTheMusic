using UnityEngine;
using Aloha;

namespace Aloha.AI
{
    /// <summary>
    /// Graph use by Wall
    /// </summary>
    [CreateAssetMenu(fileName = "Wall", menuName = "AI/Wall", order = 0)]
    public class WallGraph : Graph
    {
        /// <summary>
        /// Call by GraphRunner to init the graph structure
        /// </summary>
        public override void Start()
        {
            // Create Nodes
            Node MoveForward = new MoveForward(this);

            // Add Link to MoveForward
            MoveForward.AddAutomaticLink(MoveForward, 1.0f);

            // Register Node in Graph
            Nodes.Add(MoveForward);
        }
    }
}
