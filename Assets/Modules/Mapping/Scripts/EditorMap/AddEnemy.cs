using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha.UI
{
    /// <summary>
    /// Add Enemy Button
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class AddEnemy : MonoBehaviour
    {
        public EnemyType type;
        private Sprite sprite;

        private void Awake()
        {
            sprite = EnemyTypeToSprite.Instance.GetEnemySprite(type);
            GetComponent<Image>().sprite = sprite;
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        /// <summary>
        /// OnClick Action
        /// </summary>
        private void OnClick()
        {
            EditorManager.Instance.AddEnemy(type);
        }

        private void OnDestroy()
        {
            GetComponent<Button>().onClick.RemoveListener(OnClick);
        }
    }
}
