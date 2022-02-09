using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using SimpleFileBrowser;
using Aloha;

namespace Aloha.UI
{
    /// <summary>
    /// Import Button class
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class Import : MonoBehaviour
    {
        public InformationRoot Root;

        [SerializeField]
        private GameObject loadingScreen;

        private string currentPath = "";

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        /// <summary>
        /// OnClick Action
        /// </summary>
        private void OnClick()
        {

            // Set filters (optional)
            // It is sufficient to set the filters just once (instead of each time before showing the file browser dialog), 
            // if all the dialogs will be using the same filters
            FileBrowser.SetFilters(true, new FileBrowser.Filter("RushTheMusic", ".rtm"));

            // Set default filter that is selected when the dialog is shown (optional)
            // Returns true if the default filter is set successfully
            // In this case, set Images filter as the default filter
            FileBrowser.SetDefaultFilter(".rtm");
            LevelMapping levelMapping = EditorManager.Instance.GetLevelMapping();
            StartCoroutine(ShowLoadDialogCoroutine());
        }

        /// <summary>
        /// Load .rtm file
        /// </summary>
        /// <param name="rtm">Complete URL to .rtm file</param>
        public void Load(string rtm)
        {
            LevelMetadata metadata = new LevelMetadata();
            loadingScreen.SetActive(true);
            LevelManager.Instance.Load(rtm, FinishLoad, isFromEditor: true);
        }

        /// <summary>
        /// Show Load Dialog Coroutine
        /// </summary>
        IEnumerator ShowLoadDialogCoroutine()
        {
            // Show a load file dialog and wait for a response from user
            // Load file/folder: both, Allow multiple selection: true
            // Initial path: default (Documents), Initial filename: empty
            // Title: "Load File", Submit button text: "Load"
            yield return FileBrowser.WaitForLoadDialog(FileBrowser.PickMode.Files, true, null, null, "Load Files and Folders", "Load");

            if (FileBrowser.Success)
            {
                string path = "";
                // Print paths of the selected files (FileBrowser.Result) (null, if FileBrowser.Success is false)
                for (int i = 0; i < FileBrowser.Result.Length; i++)
                {
                    path = FileBrowser.Result[i];
                }
                if (path != "")
                {
                    currentPath = path;
                    Load(path);
                }
            }
        }

        /// <summary>
        /// CallBack finish Loading
        /// </summary>
        /// <param name="tempFolder">tempFolder where .rtm was unzip</param>
        private void FinishLoad(string tempFolder)
        {
            loadingScreen.SetActive(false);
            AudioClip clip = LevelManager.Instance.LevelMusic;
            Debug.Log(tempFolder);
            Root.PathToMusic.text = tempFolder + "/" + LevelManager.Instance.LevelMetadata.MusicFilePath;
            Root.EditorRoot.Content.SetDuration(clip.length);
            Root.Duration.text = Utils.ConvertToMinSec(clip.length);
            Root.MapName.text = LevelManager.Instance.LevelMetadata.LevelName;
            Root.Description.text = LevelManager.Instance.LevelMetadata.Description;
            EditorManager.Instance.SetLevelMapping(LevelManager.Instance.LevelMapping);
        }

        private void OnDestroy()
        {
            GetComponent<Button>().onClick.RemoveListener(OnClick);
        }
    }
}
