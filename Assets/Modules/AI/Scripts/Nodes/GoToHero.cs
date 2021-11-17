using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha.AI
{
    public class GoToHero : GONode
    {
        public float speed = 2.0f;
        public float proximity = 5.0f;

        public GoToHero() : base() { }
        public GoToHero(Graph graph, float proximity = 5.0f) : base(graph)
        {
            this.proximity = proximity;
        }

        public override IEnumerator Action()
        {
            IsRunning = true;

            float time = 0;
            Vector3 posInit = gameObject.transform.position;
            Vector3 posFinal = GameManager.Instance.GetHero().gameObject.transform.position;

            float dist = Vector3.Distance(posInit, posFinal);
            float totalTime = dist / speed;

            while (time < totalTime)
            {
                time += speed * Time.deltaTime;
                gameObject.transform.position = Vector3.Lerp(posInit, posFinal, time / totalTime);
                yield return null;
            }

            gameObject.transform.position = posFinal;

            Debug.Log("Finish : " + AutomaticLinks.Count);
            yield return null;
            if (!AutomaticLinks.IsEmpty())
            {
                yield return TryAllLink();
            }
            IsRunning = false;
        }
    }
}
