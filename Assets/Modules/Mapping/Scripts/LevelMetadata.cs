using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// TODO
    /// </summary>
    public class LevelMetadata
    {
        public string Author;
        public string LevelName;
        public string MusicFilePath;
        public string MappingFilePath;
        public string Description;

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        public LevelMetadata()
        {
            this.Author = "Unknown";
            this.LevelName = "Unknown";
            this.MusicFilePath = "music.mp3";
            this.MappingFilePath = "mapping.xml";
            this.Description = "Unknown";
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="author"></param>
        /// <param name="musicFilePath"></param>
        /// <param name="mappingFilePath"></param>
        /// <param name="levelName"></param>
        /// <param name="description"></param>
        public LevelMetadata(string author, string musicFilePath, string mappingFilePath, string levelName, string descrption)
        {
            this.Author = author;
            this.MusicFilePath = musicFilePath;
            this.MappingFilePath = mappingFilePath;
            this.LevelName = levelName;
            this.Description = descrption;
        }
    }
}
