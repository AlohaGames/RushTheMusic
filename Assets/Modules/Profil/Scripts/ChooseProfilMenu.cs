using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha
{
    public class ChooseProfilMenu : MonoBehaviour
    {

        public void DisplayProfils()
        {
            List<Profil> profils = ProfilManager.Instance.GetAllProfils();

            VerticalLayoutGroup verticalLayout = GetComponent<VerticalLayoutGroup>();

            Debug.Log(profils);

            // TODO: Ajouter l'UI du profil dans verticalLayout
        }
    }
}
