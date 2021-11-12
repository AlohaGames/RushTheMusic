using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha 
{
    /// <summary>
    /// TODO
    /// </summary>
    public class FireballSpawner : MonoBehaviour
    {
        [SerializeField] 
        private Fireball fireballPrefab;

        private Fireball currentFireball;
        public Wizard Wizard;

        /// <summary>
        /// Is called on the frame when a script is enabled just before any of the Update methods are called the first time.
        /// </summary>
        void Start()
        {
            Wizard = GameManager.Instance.GetHero() as Wizard;
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
        public void SpawnFireball()
        {
            if (!this.currentFireball)
            {
                int fireballPower = Wizard.ChargeFireball();

                if (fireballPower != 0)
                {
                    Vector3 fireballPos = transform.localPosition;
                    fireballPos.z -= 0.05f;

                    Fireball fireball = Instantiate(fireballPrefab, Vector3.zero, Quaternion.identity);

                    fireball.transform.parent = transform;
                    fireball.transform.localPosition = fireballPos;
                    if (fireballPower != Wizard.GetStats().Attack)
                    {
                        float size = (float) fireballPower / Wizard.GetStats().Attack;
                        Vector3 defaultScale = fireball.transform.localScale;
                        fireball.transform.localScale = new Vector3(defaultScale.x * size, defaultScale.y * size, defaultScale.z * size);
                    }
                    fireball.Wizard = this.Wizard;
                    fireball.Power = fireballPower;
                    this.currentFireball = fireball;
                }
            }
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
        public void SendFireball()
        {
            if (this.currentFireball)
            {
                this.currentFireball.Launch();
                this.currentFireball = null;
            }
        }
    }
}
