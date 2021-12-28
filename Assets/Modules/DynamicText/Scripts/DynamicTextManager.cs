using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    public class DynamicTextManager : Singleton<DynamicTextManager>
    {

        public DynamicText dynamicTextPrefab;

        public void Show(Vector3 position, string message, Color color)
        {
            DynamicText dt = Instantiate(dynamicTextPrefab);
            dt.transform.position = position;
            dt.Trigger(message, color);
        }
    }
}