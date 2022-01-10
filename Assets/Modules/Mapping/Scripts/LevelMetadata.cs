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
        public string Description;
        public bool IsTuto;

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
            this.Description = "Unknown";
            this.IsTuto = false;
        }

        /// <summary>
        /// Constructor with parameters
        /// <example> Example(s):
        /// <code>
        ///     LevelMetadata lm = new LevelMetadata("Youen", "myPath", "mappingPath"; "Tuto1");
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="author">Author of the map</param>
        /// <param name="musicFilePath">Path to access to the music</param>
        /// <param name="mappingFilePath">Path to access to the level mapping</param>
        /// <param name="levelName">Name of the level</param>
        /// <param name="description">Description of the level</param>
        /// <param name="isTuto">Define if the level is a tuturial created by @AlohaGames. If true, the level is readOnly</param>
        public LevelMetadata(string author, string musicFilePath, string mappingFilePath, string levelName, string description, bool isTuto)
        {
            this.Author = author;
            this.MusicFilePath = musicFilePath;
            this.MappingFilePath = mappingFilePath;
            this.LevelName = levelName;
            this.Description = description;
            this.IsTuto = isTuto;
        }
    }
}
