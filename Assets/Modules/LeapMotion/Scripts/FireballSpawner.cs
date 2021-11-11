using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha 
{
    public class FireballSpawner : MonoBehaviour
    {
        public Wizard Wizard;
        [SerializeField] private Fireball fireballPrefab;
        private Fireball currentFireball;

        private void Start()
        {
            Wizard = GameManager.Instance.GetHero() as Wizard;
        }

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
                    if (fireballPower != Wizard.GetStats().attack)
                    {
                        float size = (float) fireballPower / Wizard.GetStats().attack;
                        Vector3 defaultScale = fireball.transform.localScale;
                        fireball.transform.localScale = new Vector3(defaultScale.x * size, defaultScale.y * size, defaultScale.z * size);
                    }
                    fireball.Wizard = this.Wizard;
                    fireball.Power = fireballPower;
                    this.currentFireball = fireball;
                }
            }
        }

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