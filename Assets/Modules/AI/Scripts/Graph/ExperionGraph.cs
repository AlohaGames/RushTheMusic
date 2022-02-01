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
            Node ExperionTeleportation = new ExperionTeleportation(this);
            Node TamponNearHero = new BasicNode(this);
            ExperionMove MoveLeft = new ExperionMove(this);
            ExperionMove MoveRight = new ExperionMove(this);
            Node IceLaser = new ExperionIceAttack(this);
            Node FireLaser = new ExperionFireAttack(this);
            Node GetBump = new BasicNode(this, 1);

            // Add Link to MoveForward
            MoveForward.AddAutomaticLink(MoveForward, 0.995f);
            MoveForward.AddAutomaticLink(ExperionTeleportation, 0.005f);
            MoveForward.AddEventLink(TamponNearHero, experion.NearHeroTrigger);
            MoveForward.AddEventLink(GetBump, experion.TakeDamageEvent);

            // Add Link to ExperionTeleportation
            ExperionTeleportation.AddAutomaticLink(MoveForward, 0.995f);
            ExperionTeleportation.AddAutomaticLink(ExperionTeleportation, 0.005f);
            ExperionTeleportation.AddEventLink(TamponNearHero, experion.NearHeroTrigger);
            ExperionTeleportation.AddEventLink(GetBump, experion.TakeDamageEvent);

            // Add Link to TamponNearHero
            TamponNearHero.AddAutomaticLink(MoveLeft, 0.5f);
            TamponNearHero.AddAutomaticLink(MoveRight, 0.5f);

            // Add Link to MoveLeft
            MoveLeft.IsLeft = true;
            MoveLeft.AddAutomaticLink(MoveRight, 0.35f);
            MoveLeft.AddAutomaticLink(MoveLeft, 0.35f);
            MoveLeft.AddAutomaticLink(IceLaser, 0.15f);
            MoveLeft.AddAutomaticLink(FireLaser, 0.15f);
            MoveLeft.AddEventLink(GetBump, experion.TakeDamageEvent);

            // Add Link to MoveRight
            MoveRight.AddAutomaticLink(MoveLeft, 0.35f);
            MoveRight.AddAutomaticLink(MoveRight, 0.35f);
            MoveRight.AddAutomaticLink(IceLaser, 0.15f);
            MoveRight.AddAutomaticLink(FireLaser, 0.15f);
            MoveRight.AddEventLink(GetBump, experion.TakeDamageEvent);

            // Add Link to Ice Laser
            IceLaser.AddAutomaticLink(TamponNearHero, 1.0f);
            IceLaser.AddEventLink(GetBump, experion.TakeDamageEvent);

            // Add Link to Fire Laser
            FireLaser.AddAutomaticLink(TamponNearHero, 1.0f);
            FireLaser.AddEventLink(GetBump, experion.TakeDamageEvent);

            // Add Link to GetBump
            GetBump.AddAutomaticLink(MoveForward, 1.0f);
            //GetBump.AddAutomaticLink(Attack, 0.2f);

            // Register Node in Graph
            Nodes.Add(MoveForward);
            Nodes.Add(ExperionTeleportation);
            Nodes.Add(TamponNearHero);
            Nodes.Add(MoveLeft);
            Nodes.Add(MoveRight);
            Nodes.Add(IceLaser);
            Nodes.Add(FireLaser);
            Nodes.Add(GetBump);
        }
    }
}
