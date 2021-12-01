using UnityEngine;
using Aloha;

namespace Aloha.AI
{
    /// <summary>
    /// Graph use by Wyrmling
    /// </summary>
    [CreateAssetMenu(fileName = "Wyrmling", menuName = "AI/Wyrmling", order = 0)]
    public class WyrmlingGraph : Graph
    {
        Wyrmling wyrmling;

        /// <summary>
        /// Call by GraphRunner to init the graph structure
        /// </summary>
        public override void Start()
        {
            // Get wyrmling Object
            wyrmling = Runner.GetComponent<Wyrmling>();

            // Create Nodes
            Node MoveForward = new MoveForward(this);
            Node TamponNearHero = new BasicNode(this);
            WyrmlingMove MoveLeft = new WyrmlingMove(this);
            WyrmlingMove MoveRight = new WyrmlingMove(this);
            Node Attack = new WyrmlingAttack(this);
            Node GetBump = new BasicNode(this, 1);

            // Add Link to MoveForward
            MoveForward.AddAutomaticLink(MoveForward, 1.0f);
            MoveForward.AddEventLink(TamponNearHero, wyrmling.NearHeroTrigger);
            MoveForward.AddEventLink(GetBump, wyrmling.TakeDamageEvent);

            // Add Link to TamponNearHero
            TamponNearHero.AddAutomaticLink(MoveLeft, 0.5f);
            TamponNearHero.AddAutomaticLink(MoveRight, 0.5f);

            // Add Link to MoveLeft
            MoveLeft.IsLeft = true;
            MoveLeft.AddAutomaticLink(MoveRight, 0.45f);
            MoveLeft.AddAutomaticLink(MoveLeft, 0.45f);
            MoveLeft.AddAutomaticLink(Attack, 0.10f);
            MoveLeft.AddEventLink(GetBump, wyrmling.TakeDamageEvent);

            // Add Link to MoveRight
            MoveRight.AddAutomaticLink(MoveLeft, 0.45f);
            MoveRight.AddAutomaticLink(MoveRight, 0.45f);
            MoveRight.AddAutomaticLink(Attack, 0.10f);
            MoveRight.AddEventLink(GetBump, wyrmling.TakeDamageEvent);

            // Add Link to Attack
            Attack.AddAutomaticLink(TamponNearHero, 1.0f);
            Attack.AddEventLink(GetBump, wyrmling.TakeDamageEvent);

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
