using UnityEngine;
using Aloha;

namespace Aloha.AI
{
    /// <summary>
    /// Graph use by Wyrmling
    /// </summary>
    [CreateAssetMenu(fileName = "Experion", menuName = "AI/Boss/Experion", order = 0)]
    public class ExperionGraph : Graph
    {
        Experion experion;

        /// <summary>
        /// Call by GraphRunner to init the graph structure
        /// </summary>
        public override void Start()
        {
            // Get wyrmling Object
            experion = Runner.GetComponent<Experion>();

            // Create Nodes
            Node MoveForward = new MoveForward(this);
            Node TamponNearHero = new BasicNode(this);
            WyrmlingMove MoveLeft = new WyrmlingMove(this);
            WyrmlingMove MoveRight = new WyrmlingMove(this);
            Node Attack = new WyrmlingAttack(this);
            Node GetBump = new BasicNode(this, 1);

            // Add Link to MoveForward
            MoveForward.AddAutomaticLink(MoveForward, 1.0f);
            MoveForward.AddEventLink(TamponNearHero, experion.NearHeroTrigger);
            MoveForward.AddEventLink(GetBump, experion.TakeDamageEvent);

            // Add Link to TamponNearHero
            TamponNearHero.AddAutomaticLink(MoveLeft, 0.5f);
            TamponNearHero.AddAutomaticLink(MoveRight, 0.5f);

            // Add Link to MoveLeft
            MoveLeft.IsLeft = true;
            MoveLeft.AddAutomaticLink(MoveRight, 0.40f);
            MoveLeft.AddAutomaticLink(MoveLeft, 0.40f);
            MoveLeft.AddAutomaticLink(Attack, 0.20f);
            MoveLeft.AddEventLink(GetBump, experion.TakeDamageEvent);

            // Add Link to MoveRight
            MoveRight.AddAutomaticLink(MoveLeft, 0.40f);
            MoveRight.AddAutomaticLink(MoveRight, 0.40f);
            MoveRight.AddAutomaticLink(Attack, 0.20f);
            MoveRight.AddEventLink(GetBump, experion.TakeDamageEvent);

            // Add Link to Attack
            Attack.AddAutomaticLink(TamponNearHero, 1.0f);
            Attack.AddEventLink(GetBump, experion.TakeDamageEvent);

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
