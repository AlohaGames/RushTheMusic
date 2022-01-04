using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Aloha
{
    public class ChooseProfilMenu : UIBehaviour
    {

        [SerializeField]
        private ProfilPickerUI profilUIPrefab;

        [SerializeField]
        private NoProfilPickerUI noProfilUIPrefab;

        public GridLayoutGroup profilesGridLayout;
        public MenuRoot MenuRoot;

        protected override void Awake()
        {
            DisplayProfils();
        }

        public void ClearProfiles()
        {
            foreach (Transform child in profilesGridLayout.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }

        public void DisplayProfils()
        {
            ProfilManager.Instance.LoadProfiles();
            this.ClearProfiles();

            List<Profil> profils = ProfilManager.Instance.GetAllProfils();

            for (int i = 0; i < 3; i++)
            {
                if (profils.Count > i)
                {
                    ProfilPickerUI pmi = Instantiate(profilUIPrefab);
                    pmi.profil = profils[i];
                    pmi.MenuRoot = MenuRoot;
                    pmi.transform.SetParent(profilesGridLayout.transform);
                    pmi.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                }
                else
                {
                    NoProfilPickerUI noProfil = Instantiate(noProfilUIPrefab);
                    noProfil.MenuRoot = MenuRoot;
                    noProfil.transform.SetParent(profilesGridLayout.transform);
                    noProfil.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                }
            }
        }
    }
}
