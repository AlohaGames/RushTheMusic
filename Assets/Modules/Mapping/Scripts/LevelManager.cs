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
        [SerializeField] public LevelMapping levelMapping;
        [SerializeField] public bool IsLoaded = false;

        public void Awake()
        {
            GlobalEvent.LoadLevel.AddListener((level, isTrue) => { Load(level, isTrue); });
        }

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
