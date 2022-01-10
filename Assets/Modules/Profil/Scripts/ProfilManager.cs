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

        /// <summary>
        /// Manager of user profils
        /// </summary>
        public ProfilManager()
        {
            this.profils = new List<Profil>();
        }

        /// <summary>
        /// Return the directory where profils are stored on local computer
        /// </summary>
        private string GetProfilDir()
        {
            // Linux : ~/.config/unity3d/AlohaGames/RushTheMusic/profils/
            return $"{Application.persistentDataPath}/profils";
        }

        /// <summary>
        /// Save current profile to disk
        /// </summary>
        public void SaveCurrentProfil()
        {
            SaveProfil(CurrentProfil);
        }

        /// <summary>
        /// Create a new profile
        /// </summary>
        public void CreateProfil(Profil profil)
        {
            this.CurrentProfil = profil;
            SaveCurrentProfil();
        }

        /// <summary>
        /// Save a profile to disk
        /// </summary>
        public void SaveProfil(Profil profil)
        {
            string profilFileName = $"{profil.Name}.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(Profil));
            using (FileStream stream = new FileStream($"{GetProfilDir()}/{profilFileName}", FileMode.Create))
            {
                serializer.Serialize(stream, profil);
            }
        }

        /// <summary>
        /// Delete a profile
        /// </summary>
        public void DeleteProfil(Profil profil)
        {
            string profilFileName = $"{profil.Name}.xml";
            string filePath = $"{GetProfilDir()}/{profilFileName}";

            // check if file exists
            if (!File.Exists(filePath))
            {
                Debug.Log( "no " + profilFileName + " profile exists" );
            }
            else
            {
                File.Delete(filePath);
            }

        }

        /// <summary>
        /// Load profile from disk
        /// </summary>
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

        /// <summary>
        /// Load all profiles from disk
        /// </summary>
        public void LoadProfiles()
        {
            // Clear list of profiles before load them
            this.profils = new List<Profil>();

            // Create profile dir if not exists
            Directory.CreateDirectory(GetProfilDir());

            // Read each profile files
            Debug.Log($"Loading files from {GetProfilDir()}");
            foreach (string file in Directory.EnumerateFiles(GetProfilDir(), "*.xml"))
            {
                Profil profil = LoadProfilFile(file);
                this.profils.Add(profil);
            }
        }

        /// <summary>
        /// Get current profil
        /// </summary>
        public Profil GetCurrentProfil()
        {
            return CurrentProfil;
        }

        /// <summary>
        /// Get all profils as a list
        /// </summary>
        public List<Profil> GetAllProfils()
        {
            return profils;
        }
    }
}
