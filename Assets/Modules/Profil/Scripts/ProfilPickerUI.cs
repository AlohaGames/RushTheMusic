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

            startButton.onClick.AddListener(OnStart);
            deleteButton.onClick.AddListener(OnDelete);
        }

        private void OnStart()
        {
            ProfilManager.Instance.CurrentProfil = profil;
            MenuRoot.ShowMainMenu();
            Debug.Log("Current profil is " + ProfilManager.Instance.CurrentProfil.Name);
        }

        private void OnDelete() {
            Debug.Log("Delete " + profil.Name);
            ProfilManager.Instance.DeleteProfil(profil);
            MenuRoot.ShowProfilMenu();
        }
    }
}
