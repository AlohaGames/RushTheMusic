using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Aloha.Events;
using Aloha.Hero;

namespace Aloha
{
    public class LevelLoaderButton : MonoBehaviour
    {
        [SerializeField]
        private bool isTuto = false;
        public string level;

        public void Awake()
        {
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        public void OnClick()
        {
            GlobalEvent.LoadLevel.Invoke(level, isTuto);
        }
    }
}
