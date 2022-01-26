using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Aloha;

namespace Aloha.UI
{
    [RequireComponent(typeof(UnityEngine.UI.Button))]
    public class EditTrack : MonoBehaviour
    {
        [SerializeField]
        private GameObject EditorPrefab;


        private InputField pathText;
        private MapContent content;
        private Text durationText;

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            GameObject editor = Instantiate(EditorPrefab);
            EditorManager.Instance.SetLevelMapping(LevelManager.Instance.LevelMapping);
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
