using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;

namespace Aloha
{
    public class UIManager : Singleton<UIManager>
    {
        public HorizontalBar healthBar;
        public VerticalBar verticalHealthBa;
        // Start is called before the first frame update
        void Start()
        {
            healthBar.Init(GlobalEvent.OnHealthUpdate);
            verticalHealthBa.Init(GlobalEvent.OnHealthUpdate);
        }
    }
}

