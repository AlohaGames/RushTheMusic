using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.IO.Compression;
using UnityEngine;
using UnityEngine.Networking;
using Aloha.Events;

namespace Aloha
{
    /// <summary>
    /// Singleton that manage the level
    /// </summary>
    public class LevelManager : Singleton<LevelManager>
    {
        [SerializeField] 
        private string filename = "";

        public LevelMapping LevelMapping;
        public AudioClip LevelMusic;
        public bool IsLoaded = false;

        /// <summary>
        /// Is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        {
            GlobalEvent.LoadLevel.AddListener(Load);
        }

        /// <summary>
        /// Save a map with parameters
        /// <example> Example(s):
        /// <code>
        ///     LevelManager.Instance.Save(levelMapping, "Example", true);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="level"></param>
        /// <param name="filename"></param>
        /// <param name="isTuto"></param>
        public void Save(LevelMapping level, string filename, bool isTuto = false)
        {
            string basePath = isTuto ? Application.streamingAssetsPath + "/Levels" : Application.persistentDataPath;

            XmlSerializer serializer = new XmlSerializer(typeof(LevelMapping));
            using (FileStream stream = new FileStream($"{basePath}/{filename}", FileMode.Create))
            {
                serializer.Serialize(stream, level);
            }
        }

        /// <summary>
        /// Save a map 
        /// <example> Example(s):
        /// <code>
        /// LevelManager.Instance.Save();
        /// </code>
        /// </example>
        /// </summary>
        public void Save()
        {
            this.Save(this.LevelMapping, this.filename);
        }

        /// <summary>
        /// Load a map with parameters
        /// <example> Example(s):
        /// <code>
        ///     GlobalEvent.LoadLevel.AddListener(Load);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="isTutp"></param>
        public void Load(string filename, bool isTuto = false)
        {
            Debug.Log($"Load level {filename}");

            string basePath = isTuto ? Application.streamingAssetsPath + "/Levels" : Application.persistentDataPath;
            string workingPath = Application.temporaryCachePath;

            // Extract zip file
            Guid g = Guid.NewGuid();

            Debug.Log($"Extract level to {g}");
            ZipFile.ExtractToDirectory($"{basePath}/{filename}", $"{workingPath}/{g}");


            // Read metadata file
            Debug.Log($"Read metada.xml");
            LevelMetadata metadata;
            XmlSerializer metadataSerializer = new XmlSerializer(typeof(LevelMetadata));

            using (FileStream stream = new FileStream($"{workingPath}/{g}/metadata.xml", FileMode.Open))
            {
                metadata = (LevelMetadata)metadataSerializer.Deserialize(stream);
            }

            // Read mapping file
            Debug.Log($"Read {metadata.MappingFilePath}");
            XmlSerializer mappingSerializer = new XmlSerializer(typeof(LevelMapping));

            using (FileStream stream = new FileStream($"{workingPath}/{g}/{metadata.MappingFilePath}", FileMode.Open))
            {
                this.LevelMapping = (LevelMapping) mappingSerializer.Deserialize(stream);
                // TODO: Voir si possible de le load ailleur ?!
                SideEnvironmentManager.Instance.LoadBiome(LevelMapping.BiomeName);
            }

            // Load AudioClip from mp3 file
            string musicFilePath = $"file://{workingPath}/{g}/{metadata.MusicFilePath}";
            StartCoroutine(LoadMusic(musicFilePath, FinishLoad));
        }

        /// <summary>
        /// Load a map
        /// <example> Example(s):
        /// <code>
        ///     this.Load();
        /// </code>
        /// </example>
        /// </summary>
        public void Load()
        {
            Load(this.filename);
        }

        /// <summary>
        /// Called when load is finished
        /// <example> Example(s):
        /// <code>
        ///     StartCoroutine(LoadMusic(musicFilePath, FinishLoad));
        /// </code>
        /// </example>
        /// </summary>
        void FinishLoad()
        {
            this.IsLoaded = true;
            Debug.Log($"Load level finished");
        }

        /// <summary>
        /// Load a specific music and do an action
        /// <example> Example(s):
        /// <code>
        ///     StartCoroutine(LoadMusic(musicFilePath, FinishLoad));
        /// </code>
        /// </example>
        /// </summary>
        /// <param name=""></param>
        IEnumerator LoadMusic(string musicFileURI, Action cb)
        {
            Debug.Log($"Loading music {musicFileURI}");
            using (UnityWebRequest web = UnityWebRequestMultimedia.GetAudioClip(musicFileURI, AudioType.MPEG))
            {
                yield return web.SendWebRequest();
                AudioClip clip = DownloadHandlerAudioClip.GetContent(web);
                if (clip != null)
                {
                    this.LevelMusic = clip;
                    Debug.Log("AudioClip loaded !");
                }
            }
            cb();
        }

        /// <summary>
        /// Is called when a Scene or game ends.
        /// </summary>
        void OnDestroy()
        {
            GlobalEvent.LoadLevel.RemoveListener(Load);
        }
    }
}
