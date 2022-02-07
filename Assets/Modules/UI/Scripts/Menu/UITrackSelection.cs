using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.IO;
using System.IO.Compression;
using System.Xml.Serialization;

namespace Aloha
{
    /// <summary>
    /// Manage the track selection UI
    /// </summary>
    public class UITrackSelection : MonoBehaviour
    {
        [SerializeField]
        private GameObject trackElementPrefab;

        public GameObject TrackSelectionUI;
        public MenuRoot MenuRoot;

        void Awake()
        {
            ShowTrackList();
        }

        /// <summary>
        /// Get the list of tracks 
        /// <example> Example(s):
        /// <code>
        ///     GetTrackList()
        /// </code>
        /// </example>
        /// </summary>
        public FileInfo[] GetTracksInDir()
        {
            DirectoryInfo dir = new DirectoryInfo(Application.streamingAssetsPath + "/Levels");
            FileInfo[] info = dir.GetFiles("*.rtm");
            return info;
        }

        public LevelMetadata GetTrackInfo(FileInfo pathFile)
        {
            string workingPath = Application.temporaryCachePath;

            // Extract zip file
            Guid g = Guid.NewGuid();

            Debug.Log($"Extract level to {g}");
            ZipFile.ExtractToDirectory($"{pathFile}", $"{workingPath}/{g}");

            // Read metadata file
            Debug.Log($"Read metada.xml");
            LevelMetadata metadata;
            XmlSerializer metadataSerializer = new XmlSerializer(typeof(LevelMetadata));

            using (FileStream stream = new FileStream($"{workingPath}/{g}/metadata.xml", FileMode.Open))
            {
                metadata = (LevelMetadata) metadataSerializer.Deserialize(stream);
            }
            return metadata;
        }

        /// <summary>
        /// Display track list UI
        /// <example> Example(s):
        /// <code>
        ///     GetTrackList()
        /// </code>
        /// </example>
        /// </summary>
        public void ShowTrackList()
        {
            FileInfo[] files = GetTracksInDir();
            int trackNumber = files.Length;

            foreach (FileInfo dir in files)
            {
                // Get track info from metadata
                LevelMetadata metadata = GetTrackInfo(dir);

                // Instantiate 
                GameObject trackElement = Instantiate(trackElementPrefab);
                trackElement.transform.SetParent(TrackSelectionUI.transform);
                trackElement.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

                // Description of the track
                trackElement.transform.Find("MapName").GetComponent<Text>().text = metadata.LevelName;
                trackElement.transform.Find("MapDescription").GetComponent<Text>().text = metadata.Description;

                // Button of the track
                LevelLoaderButton button = trackElement.GetComponent<LevelLoaderButton>();
                button.Level = dir.Name;
                button.IsTuto = true;
                button.MenuRoot = MenuRoot;

                // Edit Button
                Button buttonEdit = button.Edit;
                buttonEdit?.onClick.AddListener(() =>
                {
                    LevelManager.Instance.URLToLoad = "" + dir;
                });
                Button buttonDelete = button.Delete;
                buttonDelete?.onClick.AddListener(() =>
                {
                    Delete("" + dir);
                    button.gameObject.SetActive(false);
                });
            }
        }

        public void Delete(string url)
        {
            File.Delete(url);
        }
    }
}
