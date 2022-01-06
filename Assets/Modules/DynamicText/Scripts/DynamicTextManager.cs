using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    public class DynamicTextCall
    {
        public DynamicText Dt;

        public Color DtColor;

        public string DtMessage;

        // 0 = HIGHT PRIORITY
        // Meaning it will be displayed first
        // 10 = LAST PRIORITY
        // Meaning it will be displayed last
        public int DtPriority;

        /// <summary>
        /// Object to pass to the manager to instanciate a dynamic text when possible
        /// </summary>
        public DynamicTextCall(DynamicText Dt, Color DtColor, string DtMessage, int DtPriority)
        {
            this.Dt = Dt;
            this.DtColor = DtColor;
            this.DtMessage = DtMessage;
            this.DtPriority = Utils.Clamp(DtPriority, 0, 10);
        }
    }

    public class DynamicTextManager : Singleton<DynamicTextManager>
    {

        public DynamicText dynamicTextPrefab;
        public Dictionary<string, List<DynamicTextCall>> queues = new Dictionary<string, List<DynamicTextCall>>();

        void Update()
        {
            foreach (KeyValuePair<string, List<DynamicTextCall>> entry in queues)
            {
                if (entry.Value.Count > 0)
                {
                    List<DynamicTextCall> queue = entry.Value;
                    DynamicTextCall firstTextCall = queue[0];

                    // Never run
                    if (!firstTextCall.Dt.Running && !firstTextCall.Dt.HasRun)
                    {
                        firstTextCall.Dt.Trigger(firstTextCall.DtMessage, firstTextCall.DtColor);
                    }
                    // Finish run
                    else if (!firstTextCall.Dt.Running && firstTextCall.Dt.HasRun)
                    {
                        queue.RemoveAt(0);
                    }
                }
            }
        }

        /// <summary>
        /// Ask the manager to create a dynamic text near the specified game object and as soon as possible.
        /// A priority can also be passed to define what text should be rendered first
        /// </summary>
        public void Show(GameObject gameObject, string message, Color color, int priority = 2)
        {
            if(dynamicTextPrefab == null) return;
            
            string key = gameObject.GetInstanceID().ToString();
            DynamicText dt = Instantiate(dynamicTextPrefab);
            dt.transform.position = gameObject.transform.position;

            // Init queue of does not exists 
            if (!queues.ContainsKey(key))
            {
                queues.Add(key, new List<DynamicTextCall>());
            }

            // Add dt to queue
            List<DynamicTextCall> queue = queues[key];
            queue.Add(new DynamicTextCall(dt, color, message, priority));

            // Reorder list based on priority
            queue.Sort(delegate (DynamicTextCall a, DynamicTextCall b)
            {
                return a.DtPriority > b.DtPriority ? 1 : -1;
            });
        }
    }
}
