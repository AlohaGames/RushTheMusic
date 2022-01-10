using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Aloha.Events;

namespace Aloha
{
    public class InfiniteModeNextLevelButton : MonoBehaviour
    {
        void Awake()
        {
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        /// <summary>
        /// Called when the user click on the button
        /// <example> Example(s):
        /// <code>
        ///     GetComponent<Button>().onClick.AddListener(OnClick);
        /// </code>
        /// </example>
        /// </summary>
        public void OnClick()
        {
            ScoreManager.Instance.FinishLevelReset();
            LevelManager.Instance.LoadRandomLevel(onFinishLoad);
        }

        public void onFinishLoad()
        {
            GameManager.Instance.StartLevel();
            UIManager.Instance.HideEndGameUIElements();
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
