using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Aloha.EntityStats;

namespace Aloha
{
    public class Assassin : Enemy<AssassinStats> 
    {
        private Hero hero;

        private void Start()
        {
            hero = GameManager.Instance.GetHero();
        }
        protected override IEnumerator AI()
        {
            yield return StartCoroutine(Concentration(15f));
            yield return StartCoroutine(StealthJump(2f));
        }

        protected IEnumerator StealthJump(float speed)
        {

            float temps = 0;
            Vector3 posInit = gameObject.transform.position;
            Vector3 posFinal = posInit * speed;

            while (temps < 1f)
            {
                temps += speed * Time.deltaTime;
                posFinal.y = posInit.y + 15;
                posFinal.z = posInit.z - 7;
                gameObject.transform.position = Vector3.Lerp(posInit, posFinal, temps);
                yield return null;
            }

            gameObject.transform.position = posFinal;

            Hero hero = GameManager.Instance.GetHero();
            Attack(hero);
            Debug.Log(hero.currentHealth);

            Disappear();
        }

        protected IEnumerator Concentration(float speed)
        {
            yield return new WaitForSeconds(0.8f);
            float temps = 0;
            Vector3 posInit = gameObject.transform.position;
            Vector3 posFinal = posInit;
            posFinal.z = posFinal.z - 2.2f;
            Debug.Log(posInit);
            Debug.Log(posFinal);

            while (temps < 1f)
            {
                temps += speed * Time.deltaTime;
                gameObject.transform.position = Vector3.Lerp(posInit, posFinal, temps);
                yield return null;
            }
            gameObject.transform.position = posFinal;
            yield return new WaitForSeconds(0.15f);
        }

    }
}
