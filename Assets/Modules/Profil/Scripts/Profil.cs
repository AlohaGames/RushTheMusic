using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    public class Profil
    {
        public string Name;

        public Profil()
        {
            this.Name = "default-profil";
        }

        public Profil(string name)
        {
            this.Name = name;
        }
    }
}
