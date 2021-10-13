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

        /// <summary>
        /// Invoke when click on a button and will pass the string <paramref name="level" /> and the bool <paramref name="isTuto" />
        /// </summary>
        /// <param name="level">The level to load</param>
        /// <param name="isTuto">Is it a Tuto Level</param>
        public static StringBoolEvent onLoadEvent = new StringBoolEvent();

        public void Awake()
        {
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        public void OnClick()
        {
            onLoadEvent.Invoke(level, isTuto);
        }
    }
}
