    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha
{
    public class NoProfilPickerUI : MonoBehaviour
    {
        public MenuRoot MenuRoot;

        [HideInInspector]
        public ChooseProfilMenu cpm;

        void Start()
        {
            Button create = GetComponentInChildren<Button>();
            create.onClick.AddListener(onCreate);
        }

        private void onCreate()
        {
            cpm.transform.GetChild(cpm.transform.childCount - 1).gameObject.SetActive(true);
        }

    }
}