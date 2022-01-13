using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using SimpleFileBrowser;

namespace Aloha.UI
{
    [RequireComponent(typeof(UnityEngine.UI.Button))]
    public class LoadMusic : MonoBehaviour
    {
        [SerializeField]
        InputField pathText;
        [SerializeField]
        Content content;
        [SerializeField]
        Text durationText;

        private void Awake()
        {
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
            StartCoroutine(LevelManager.Instance.LoadMusic(MusicUrl, FinishLoad)); ;
        }

        IEnumerator ShowLoadDialogCoroutine()
        {
            // Show a load file dialog and wait for a response from user
            // Load file/folder: both, Allow multiple selection: true
            // Initial path: default (Documents), Initial filename: empty
            // Title: "Load File", Submit button text: "Load"
            yield return FileBrowser.WaitForLoadDialog(FileBrowser.PickMode.FilesAndFolders, true, null, null, "Load Files and Folders", "Load");

            // Dialog is closed
            // Print whether the user has selected some files/folders or cancelled the operation (FileBrowser.Success)
            Debug.Log(FileBrowser.Success);

            if (FileBrowser.Success)
            {
                // Print paths of the selected files (FileBrowser.Result) (null, if FileBrowser.Success is false)
                for (int i = 0; i < FileBrowser.Result.Length; i++)
                {
                    pathText.text = FileBrowser.Result[i];
                }
            }
            Load("file://" + pathText.text);
        }

        private void FinishLoad()
        {
            AudioClip clip = LevelManager.Instance.LevelMusic;
            content.SetDuration(clip.length);
            durationText.text = ConvertToMinSec(clip.length);
        }

        private string ConvertToMinSec(float duration)
        {
            string str = "";
            int min = (int) (duration / 60);
            int sec = (int) (duration % 60);
            if (min > 0)
            {
                str += min + " min ";
            }
            str += sec + " sec";
            return str;
        }

        private void OnDestroy()
        {
            GetComponent<Button>().onClick.RemoveListener(OnClick);
        }
    }
}
