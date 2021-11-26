using UnityEngine;
using Aloha;

namespace Aloha.AI
{
    /// <summary>
    /// Graph use by Lancer
    /// </summary>
    [CreateAssetMenu(fileName = "Lancer", menuName = "AI/Lancer", order = 0)]
    public class LancerGraph : Graph
    {
        Lancer lancer;

        /// <summary>
        /// Call by GraphRunner to init the graph structure
        /// </summary>
        public override void Start()
        {
            // Get lancer Object
            lancer = Runner.GetComponent<Lancer>();

            // Create Nodes
            Node MoveForward = new MoveForward(this);
            Node TamponNearHero = new BasicNode(this);
            Move MoveLeft = new Move(this);
            Move MoveRight = new Move(this);
            Node Attack = new LancerAttack(this);
            Node GetBump = new BasicNode(this, 5);

            // Add Link to MoveForward
            MoveForward.AddAutomaticLink(MoveForward, 1.0f);
            MoveForward.AddEventLink(TamponNearHero, lancer.NearHeroTrigger);
            MoveForward.AddEventLink(GetBump, lancer.TakeDamageEvent);

            // Add Link to TamponNearHero
            TamponNearHero.AddAutomaticLink(MoveLeft, 0.5f);
            TamponNearHero.AddAutomaticLink(MoveRight, 0.5f);

            // Add Link to MoveLeft
            MoveLeft.AddAutomaticLink(MoveRight, 0.45f);
            MoveLeft.AddAutomaticLink(MoveLeft, 0.45f);
            MoveLeft.AddAutomaticLink(Attack, 0.02f);
            MoveLeft.AddEventLink(GetBump, lancer.TakeDamageEvent);

            // Add Link to MoveRight
            MoveRight.IsLeft = true;
            MoveRight.AddAutomaticLink(MoveLeft, 0.45f);
            MoveRight.AddAutomaticLink(MoveRight, 0.45f);
            MoveRight.AddAutomaticLink(Attack, 0.10f);
            MoveRight.AddEventLink(GetBump, lancer.TakeDamageEvent);

            // Add Link to Attack
            Attack.AddEventLink(GetBump, lancer.TakeDamageEvent);

            // Add Link to GetBump
            GetBump.AddAutomaticLink(MoveForward, 1.0f);

            // Register Node in Graph
            Nodes.Add(MoveForward);
            Nodes.Add(TamponNearHero);
            Nodes.Add(MoveLeft);
            Nodes.Add(MoveRight);
            Nodes.Add(Attack);
            Nodes.Add(GetBump);
        }
    }
}
