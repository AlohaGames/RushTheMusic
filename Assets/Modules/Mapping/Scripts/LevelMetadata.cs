using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    public class LevelMetadata
    {
        public string author;
        public string levelName;
        public string musicFilePath;
        public string mappingFilePath;

        public LevelMetadata()
        {
            this.author = "Unknown";
            this.levelName = "Unknown";
            this.musicFilePath = "music.mp3";
            this.mappingFilePath = "mapping.xml";
        }

        public LevelMetadata(string author, string musicFilePath, string mappingFilePath, string levelName)
        {
            this.author = author;
            this.musicFilePath = musicFilePath;
            this.mappingFilePath = mappingFilePath;
            this.levelName = levelName;
        }
    }
}
