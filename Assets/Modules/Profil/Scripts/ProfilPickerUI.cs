using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha
{
    public class ProfilPickerUI : MonoBehaviour
    {
        public Profil profil;

        void Start()
        {
            Text name = GetComponentInChildren<Text>();
            name.text = profil.name;

            Button[] buttons = GetComponentsInChildren<Button>();
            Button start = buttons[0];
            Button delete  = buttons[1];
            start.onClick.AddListener(onStart);
            delete.onClick.AddListener(onDelete);
        }

        private void onStart()
        {
            ProfilManager.Instance.CurrentProfil = profil;
            Debug.Log("Current profil is " + ProfilManager.Instance.CurrentProfil.name);
        }

        private void onDelete() {
            Debug.Log("Delete " + profil.name);
        }
    }
}
