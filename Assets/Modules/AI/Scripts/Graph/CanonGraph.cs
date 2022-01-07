using UnityEngine;
using Aloha;

namespace Aloha.AI
{
    /// <summary>
    /// Graph use by Wyrmling
    /// </summary>
    [CreateAssetMenu(fileName = "Canon", menuName = "AI/Canon", order = 0)]
    public class CanonGraph : Graph
    {
        Canon canon;

        /// <summary>
        /// Call by GraphRunner to init the graph structure
        /// </summary>
        public override void Start()
        {
            // Get wyrmling Object
            canon = Runner.GetComponent<Canon>();

            // Create Nodes
            Node MoveForward = new MoveForward(this);
            Node Attack = new CanonAttack(this);

            // Add Link to MoveForward
            MoveForward.AddAutomaticLink(MoveForward, 1.0f);
            MoveForward.AddEventLink(Attack, canon.AttackAvailableEvent);

            // Add Link to Attack
            Attack.AddAutomaticLink(MoveForward, 1.0f);

            // Register Node in Graph
            Nodes.Add(MoveForward);
            Nodes.Add(Attack);
        }
    }
}
