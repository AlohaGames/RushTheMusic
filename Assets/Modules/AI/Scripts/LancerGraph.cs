using UnityEngine;
using Aloha;

namespace Aloha.AI
{
    public class LancerGraph : StateGraph {

        Lancer lancer;
        void Start() {
            lancer = GetComponent<Lancer>();

            Move MoveLeft = new Move(this);
            Move MoveRight = new Move(this);
            Node Attack = new LancerAttack(this);
            Node Tampon = new BasicNode(this);

            MoveRight.IsLeft = true;
            
            MoveLeft.AddAutomaticLink(MoveRight, 0.5f);
            MoveLeft.AddAutomaticLink(MoveLeft, 0.5f);
            MoveLeft.AddAutomaticLink(Attack, 0.01f);
            MoveLeft.AddEventLink(Tampon, lancer.TakeDamageEvent);

            MoveRight.AddAutomaticLink(MoveLeft, 0.5f);
            MoveRight.AddAutomaticLink(MoveRight, 0.5f);
            MoveRight.AddAutomaticLink(Attack, 0.1f);
            MoveRight.AddEventLink(Tampon, lancer.TakeDamageEvent);

            Attack.AddEventLink(Tampon, lancer.TakeDamageEvent);

            Tampon.AddAutomaticLink(MoveLeft, 0.5f);
            Tampon.AddAutomaticLink(MoveRight, 0.5f);

            Nodes.Add(MoveLeft);
            Nodes.Add(MoveRight);
            Nodes.Add(Attack);
            Nodes.Add(Tampon);
        }
    }
}
