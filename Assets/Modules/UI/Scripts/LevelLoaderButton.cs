using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Aloha.Events;

namespace Aloha
{
    [RequireComponent(typeof(Button))]
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
            GameManager.Instance.LoadLevel(level, isTuto);
        }

        public void OnDestroy() {
            GetComponent<Button>().onClick.RemoveListener(OnClick);
        }
    }
}
