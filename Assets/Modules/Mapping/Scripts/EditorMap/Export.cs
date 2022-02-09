using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha.UI
{
    /// <summary>
    /// Export Button class
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class Export : MonoBehaviour
    {
        public InformationRoot Root;
        private InputField pathText;
        private InputField mapName;
        private InputField description;

        [SerializeField]
        private GameObject confirmOverride;

        private void Awake()
        {
            pathText = Root.PathToMusic;
            mapName = Root.MapName;
            description = Root.Description;

            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        /// <summary>
        /// OnClick Action
        /// </summary>
        private void OnClick()
        {
            LevelMapping levelMapping = EditorManager.Instance.GetLevelMapping();
            ExportMap(levelMapping);
        }

        /// <summary>
        /// Export the levelMapping into .rtm file
        /// </summary>
        /// <param name="levelMapping">LevelMapping to save</param>
        private void ExportMap(LevelMapping levelMapping)
        {
            LevelMetadata metadata = new LevelMetadata();
            metadata.Author = ProfilManager.Instance.CurrentProfil?.Name;
            metadata.LevelName = mapName.text;
            metadata.Description = description.text;

            LevelManager.Instance.Save(levelMapping, mapName.text + ".rtm", metadata, pathText.text, true, confirmOverride.GetComponent<ConfirmWindow>());
        }

        private void OnDestroy()
        {
            GetComponent<Button>().onClick.RemoveListener(OnClick);
        }
    }
}
