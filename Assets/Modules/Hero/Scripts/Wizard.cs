using UnityEngine;
using System.Collections;
using Aloha.Events;

namespace Aloha
{
    /// <summary>
    /// This class manage the wizard
    /// </summary>
    public class Wizard : Hero<WizardStats>
    {
        public int CurrentMana;

        /// <summary>
        /// Initialize the wizard
        /// <example> Example(s):
        /// <code>
        ///     wizard.Init();
        /// </code>
        /// </example>
        /// </summary>
        public override void Init()
        {
            this.Init(this.heroStats);
        }

        /// <summary>
        /// Initialize the wizard with stats
        /// <example> Example(s):
        /// <code>
        ///     wizard.Init(wizardStats);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="stats"></param>
        public void Init(WizardStats stats)
        {
            base.Init(stats);
            this.CurrentMana = this.heroStats.MaxMana;
            GlobalEvent.OnSecondaryUpdate.Invoke(this.CurrentMana, this.heroStats.MaxMana);
        }

        /// <summary>
        /// Is called on the frame when a script is enabled just before any of the Update methods are called the first time.
        /// </summary>
        void Start()
        {
            StartCoroutine(RegainManaOverTime());
        }

        /// <summary>
        /// Bump an entity
        /// <example> Example(s):
        /// <code>
        ///     wizard.BumpEntity(assassin);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="entity"></param>
        public void BumpEntity(Entity entity)
        {
            Vector3 direction = new Vector3(0, 0, 2);
            StartCoroutine(entity.GetBump(direction, 1));
        }

        /// <summary>
        /// Charge a fireball
        /// <example> Example(s):
        /// <code>
        ///     wizard.ChargeFireball
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>
        /// A int representing the power of fireball
        /// </returns>
        public int ChargeFireball()
        {
            int manaToUse = 200;
            int power = 0;

            if (this.CurrentMana >= manaToUse)
            {
                power = this.heroStats.Attack;
                this.CurrentMana -= manaToUse;
            }
            else if (((float)this.CurrentMana / manaToUse > 0.1f))
            {
                power = this.heroStats.Attack * this.CurrentMana / manaToUse;
                this.CurrentMana = 0;
            }
            GlobalEvent.OnSecondaryUpdate.Invoke(this.CurrentMana, this.heroStats.MaxMana);
            return power;
        }

        /// <summary>
        /// Charge a vortex
        /// <example> Example(s):
        /// <code>
        ///     wizard.ChargeVortex();
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>
        /// A int representing the mana used for the vortex
        /// </returns>
        public int ChargeVortex()
        {
            int manaToUse = 400;
            int manaUsed = 0;

            if (this.CurrentMana >= manaToUse)
            {
                manaUsed = manaToUse;
                this.CurrentMana -= manaToUse;
            }
            GlobalEvent.OnSecondaryUpdate.Invoke(this.CurrentMana, this.heroStats.MaxMana);
            return manaUsed;
        }

        /// <summary>
        /// Regain mana automatically during the game
        /// <example> Example(s):
        /// <code>
        ///     StartCoroutine(RegainManaOverTime());
        /// </code>
        /// </example>
        /// </summary>
        IEnumerator RegainManaOverTime()
        {
            while (true)
            {
                if (this.CurrentMana < this.heroStats.MaxMana) this.CurrentMana += 5;
                GlobalEvent.OnSecondaryUpdate.Invoke(this.CurrentMana, this.heroStats.MaxMana);
                yield return new WaitForSeconds(0.1f);
            }
        }

        /// <summary>
        /// Regenerates a pourcentage of the wizard's max mana.
        /// <example> Example(s):
        /// <code>
        ///     warrior.RegenerateSecondary();
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="secondaryRegen">A percentage of regeneration of the secondary bar</param>
        public override void RegenerateSecondary(float secondaryRegen)
        {
            int newMana = (int)(this.CurrentMana + this.heroStats.MaxMana * Mathf.Abs(secondaryRegen));
            this.CurrentMana = newMana.Clamp(0, this.heroStats.MaxMana);
            GlobalEvent.OnSecondaryUpdate.Invoke(this.CurrentMana, this.heroStats.MaxMana);
        }
    }
}
