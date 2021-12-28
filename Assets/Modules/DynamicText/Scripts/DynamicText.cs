using System.Collections;
using UnityEngine;

namespace Aloha
{
    public class DynamicText : MonoBehaviour
    {

        private TextMesh tm;

        public float ActionTime = 1.0f;
        public float Speed = 1.0f;
        public float Distance = 5f;

        public void Trigger(string text, Color color)
        {
            tm = GetComponent<TextMesh>();
            tm.text = text;
            tm.color = color;
            StartCoroutine(Action());
        }

        public IEnumerator Action()
        {
            float time = 0;
            Vector3 posInit = gameObject.transform.position;
            Vector3 posFinal = posInit;
            posFinal.y = posFinal.y + Distance;

            while (time < ActionTime)
            {
                time += Speed * Time.deltaTime;
                gameObject.transform.position = Vector3.Lerp(posInit, posFinal, time / ActionTime);
                yield return null;
            }

            gameObject.transform.position = posFinal;
            yield return null;

            Destroy(gameObject);
        }
    }
}
