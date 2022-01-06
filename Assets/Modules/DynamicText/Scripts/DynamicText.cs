using System.Collections;
using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// Class reprensting a dynamic text that pop up above and entity
    /// and disapear after few secondes going up
    /// </summary>
    public class DynamicText : MonoBehaviour
    {
        private TextMesh tm;
        public bool HasRun = false;
        public bool Running = false;
        public float RunningTime = 0.3f;
        public float ActionTime = 1.0f;
        public float Speed = 1.0f;
        public float Distance = 5f;

        /// <summary>
        /// Customize the dynamic text and run it
        /// </summary>
        public void Trigger(string text, Color color)
        {
            tm = GetComponent<TextMesh>();
            tm.text = text;
            tm.color = color;
            StartCoroutine(Action());
        }

        /// <summary>
        /// Run the dynamic text
        /// </summary>
        public IEnumerator Action()
        {
            Running = true;
            float time = 0;
            Vector3 posInit = gameObject.transform.position;
            Vector3 posFinal = posInit;
            posFinal.y = posFinal.y + Distance;

            while (time < ActionTime)
            {
                if (time > RunningTime)
                {
                    Running = false;
                    HasRun = true;
                }

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
