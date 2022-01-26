using UnityEngine;
using Aloha;

namespace Aloha.AI
{
    /// <summary>
    /// Graph use by Wyrmling
    /// </summary>
    [CreateAssetMenu(fileName = "DarkWizard", menuName = "AI/DarkWizard", order = 0)]
    public class DarkWizardGraph : Graph
    {
        DarkWizard darkWizard;

        /// <summary>
        /// Call by GraphRunner to init the graph structure
        /// </summary>
        public override void Start()
        {
            // Get wyrmling Object
            darkWizard = Runner.GetComponent<DarkWizard>();

            // Create Nodes
            Node MoveForward = new MoveForward(this);
            Node TamponNearHero = new BasicNode(this);
            Move MoveLeft = new Move(this);
            Move MoveRight = new Move(this);
            Node IceLaser = new DarkWizardIceAttack(this);
            Node FireLaser = new DarkWizardFireAttack(this);
            Node GetBump = new BasicNode(this, 1);

            // Add Link to MoveForward
            MoveForward.AddAutomaticLink(MoveForward, 1.0f);
            MoveForward.AddEventLink(TamponNearHero, darkWizard.NearHeroTrigger);
            MoveForward.AddEventLink(GetBump, darkWizard.TakeDamageEvent);

            // Add Link to TamponNearHero
            TamponNearHero.AddAutomaticLink(MoveLeft, 0.5f);
            TamponNearHero.AddAutomaticLink(MoveRight, 0.5f);

            // Add Link to MoveLeft
            MoveLeft.IsLeft = true;
            MoveLeft.AddAutomaticLink(MoveRight, 0.35f);
            MoveLeft.AddAutomaticLink(MoveLeft, 0.35f);
            MoveLeft.AddAutomaticLink(IceLaser, 0.15f);
            MoveLeft.AddAutomaticLink(FireLaser, 0.15f);
            MoveLeft.AddEventLink(GetBump, darkWizard.TakeDamageEvent);

            // Add Link to MoveRight
            MoveRight.AddAutomaticLink(MoveLeft, 0.35f);
            MoveRight.AddAutomaticLink(MoveRight, 0.35f);
            MoveRight.AddAutomaticLink(IceLaser, 0.15f);
            MoveRight.AddAutomaticLink(FireLaser, 0.15f);
            MoveRight.AddEventLink(GetBump, darkWizard.TakeDamageEvent);

            // Add Link to Ice Laser
            IceLaser.AddAutomaticLink(TamponNearHero, 1.0f);
            IceLaser.AddEventLink(GetBump, darkWizard.TakeDamageEvent);

            // Add Link to Fire Laser
            FireLaser.AddAutomaticLink(TamponNearHero, 1.0f);
            FireLaser.AddEventLink(GetBump, darkWizard.TakeDamageEvent);

            // Add Link to GetBump
            GetBump.AddAutomaticLink(MoveForward, 1.0f);

            // Register Node in Graph
            Nodes.Add(MoveForward);
            Nodes.Add(TamponNearHero);
            Nodes.Add(MoveLeft);
            Nodes.Add(MoveRight);
            Nodes.Add(IceLaser);
            Nodes.Add(FireLaser);
            Nodes.Add(GetBump);
        }
    }
}
