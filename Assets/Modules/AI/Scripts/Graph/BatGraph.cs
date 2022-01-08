using UnityEngine;
using Aloha;

namespace Aloha.AI
{
    /// <summary>
    /// Graph use by bat
    /// </summary>
    [CreateAssetMenu(fileName = "Bat", menuName = "AI/Bat", order = 0)]
    public class BatGraph : Graph
    {
        Bat bat;

        /// <summary>
        /// Call by GraphRunner to init the graph structure
        /// </summary>
        public override void Start()
        {
            // Get wyrmling Object
            bat = Runner.GetComponent<Bat>();

            // Create Nodes
            Node MoveForward = new MoveForward(this);
            Node TamponNearHero = new BasicNode(this);
            BatMove Move = new BatMove(this);
            //Node Attack = new BatAttack(this);
            Node GetBump = new BasicNode(this, 1);

            // Add Link to MoveForward
            MoveForward.AddAutomaticLink(MoveForward, 1.0f);
            MoveForward.AddEventLink(TamponNearHero, bat.NearHeroTrigger);
            MoveForward.AddEventLink(GetBump, bat.TakeDamageEvent);

            // Add Link to TamponNearHero
            TamponNearHero.AddAutomaticLink(Move, 1.0f);

            // Add Link to Move
            Move.AddAutomaticLink(Move, 1.0f);
            //Move.AddAutomaticLink(Attack, 0.20f);
            Move.AddEventLink(GetBump, bat.TakeDamageEvent);

            // Add Link to Attack
            //Attack.AddAutomaticLink(TamponNearHero, 1.0f);
            //Attack.AddEventLink(GetBump, wyrmling.TakeDamageEvent);

            // Add Link to GetBump
            GetBump.AddAutomaticLink(MoveForward, 1.0f);

            // Register Node in Graph
            Nodes.Add(MoveForward);
            Nodes.Add(TamponNearHero);
            Nodes.Add(Move);
            //Nodes.Add(Attack);
            Nodes.Add(GetBump);
        }
    }
}
