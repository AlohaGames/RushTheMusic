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
            lancer = Runner.GetComponent<Lancer>();

            Node MoveForward = new MoveForward(this);
            Node TamponNearHero = new BasicNode(this);
            Move MoveLeft = new Move(this);
            Move MoveRight = new Move(this);
            Node Attack = new LancerAttack(this);
            Node GetBump = new BasicNode(this, 5);

            MoveRight.IsLeft = true;
            MoveForward.AddAutomaticLink(MoveForward, 1.0f);
            MoveForward.AddEventLink(TamponNearHero, lancer.NearHeroTrigger);
            MoveForward.AddEventLink(GetBump, lancer.TakeDamageEvent);

            TamponNearHero.AddAutomaticLink(MoveLeft, 0.5f);
            TamponNearHero.AddAutomaticLink(MoveRight, 0.5f);

            MoveLeft.AddAutomaticLink(MoveRight, 0.45f);
            MoveLeft.AddAutomaticLink(MoveLeft, 0.45f);
            MoveLeft.AddAutomaticLink(Attack, 0.02f);
            MoveLeft.AddEventLink(GetBump, lancer.TakeDamageEvent);

            MoveRight.AddAutomaticLink(MoveLeft, 0.45f);
            MoveRight.AddAutomaticLink(MoveRight, 0.45f);
            MoveRight.AddAutomaticLink(Attack, 0.10f);
            MoveRight.AddEventLink(GetBump, lancer.TakeDamageEvent);

            Attack.AddEventLink(GetBump, lancer.TakeDamageEvent);

            GetBump.AddAutomaticLink(MoveForward, 1.0f);

            Nodes.Add(MoveForward);
            Nodes.Add(TamponNearHero);
            Nodes.Add(MoveLeft);
            Nodes.Add(MoveRight);
            Nodes.Add(Attack);
            Nodes.Add(GetBump);
        }
    }
}
