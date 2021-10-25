using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;
using Aloha.Events;


namespace Aloha
{
    public class LevelManager : Singleton<LevelManager>
    {
        [SerializeField] private string Filename;
        public LevelMapping levelMapping;
        public bool IsLoaded = false;

        public void Awake() {
            GlobalEvent.LoadLevel.AddListener(Load);
        }

        public void Save(LevelMapping level, string filename, bool isTuto = false)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(LevelMapping));
            using (FileStream stream = new FileStream($"{Application.persistentDataPath}/{Filename}", FileMode.Create))
            {
                serializer.Serialize(stream, levelMapping);
            }
        }

        public void Save(LevelMapping level, bool isTuto = false)
        {
            Save(level, Filename, isTuto);
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
        }

        public void Load(bool isTuto = false) {
            Load(Filename, isTuto);
        }

        public void OnDestroy() {
            GlobalEvent.LoadLevel.RemoveListener(Load);
        }
    }
}
