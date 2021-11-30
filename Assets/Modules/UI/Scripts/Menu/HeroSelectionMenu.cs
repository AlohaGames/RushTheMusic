using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Aloha.Events;

namespace Aloha
{
    /// <summary>
    /// TODO
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class HeroSelectionMenu : MonoBehaviour
    {
        public HeroType Type;

        /// <summary>
        /// Is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        {
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        /// <summary>
        /// TODO
        /// </summary>
        public void OnClick()
        {
            GlobalEvent.LoadHero.Invoke(Type);
            GameManager.Instance.StartLevel();
        }

        /// <summary>
        /// Is called when a Scene or game ends.
        /// </summary>
        void OnDestroy()
        {
            GetComponent<Button>().onClick.RemoveListener(OnClick);
        }
    }
}
