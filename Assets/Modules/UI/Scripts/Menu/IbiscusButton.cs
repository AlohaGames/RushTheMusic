using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha
{
    /// <summary>
    /// Manage the continue button in Game Over Menu
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class IbiscusButton : MonoBehaviour
    {

        /// <summary>
        /// Is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        {
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        /// <summary>
        /// Manage actions where button is clicked
        /// </summary>
        void OnClick()
        {
            SoundEffectManager.Instance.Play(
                SoundEffectManager.Instance.Sounds.click, this.gameObject
            );
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
