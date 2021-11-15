using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;

namespace Aloha
{
    public class ProgressionBar : VerticalBar
    {
        public new void Awake()
        {
            base.Awake();
            GlobalEvent.OnProgressionUpdate.AddListener(UpdateBar);
        }

        public void OnDestroy()
        {
            GlobalEvent.OnProgressionUpdate.RemoveListener(UpdateBar);
        }
    }
}
