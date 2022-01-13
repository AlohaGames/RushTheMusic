using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha.UI
{
    [RequireComponent(typeof(UnityEngine.UI.Button))]
    public class Export : MonoBehaviour
    {
        [SerializeField]
        InputField pathText;


        [SerializeField]
        InputField mapName;

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            LevelMapping levelMapping = EditorManager.Instance.GetLevelMapping();
            ExportMap(levelMapping);
        }

        private void ExportMap(LevelMapping levelMapping)
        {
            LevelMetadata metadata = new LevelMetadata();
            LevelManager.Instance.Save(levelMapping, mapName.text + ".rtm", metadata, pathText.text, true);
        }

        private void OnDestroy()
        {
            GetComponent<Button>().onClick.RemoveListener(OnClick);
        }
    }
}
