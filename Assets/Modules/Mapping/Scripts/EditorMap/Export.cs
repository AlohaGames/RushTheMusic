using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha.UI
{
    [RequireComponent(typeof(UnityEngine.UI.Button))]
    public class Export : MonoBehaviour
    {
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
            LevelManager.Instance.Save(levelMapping, "NewMap.rtm", metadata, "/home/dbricaud/Musique/test.mp3", true);
        }

        private void OnDestroy()
        {
            GetComponent<Button>().onClick.RemoveListener(OnClick);
        }
    }
}
