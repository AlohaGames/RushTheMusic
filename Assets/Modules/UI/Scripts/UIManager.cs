using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;

namespace Aloha
{
    public class UIManager : Singleton<UIManager>
    {
        public HorizontalBar horizontalBar;
        public VerticalBar verticalBar;
        // Start is called before the first frame update
        void Start()
        {
            horizontalBar.Init(GlobalEvent.OnHealthUpdate);
            verticalBar.Init(GlobalEvent.OnHealthUpdate2);
        }
    }
}

