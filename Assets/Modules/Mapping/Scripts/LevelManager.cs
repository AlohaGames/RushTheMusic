using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using Aloha.EntityStats;
using Aloha.Events;
using UnityEngine;


namespace Aloha
{
    public class LevelManager : Singleton<LevelManager>
    {
        [SerializeField] private string Filename;
        [SerializeField] public LevelMapping levelMapping = new LevelMapping();
        [SerializeField] public bool IsLoaded = false;

        public void Awake()
        {
            GlobalEvent.LoadLevel.AddListener((level, isTrue) => { Load(level, isTrue); });
        }

        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(LevelMapping));
            using (FileStream stream = new FileStream($"{Application.persistentDataPath}/{Filename}", FileMode.Create))
            {
                serializer.Serialize(stream, levelMapping);
            }
        }

        public void Load(string filename, bool isTuto = false)
        {
            Debug.Log($"Load level {filename} in {this} of Id {this.GetInstanceID()}");

            XmlSerializer serializer = new XmlSerializer(typeof(LevelMapping));

            if (!isTuto)
            {
                using (FileStream stream = new FileStream($"{Application.persistentDataPath}/{filename}", FileMode.Open))
                {
                    this.levelMapping = (LevelMapping)serializer.Deserialize(stream);
                    this.IsLoaded = true;
                }
            }
            else
            {
                using (FileStream stream = new FileStream($"{Application.streamingAssetsPath}/Levels/{filename}", FileMode.Open))
                {
                    this.levelMapping = (LevelMapping)serializer.Deserialize(stream);
                    this.IsLoaded = true;
                }
            }
            Debug.Log($"Load level finished : {this.levelMapping}");
            Debug.Log($"Number of ennemy on tile 10 : {this.levelMapping.getEnnemies(10).Count}");
        }

        public void Load(bool isTuto = false)
        {
            Load(Filename, isTuto);
        }
    }
}
