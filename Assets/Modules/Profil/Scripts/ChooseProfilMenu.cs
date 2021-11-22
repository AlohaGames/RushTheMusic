using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Aloha
{
    public class ChooseProfilMenu : UIBehaviour
    {

        [SerializeField] private ProfilMenuItem profilMenuItemPrefab;

        public void DisplayProfils()
        {
            List<Profil> profils = ProfilManager.Instance.GetAllProfils();

            VerticalLayoutGroup layout = GetComponent<VerticalLayoutGroup>();

            foreach(Profil profil in profils) {
                ProfilMenuItem pmi = Instantiate(profilMenuItemPrefab);
                pmi.profil = profil;
                pmi.transform.SetParent(layout.transform);
            }
        }
    }
}
