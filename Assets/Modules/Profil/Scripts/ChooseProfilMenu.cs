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
        private GameObject noProfilUIPrefab;

        public void DisplayProfils()
        {
            List<Profil> profils = ProfilManager.Instance.GetAllProfils();

            HorizontalLayoutGroup layout = GetComponentInChildren<HorizontalLayoutGroup>();

            for (int i = 0; i < 3; i++)
            {
                if (profils.Count > i)
                {
                    ProfilPickerUI pmi = Instantiate(profilUIPrefab);
                    pmi.profil = profils[i];
                    pmi.transform.SetParent(layout.transform);
                }
                else
                {
                    GameObject noProfil = Instantiate(noProfilUIPrefab);
                    noProfil.transform.SetParent(layout.transform);
                }
            }
        }
    }
}
