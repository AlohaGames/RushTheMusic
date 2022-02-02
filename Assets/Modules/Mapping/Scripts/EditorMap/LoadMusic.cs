using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using SimpleFileBrowser;
using Aloha;

namespace Aloha.UI
{
    [RequireComponent(typeof(UnityEngine.UI.Button))]
    public class LoadMusic : MonoBehaviour
    {
        public InformationRoot Root;

        private InputField pathText;
        private MapContent content;
        private Text durationText;

        [SerializeField]
        private GameObject loadingScreen;

        private void Awake()
        {
            pathText = Root.PathToMusic;
            content = Root.EditorRoot.Content;
            durationText = Root.Duration;

            GetComponent<Button>().onClick.AddListener(OnClick);

            // Set filters (optional)
            // It is sufficient to set the filters just once (instead of each time before showing the file browser dialog), 
            // if all the dialogs will be using the same filters
            FileBrowser.SetFilters(true, new FileBrowser.Filter("Audio", ".mp3"));

            // Set default filter that is selected when the dialog is shown (optional)
            // Returns true if the default filter is set successfully
            // In this case, set Images filter as the default filter
            FileBrowser.SetDefaultFilter(".mp3");
        }

        private void OnClick()
        {
            LevelMapping levelMapping = EditorManager.Instance.GetLevelMapping();
            StartCoroutine(ShowLoadDialogCoroutine());
        }

        private void Load(string MusicUrl)
        {
            LevelMetadata metadata = new LevelMetadata();
            loadingScreen.SetActive(true);
            StartCoroutine(LevelManager.Instance.LoadMusic(MusicUrl, FinishLoad)); ;
        }

        IEnumerator ShowLoadDialogCoroutine()
        {
            // Show a load file dialog and wait for a response from user
            // Load file/folder: both, Allow multiple selection: true
            // Initial path: default (Documents), Initial filename: empty
            // Title: "Load File", Submit button text: "Load"
            yield return FileBrowser.WaitForLoadDialog(FileBrowser.PickMode.FilesAndFolders, true, null, null, "Load Files and Folders", "Load");

            if (FileBrowser.Success)
            {
                // Print paths of the selected files (FileBrowser.Result) (null, if FileBrowser.Success is false)
                for (int i = 0; i < FileBrowser.Result.Length; i++)
                {
                    pathText.text = FileBrowser.Result[i];
                }
                Load("file://" + pathText.text);
            }
        }

        private void FinishLoad()
        {
            loadingScreen.SetActive(false);
            AudioClip clip = LevelManager.Instance.LevelMusic;
            content.SetDuration(clip.length);
            durationText.text = Utils.ConvertToMinSec(clip.length);
        }

        private void OnDestroy()
        {
            GetComponent<Button>().onClick.RemoveListener(OnClick);
        }
    }
}
