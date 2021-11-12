using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha.AI
{
    public class Move : GONode
    {
        public bool IsLeft = false;
        public float actionTime = 1.0f;
        public float speed = 2.0f;
        public float distToMove = 0.5f;

        public Move() : base() { }
        public Move(Graph graph) : base(graph) { }

        public override IEnumerator Action()
        {
            IsRunning = true;

            float time = 0;
            Vector3 posInit = gameObject.transform.position;
            Vector3 posFinal = posInit;
            posFinal.x = IsLeft ? posFinal.x + distToMove : posFinal.x - distToMove;

            while (time < actionTime)
            {
                time += speed * Time.deltaTime;
                gameObject.transform.position = Vector3.Lerp(posInit, posFinal, time/actionTime);
                yield return null;
            }

            gameObject.transform.position = posFinal;
            
            yield return null;
            if (!AutomaticLinks.IsEmpty())
            {
                yield return TryAllLink();
            }
            IsRunning = false;
        }
    }
}
