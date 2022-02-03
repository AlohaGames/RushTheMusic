using UnityEngine;
using Aloha;

namespace Aloha.AI
{
    /// <summary>
    /// Graph use by Experion
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
            // Get experion Object
            experion = Runner.GetComponent<Experion>();

            // Create Nodes
            Node Quote = new ExperionQuote(this);
            Node GetBump = new BasicNode(this, 1);
            Node IceLaser = new ExperionIceAttack(this);
            Node FireLaser = new ExperionFireAttack(this);
            Node DashAttack = new ExperionDash(this);
            Node MoveForward = new MoveForward(this);
            Node TamponNearHero = new BasicNode(this);
            Node ExperionTeleportation = new ExperionTeleportation(this);
            ExperionMove MoveLeft = new ExperionMove(this);
            ExperionMove MoveRight = new ExperionMove(this);
            ExperionMove TeleportRightLeft = new ExperionMove(this);
            ExperionFireball FireballAttack = new ExperionFireball(this);
            ExperionFireball IceballAttack = new ExperionFireball(this);

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
            TamponNearHero.AddAutomaticLink(MoveLeft, 0.475f);
            TamponNearHero.AddAutomaticLink(MoveRight, 0.475f);
            TamponNearHero.AddAutomaticLink(Quote, 0.05f);

            // Add Link to MoveLeft
            MoveLeft.IsLeft = true;
            MoveLeft.AddAutomaticLink(MoveRight, 0.225f);
            MoveLeft.AddAutomaticLink(MoveLeft, 0.225f);
            MoveLeft.AddAutomaticLink(TeleportRightLeft, 0.20f);
            MoveLeft.AddAutomaticLink(IceLaser, 0.06f);
            MoveLeft.AddAutomaticLink(FireLaser, 0.06f);
            MoveLeft.AddAutomaticLink(FireballAttack, 0.06f);
            MoveLeft.AddAutomaticLink(IceballAttack, 0.06f);
            MoveLeft.AddAutomaticLink(DashAttack, 0.06f);
            MoveLeft.AddAutomaticLink(Quote, 0.05f);
            MoveLeft.AddEventLink(GetBump, experion.TakeDamageEvent);

            // Add Link to MoveRight
            MoveRight.AddAutomaticLink(MoveRight, 0.225f);
            MoveRight.AddAutomaticLink(MoveLeft, 0.225f);
            MoveRight.AddAutomaticLink(TeleportRightLeft, 0.20f);
            MoveRight.AddAutomaticLink(IceLaser, 0.06f);
            MoveRight.AddAutomaticLink(FireLaser, 0.06f);
            MoveRight.AddAutomaticLink(FireballAttack, 0.06f);
            MoveRight.AddAutomaticLink(IceballAttack, 0.06f);
            MoveRight.AddAutomaticLink(DashAttack, 0.06f);
            MoveRight.AddAutomaticLink(Quote, 0.05f);
            MoveRight.AddEventLink(GetBump, experion.TakeDamageEvent);

            // Add Link to TeleportRightLeft
            TeleportRightLeft.Teleport = true;
            TeleportRightLeft.AddAutomaticLink(TeleportRightLeft, 0.10f);
            TeleportRightLeft.AddAutomaticLink(IceLaser, 0.18f);
            TeleportRightLeft.AddAutomaticLink(FireLaser, 0.18f);
            TeleportRightLeft.AddAutomaticLink(FireballAttack, 0.18f);
            TeleportRightLeft.AddAutomaticLink(IceballAttack, 0.18f);
            TeleportRightLeft.AddAutomaticLink(DashAttack, 0.18f);
            TeleportRightLeft.AddEventLink(GetBump, experion.TakeDamageEvent);

            // Add Link to Ice Laser
            IceLaser.AddAutomaticLink(TamponNearHero, 1.0f);
            IceLaser.AddEventLink(GetBump, experion.TakeDamageEvent);

            // Add Link to Fire Laser
            FireLaser.AddAutomaticLink(TamponNearHero, 1.0f);
            FireLaser.AddEventLink(GetBump, experion.TakeDamageEvent);

            // Add Link to Fireball
            FireballAttack.AddAutomaticLink(TamponNearHero, 1.0f);
            FireballAttack.AddEventLink(GetBump, experion.TakeDamageEvent);

            // Add Link to Iceball
            FireballAttack.IsIce = true;
            IceballAttack.AddAutomaticLink(TamponNearHero, 1.0f);
            IceballAttack.AddEventLink(GetBump, experion.TakeDamageEvent);

            // Add Link to Dash
            DashAttack.AddAutomaticLink(TamponNearHero, 1.0f);
            DashAttack.AddEventLink(GetBump, experion.TakeDamageEvent);

            // Add Link to GetBump
            GetBump.AddAutomaticLink(MoveForward, 0.3f);
            GetBump.AddAutomaticLink(ExperionTeleportation, 0.7f);

            // Add link to Quote
            Quote.AddAutomaticLink(TamponNearHero, 1.0f);

            // Register Node in Graph
            Nodes.Add(MoveForward);
            Nodes.Add(ExperionTeleportation);
            Nodes.Add(TamponNearHero);
            Nodes.Add(MoveLeft);
            Nodes.Add(MoveRight);
            Nodes.Add(TeleportRightLeft);
            Nodes.Add(IceLaser);
            Nodes.Add(FireLaser);
            Nodes.Add(FireballAttack);
            Nodes.Add(IceballAttack);
            Nodes.Add(DashAttack);
            Nodes.Add(GetBump);
            Nodes.Add(Quote);
        }
    }
}
