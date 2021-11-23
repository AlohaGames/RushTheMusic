using UnityEngine;
using Aloha;

namespace Aloha.AI
{
    [CreateAssetMenu(fileName = "Lancer", menuName = "AI/Lancer", order = 0)]
    public class LancerGraph : Graph
    {

        Lancer lancer;
        public override void Start()
        {
            lancer = Runner.GetComponent<Lancer>();

            Node GoToHero = new GoToHero(this);
            Node TamponNearHero = new BasicNode(this);
            Move MoveLeft = new Move(this);
            Move MoveRight = new Move(this);
            Node Attack = new LancerAttack(this);
            Node GetBump = new BasicNode(this, 5);

            MoveRight.IsLeft = true;
            GoToHero.AddAutomaticLink(GoToHero, 1.0f);
            GoToHero.AddEventLink(TamponNearHero, lancer.NearHeroTrigger);
            GoToHero.AddEventLink(GetBump, lancer.TakeDamageEvent);

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

            GetBump.AddAutomaticLink(GoToHero, 1.0f);

            Nodes.Add(GoToHero);
            Nodes.Add(TamponNearHero);
            Nodes.Add(MoveLeft);
            Nodes.Add(MoveRight);
            Nodes.Add(Attack);
            Nodes.Add(GetBump);
        }
    }
}
