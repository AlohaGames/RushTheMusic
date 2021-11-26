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
        public Profil CurrentProfil;

        public ProfilManager()
        {
            this.profils = new List<Profil>();
        }

        private string getProfilDir()
        {
            return $"{Application.persistentDataPath}/profils";
        }

        // Save current profil to disk
        public void SaveCurrentProfil()
        {
            SaveProfil(CurrentProfil);
        }

        // Save a profil to disk
        public void SaveProfil(Profil profil)
        {
            string profilFileName = $"{profil.name}.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(Profil));
            using (FileStream stream = new FileStream($"{getProfilDir()}/{profilFileName}", FileMode.Create))
            {
                serializer.Serialize(stream, profil);
            }
        }

        // Load profile from disk
        public Profil LoadProfilFile(string filepath)
        {
            Profil profil;
            XmlSerializer metadataSerializer = new XmlSerializer(typeof(Profil));
            using (FileStream stream = new FileStream(filepath, FileMode.Open))
            {
                profil = (Profil)metadataSerializer.Deserialize(stream);
            }
            Debug.Log($"Profil {profil.name} loaded");
            return profil;
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
            return CurrentProfil;
        }

        public List<Profil> GetAllProfils()
        {
            return profils;
        }
    }
}
