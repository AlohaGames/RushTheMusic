using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.IO.Compression;
using Aloha.EntityStats;
using UnityEngine;
using UnityEngine.Networking;

namespace Aloha
{
    public class LevelManager : Singleton<LevelManager>
    {
        [SerializeField] private string Filename;
        public LevelMapping levelMapping;
        public AudioClip levelMusic;
        public bool IsLoaded = false;

        public void Init()
        {
            /*
            Stats enemyStats = ScriptableObject.CreateInstance<Stats>();
            enemyStats.attack = 10;
            enemyStats.defense = 10;
            enemyStats.maxHealth = 10;
            enemyStats.level = 2;

            EnemyMapping genericEnemy = new EnemyMapping(EnemyType.generic, enemyStats, VerticalPosition.BOT, HorizontalPosition.CENTER);

            List<EnemyMapping> tile10Enemies = new List<EnemyMapping>();
            tile10Enemies.Add(genericEnemy);

            SerializeDictionary<int, List<EnemyMapping>> enemies = new SerializeDictionary<int, List<EnemyMapping>>();
            enemies.Add(10, tile10Enemies);

            levelMapping = new LevelMapping(enemies, 80);

            // Save le level
            Save();

            // Reset
            levelMapping = null;
            */
        }

        public void Save(LevelMapping level, string filename, bool isTuto = false)
        {
            string basePath = isTuto ? Application.streamingAssetsPath + "/Levels" : Application.persistentDataPath;

            XmlSerializer serializer = new XmlSerializer(typeof(LevelMapping));
            using (FileStream stream = new FileStream($"{basePath}/{filename}", FileMode.Create))
            {
                serializer.Serialize(stream, level);
            }
        }

        public void Save()
        {
            this.Save(this.levelMapping, this.Filename);
        }

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
            Debug.Log($"Read {metadata.mappingFilePath}");
            XmlSerializer mappingSerializer = new XmlSerializer(typeof(LevelMapping));

            using (FileStream stream = new FileStream($"{workingPath}/{g}/{metadata.mappingFilePath}", FileMode.Open))
            {
                this.levelMapping = (LevelMapping)mappingSerializer.Deserialize(stream);
            }

            // Load AudioClip from mp3 file
            string musicFilePath = $"file://{workingPath}/{g}/{metadata.musicFilePath}";
            StartCoroutine(LoadMusic(musicFilePath, FinishLoad));
        }

        public void Load()
        {
            Load(this.Filename);
        }

        void FinishLoad()
        {
            this.IsLoaded = true;
            Debug.Log($"Load level finished");
        }

        IEnumerator LoadMusic(string musicFileURI, Action cb)
        {
            Debug.Log($"Loading music {musicFileURI}");
            using (UnityWebRequest web = UnityWebRequestMultimedia.GetAudioClip(musicFileURI, AudioType.MPEG))
            {
                yield return web.SendWebRequest();
                AudioClip clip = DownloadHandlerAudioClip.GetContent(web);
                if (clip != null)
                {
                    this.levelMusic = clip;
                    Debug.Log("AudioClip loaded !");
                }
            }
            cb();
        }
    }
}
