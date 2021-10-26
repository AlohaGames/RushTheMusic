using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;

namespace Aloha
{
    public class HealthBar : HorizontalBar
    {
        public void Awake()
        {
            GlobalEvent.OnHealthUpdate.AddListener(UpdateBar);
        }

        public void OnDestroy()
        {
            GlobalEvent.OnHealthUpdate.RemoveListener(UpdateBar);
        }
    }
}
