using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha.UI
{
    /// <summary>
    /// Clean Enemy from current select position
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class CleanEnemy : MonoBehaviour
    {
        private Sprite sprite;

        private void Awake()
        {
            sprite = EnemyTypeToSprite.Instance.Delete;
            GetComponent<Image>().sprite = sprite;
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        /// <summary>
        /// OnClick Action
        /// </summary>
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
