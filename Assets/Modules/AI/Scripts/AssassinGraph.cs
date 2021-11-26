using UnityEngine;
using Aloha;

namespace Aloha.AI
{
    /// <summary>
    /// Graph use by Assassin
    /// </summary>
    [CreateAssetMenu(fileName = "Assassin", menuName = "AI/Assassin", order = 0)]
    public class AssassinGraph : Graph
    {
        Assassin assassin;

        /// <summary>
        /// Call by GraphRunner to init the graph structure
        /// </summary>
        public override void Start()
        {
            // Get assassin Object
            assassin = Runner.GetComponent<Assassin>();

            // Create Nodes
            Node GetBump = new BasicNode(this, 4);
            Node MoveForward = new MoveForward(this);
            Node TamponNearHero = new BasicNode(this);
            Node Attack = new AssassinAttack(this);
            Node Concentration = new AssassinConcentration(this);

            // Add Link to MoveForward
            MoveForward.AddAutomaticLink(MoveForward, 1.0f);
            MoveForward.AddEventLink(TamponNearHero, assassin.NearHeroTrigger);
            MoveForward.AddEventLink(GetBump, assassin.TakeDamageEvent);

            // Add Link to TamponNearHero
            TamponNearHero.AddAutomaticLink(Concentration, 1.0f);

            // Add Link to Concentration
            Concentration.AddAutomaticLink(Attack, 1.0f);
            Concentration.AddEventLink(GetBump, assassin.TakeDamageEvent);

            // Add Link to GetBump
            GetBump.AddAutomaticLink(MoveForward, 1.0f);

            // Register Node in Graph
            Nodes.Add(MoveForward);
            Nodes.Add(TamponNearHero);
            Nodes.Add(Attack);
            Nodes.Add(GetBump);
            Nodes.Add(Concentration);
        }
    }
}
