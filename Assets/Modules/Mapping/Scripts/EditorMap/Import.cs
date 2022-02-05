using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using SimpleFileBrowser;
using Aloha;

namespace Aloha.UI
{
    [RequireComponent(typeof(Button))]
    public class Import : MonoBehaviour
    {
        public InformationRoot Root;

        [SerializeField]
        private GameObject loadingScreen;

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

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

        private void Load(string rtm)
        {
            LevelMetadata metadata = new LevelMetadata();
            loadingScreen.SetActive(true);
            LevelManager.Instance.Load(rtm, FinishLoad, isFromEditor: true);
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
                string path = "";
                // Print paths of the selected files (FileBrowser.Result) (null, if FileBrowser.Success is false)
                for (int i = 0; i < FileBrowser.Result.Length; i++)
                {
                    path = FileBrowser.Result[i];
                }
                if (path != "")
                {
                    Root.PathToMusic.text = path;
                    Load(path);
                }
            }
        }

        private void FinishLoad()
        {
            loadingScreen.SetActive(false);
            AudioClip clip = LevelManager.Instance.LevelMusic;
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
