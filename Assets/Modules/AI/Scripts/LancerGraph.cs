using UnityEngine;
using Aloha;

namespace Aloha.AI
{
    public class LancerGraph : StateGraph {

        Lancer lancer;
        void Start() {
            lancer = GetComponent<Lancer>();

            Node GoToHero = new GoToHero(this);
            Node TamponNearHero = new BasicNode(this);
            Move MoveLeft = new Move(this);
            Move MoveRight = new Move(this);
            Node Attack = new LancerAttack(this);
            Node Tampon = new BasicNode(this);

            MoveRight.IsLeft = true;

            GoToHero.AddEventLink(TamponNearHero, lancer.NearHeroTrigger);

            TamponNearHero.AddAutomaticLink(MoveLeft, 0.5f);
            TamponNearHero.AddAutomaticLink(MoveRight, 0.5f);

            MoveLeft.AddAutomaticLink(MoveRight, 0.49f);
            MoveLeft.AddAutomaticLink(MoveLeft, 0.49f);
            MoveLeft.AddAutomaticLink(Attack, 0.02f);
            MoveLeft.AddEventLink(Tampon, lancer.TakeDamageEvent);

            MoveRight.AddAutomaticLink(MoveLeft, 0.49f);
            MoveRight.AddAutomaticLink(MoveRight, 0.49f);
            MoveRight.AddAutomaticLink(Attack, 0.02f);
            MoveRight.AddEventLink(Tampon, lancer.TakeDamageEvent);

            Attack.AddEventLink(Tampon, lancer.TakeDamageEvent);

            Tampon.AddAutomaticLink(GoToHero, 1.0f);

            Nodes.Add(GoToHero);
            Nodes.Add(TamponNearHero);
            Nodes.Add(MoveLeft);
            Nodes.Add(MoveRight);
            Nodes.Add(Attack);
            Nodes.Add(Tampon);
        }
    }
}
