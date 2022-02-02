using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha
{
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
        public void SetCallback(Action cb)
        {
            confirm.onClick.AddListener(() => { cb(); });
        }
    }
}
