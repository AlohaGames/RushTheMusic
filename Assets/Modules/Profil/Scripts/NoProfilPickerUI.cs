using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha
{
    public class NoProfilPickerUI : MonoBehaviour
    {
        public MenuRoot MenuRoot;

        void Start()
        {
            Button create = GetComponentInChildren<Button>();
            create.onClick.AddListener(onCreate);
        }

        private void onCreate()
        {
            this.transform.parent.transform.parent.GetChild(1).gameObject.SetActive(true);
        }

    }
}