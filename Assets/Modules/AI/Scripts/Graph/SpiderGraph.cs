using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Aloha.AI
{
    /// <summary>
    /// Graph use by Spider
    /// </summary>
    [CreateAssetMenu(fileName = "Spider", menuName = "AI/Spider", order = 0)]

    public class SpiderGraph : Graph
    {
        Spider spider;

        /// <summary>
        /// Call by GraphRunner to init the graph structure
        /// </summary>
        public override void Start()
        {
            // Get spider Object
            spider = Runner.GetComponent<Spider>();

            // Create Nodes
            Node GetBump = new BasicNode(this, 1);
            Node MoveForward = new MoveForward(this);
            Node Attack = new CanonAttack(this);

            // Add Link to MoveForward
            MoveForward.AddAutomaticLink(MoveForward, 1.0f);
            MoveForward.AddEventLink(GetBump, spider.TakeDamageEvent);

            // Add Link to Attack
            Attack.AddAutomaticLink(MoveForward, 1.0f);

            // Add Link to GetBump
            GetBump.AddAutomaticLink(MoveForward, 1.0f);

            // Register Node in Graph
            Nodes.Add(MoveForward);
            Nodes.Add(GetBump);
            Nodes.Add(Attack);
        }


    }
}
