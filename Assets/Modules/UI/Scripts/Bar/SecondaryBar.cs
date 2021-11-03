using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;

namespace Aloha
{
    public class SecondaryBar : HorizontalBar
    {
        public new void Awake()
        {
            base.Awake();
            GlobalEvent.OnSecondaryUpdate.AddListener(UpdateBar);
        }

        public void OnDestroy()
        {
            GlobalEvent.OnSecondaryUpdate.RemoveListener(UpdateBar);
        }
    }
}
