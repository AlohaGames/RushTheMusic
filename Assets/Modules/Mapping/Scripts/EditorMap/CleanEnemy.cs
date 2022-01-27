using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha.UI
{
    [RequireComponent(typeof(UnityEngine.UI.Button))]
    public class CleanEnemy : MonoBehaviour
    {
        private Sprite sprite;

        private void Awake()
        {
            sprite = EnemyTypeToSprite.Instance.Delete;
            GetComponent<Image>().sprite = sprite;
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            EditorManager.Instance.CleanEnemy();
        }

        private void OnDestroy()
        {
            GetComponent<Button>().onClick.RemoveListener(OnClick);
        }
    }
}
