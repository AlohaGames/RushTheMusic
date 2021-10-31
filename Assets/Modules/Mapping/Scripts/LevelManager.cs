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
        public LevelMapping LevelMapping;
        public AudioClip LevelMusic;
        
        public bool IsLoaded = false;

        [SerializeField] 
        private string Filename = "";

        /// <summary>
        /// Is called when the script instance is being loaded.
        /// </summary>
        public void Awake()
        {
            GlobalEvent.LoadLevel.AddListener(Load);
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
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
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        public void Save()
        {
            this.Save(this.LevelMapping, this.Filename);
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
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
                this.LevelMapping = (LevelMapping)mappingSerializer.Deserialize(stream);
            }

            // Load AudioClip from mp3 file
            string musicFilePath = $"file://{workingPath}/{g}/{metadata.MusicFilePath}";
            StartCoroutine(LoadMusic(musicFilePath, FinishLoad));
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        public void Load()
        {
            Load(this.Filename);
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        void FinishLoad()
        {
            this.IsLoaded = true;
            Debug.Log($"Load level finished");
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <param name=""></param>
        /// <returns>
        /// TODO
        /// </returns>
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
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        public void OnDestroy()
        {
            GlobalEvent.LoadLevel.RemoveListener(Load);
        }
    }
}
