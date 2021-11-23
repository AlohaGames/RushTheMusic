using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha.AI
{
    public class GoToHero : GONode
    {
        public float proximity = 5.0f;

        public GoToHero() : base() { }
        public GoToHero(Graph graph, float proximity = 5.0f) : base(graph)
        {
            this.proximity = proximity;
        }

        public override IEnumerator Action()
        {
            IsRunning = true;

            //time += speed * Time.deltaTime;
            //gameObject.transform.position = Vector3.Lerp(posInit, posFinal, time / totalTime);
            gameObject.transform.Translate(Vector3.forward * TilesManager.Instance.TileSpeed * Time.deltaTime);
            yield return null;

            if (!AutomaticLinks.IsEmpty())
            {
                TryAllLink();
            }
            IsRunning = false;
        }
    }
}
