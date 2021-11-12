using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Xml.Serialization;
using UnityEngine;

namespace Aloha
{
    public class ProfilManager : Singleton<ProfilManager>
    {
        private List<Profil> profils;
        private Profil currentProfil;

        public ProfilManager() {
            this.profils = new List<Profil>();
        }

        private string getProfilDir()
        {
            return $"{Application.persistentDataPath}/profils";
        }

        // Save current profil to disk
        public void SaveCurrentProfil()
        {
            string profilFileName = $"{currentProfil.name}.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(Profil));
            using (FileStream stream = new FileStream($"{getProfilDir()}/{profilFileName}", FileMode.Create))
            {
                serializer.Serialize(stream, currentProfil);
            }
        }

        // Load profile from xml file
        public Profil LoadProfilFile(string filename)
        {

            // TODO: Faire l'UI de la liste des profils chargés
            // TODO: Read profil from actual file
            
            Debug.Log(filename);
            return new Profil("TODO");
        }

        // Load all profils from disk
        public void LoadProfils()
        {
            // Create profil dir if not exists
            Directory.CreateDirectory(getProfilDir());

            // Read each profil files
            Debug.Log($"Loading files from {getProfilDir()}");
            foreach (string file in Directory.EnumerateFiles(getProfilDir(), "*.xml"))
            {
                Profil profil = LoadProfilFile(file);
                this.profils.Add(profil);
            }
        }

        public Profil GetCurrentProfil()
        {
            return currentProfil;
        }

        public List<Profil> GetAllProfils()
        {
            return profils;
        }
    }
}
