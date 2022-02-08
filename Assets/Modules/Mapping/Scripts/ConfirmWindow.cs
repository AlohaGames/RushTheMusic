using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha
{
    /// <summary>
    /// Confirm Window class
    /// </summary>
    public class ConfirmWindow : MonoBehaviour
    {
        [SerializeField]
        Button confirm;

        [SerializeField]
        Button cancel;

        private void Awake()
        {
            confirm.onClick.AddListener(() => { this.gameObject.SetActive(false); });
            cancel.onClick.AddListener(() => { this.gameObject.SetActive(false); });
        }

        /// <summary>
        /// Define confirm callback
        /// </summary>
        /// <param name="cb">Action to call when confirm</param>
        public void SetCallback(Action cb)
        {
            confirm.onClick.AddListener(() => { cb(); });
        }
    }
}
