using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// Class for level metadatas
    /// </summary>
    public class LevelMetadata
    {
        public string Author;
        public string LevelName;
        public string MusicFilePath;
        public string MappingFilePath;

        /// <summary>
        /// Default constructor
        /// <example> Example(s):
        /// <code>
        ///     LevelMetadata lm = new LevelMetadata();
        /// </code>
        /// </example>
        /// </summary>
        public LevelMetadata()
        {
            this.Author = "Unknown";
            this.LevelName = "Unknown";
            this.MusicFilePath = "music.mp3";
            this.MappingFilePath = "mapping.xml";
        }

        /// <summary>
        /// Constructor with parameters
        /// <example> Example(s):
        /// <code>
        ///     LevelMetadata lm = new LevelMetadata("Youen", "myPath", "mappingPath"; "Tuto1");
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="author"></param>
        /// <param name="musicFilePath"></param>
        /// <param name="mappingFilePath"></param>
        /// <param name="levelName"></param>
        public LevelMetadata(string author, string musicFilePath, string mappingFilePath, string levelName)
        {
            this.Author = author;
            this.MusicFilePath = musicFilePath;
            this.MappingFilePath = mappingFilePath;
            this.LevelName = levelName;
        }
    }
}
