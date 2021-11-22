using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha
{
    public class ProfilMenuItem : MonoBehaviour
    {
        public Profil profil;

        void Start() {
            Text name = GetComponentInChildren<Text>();
            name.text = profil.name;
        }
    }
}
