using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Aloha.Events;

namespace Aloha
{
    /// <summary>
    /// Class for the hero invoker button
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class HeroInvokerButton : MonoBehaviour
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
        /// Called when user click on the button
        /// <example> Example(s):
        /// <code>
        ///     GetComponent<Button>().onClick.AddListener(OnClick);
        /// </code>
        /// </example>
        /// </summary>
        public void OnClick()
        {
            GlobalEvent.LoadHero.Invoke(Type);
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
