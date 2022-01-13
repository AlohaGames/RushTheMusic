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
        public ChooseProfilMenu CPM;

        void Start()
        {
            Button create = GetComponentInChildren<Button>();
            create.onClick.AddListener(onCreate);
        }

        private void onCreate()
        {
            CPM.transform.GetChild(CPM.transform.childCount - 1).gameObject.SetActive(true);
        }

    }
}