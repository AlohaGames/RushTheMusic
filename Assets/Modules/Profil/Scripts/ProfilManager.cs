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
        /// TODO
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
        public ProfilManager()
        {
            this.profils = new List<Profil>();
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
        private string getProfilDir()
        {
            // Linux : ~/.config/unity3d/AlohaGames/RushTheMusic/profils/
            return $"{Application.persistentDataPath}/profils";
        }

        /// <summary>
        /// Save current profile to disk
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
        public void SaveCurrentProfil()
        {
            SaveProfil(CurrentProfil);
        }

        /// <summary>
        /// Create a new profile
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
        public void CreateProfil(Profil profil)
        {
            this.CurrentProfil = profil;
            SaveCurrentProfil();
        }

        /// <summary>
        /// Save a profile to disk
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
        public void SaveProfil(Profil profil)
        {
            string profilFileName = $"{profil.Name}.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(Profil));
            using (FileStream stream = new FileStream($"{getProfilDir()}/{profilFileName}", FileMode.Create))
            {
                serializer.Serialize(stream, profil);
            }
        }

        /// <summary>
        /// Delete a profile
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
        public void DeleteProfil(Profil profil)
        {
            string profilFileName = $"{profil.Name}.xml";
            string filePath = $"{getProfilDir()}/{profilFileName}";

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
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
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
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
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

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
        public Profil GetCurrentProfil()
        {
            return CurrentProfil;
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
        public List<Profil> GetAllProfils()
        {
            return profils;
        }
    }
}
