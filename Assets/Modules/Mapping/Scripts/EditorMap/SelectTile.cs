using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha.UI
{
    [RequireComponent(typeof(UnityEngine.UI.Button))]
    public class SelectTile : MonoBehaviour
    {
        [SerializeField]
        private int id;

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            EditorManager.UpdateSelectedTile.Invoke(id);
        }

        private void OnDestroy()
        {
            GetComponent<Button>().onClick.RemoveListener(OnClick);
        }
    }
}
