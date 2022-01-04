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

        // Save current profile to disk
        public void SaveCurrentProfil()
        {
            SaveProfil(CurrentProfil);
        }

        // Create a new profile
        public void CreateProfil(Profil profil)
        {
            this.CurrentProfil = profil;
            SaveCurrentProfil();
        }

        // Save a profile to disk
        public void SaveProfil(Profil profil)
        {
            string profilFileName = $"{profil.Name}.xml";
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
            Debug.Log($"Profil {profil.Name} loaded");
            return profil;
        }

        // Load all profiles from disk
        public void LoadProfiles()
        {
            // Clear list of profiles before load them
            this.profils = new List<Profil>();

            // Create profile dir if not exists
            Directory.CreateDirectory(getProfilDir());

            // Read each profile files
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
