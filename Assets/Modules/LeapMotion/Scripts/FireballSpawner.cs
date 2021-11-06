using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha 
{
    public class FireballSpawner : MonoBehaviour
    {
        public Wizard wizard;
        [SerializeField] private Fireball fireballPrefab;
        private Fireball currentFireball;

        private void Start()
        {
            // TODO Change this
            //wizard = GameManager.Instance.GetHero() as Wizard;
            wizard = FindObjectOfType<Wizard>();
        }

        public void SpawnFireball()
        {
            if (!this.currentFireball)
            {
                Vector3 fireballPos = transform.localPosition;
                fireballPos.z -= 0.05f;
                Fireball fireball = Instantiate(fireballPrefab, Vector3.zero, Quaternion.identity);
                fireball.transform.parent = transform;
                fireball.transform.localPosition = fireballPos;
                fireball.wizard = this.wizard;
                this.currentFireball = fireball;
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