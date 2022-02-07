using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
            SceneManager.LoadScene(1);
        }

        private void OnDestroy()
        {
            GetComponent<Button>().onClick.RemoveListener(OnClick);
        }
    }
}
