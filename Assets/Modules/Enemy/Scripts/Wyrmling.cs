using System.Collections;
using UnityEngine;
using Aloha.EntityStats;

namespace Aloha
{
    public class Wyrmling : Enemy<WyrmlingStats>
    {
        [SerializeField] private WyrmlingFireball fireballPrefab;
        private float initialY;

        private void Start()
        {
            initialY = transform.position.y;
        }

        protected override IEnumerator AI()
        {
            while (true)
            {
                int rand = Utils.RandomInt(2, 4);
                for (int i = 0; i < rand; i++)
                {
                    yield return StartCoroutine(MoveXToAnimation(Utils.RandomFloat(-1.5f, 1.5f), 1));
                }
                yield return StartCoroutine(AttackAnimation());
            }
        }

        protected override IEnumerator MoveXToAnimation(float x, float speed)
        {
            float temps = 0;
            Vector3 posInit = gameObject.transform.position;
            Vector3 posFinal = posInit;
            posFinal.x = x;

            while (temps < 1f)
            {
                temps += speed * Time.deltaTime;
                posFinal.y = initialY + Mathf.Sin( Mathf.PI * gameObject.transform.position.x) * 0.1f;
                gameObject.transform.position = Vector3.Lerp(posInit, posFinal, temps);
                yield return null;
            }

            gameObject.transform.position = posFinal;
        }

        protected IEnumerator AttackAnimation()
        {
            // Config fireball's spawning position
            Vector3 fireballPos = transform.position;
            fireballPos.y += 0.3f;
            fireballPos.z -= 1f;

            // Spawn fireball
            WyrmlingFireball fireball = Instantiate(fireballPrefab, fireballPos, Quaternion.identity);
            fireball.associatedEnemy = this;
            yield return new WaitForSeconds(1f);

            // Launch fireball to the hero
            // TODO To change to this
            //Hero hero = GameManager.Instance.GetHero();
            Hero hero = FindObjectOfType<Warrior>();
            Vector3 dir = hero.transform.position - fireball.transform.position;
            dir.Normalize();
            fireball.GetComponent<Rigidbody>().AddForce(dir * 3, ForceMode.Impulse);
            
            yield return null;
        }

    }
}
