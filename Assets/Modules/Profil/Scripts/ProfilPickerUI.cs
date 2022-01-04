using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha
{
    public class ProfilPickerUI : MonoBehaviour
    {
        public Profil profil;
        public Button startButton;
        public Button deleteButton;
        public MenuRoot MenuRoot;

        void Start()
        {
            startButton.GetComponentInChildren<Text>().text = profil.Name;

            startButton.onClick.AddListener(onStart);
            deleteButton.onClick.AddListener(onDelete);
        }

        private void onStart()
        {
            ProfilManager.Instance.CurrentProfil = profil;
            MenuRoot.ShowMainMenu();
            Debug.Log("Current profil is " + ProfilManager.Instance.CurrentProfil.Name);
        }

        private void onDelete() {
            Debug.Log("TODO Delete " + profil.Name);
            // TODO Delete the profil
        }
    }
}
