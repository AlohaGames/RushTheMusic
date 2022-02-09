using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha.UI
{
    /// <summary>
    /// Select Position class
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class SelectPos : MonoBehaviour
    {
        private CurrentTile tile;
        private static Color selectedColor;
        private static Color unselectedColor;

        [SerializeField]
        private HorizontalPositionEnum horizontal;

        [SerializeField]
        private VerticalPositionEnum vertical;

        private void Awake()
        {
            tile = GetComponentInParent<CurrentTile>();
            selectedColor = EditorManager.Instance.SelectedColor;
            unselectedColor = EditorManager.Instance.UnselectedColor;
            GetComponent<Button>().onClick.AddListener(OnClick);
            Unselect();
        }

        /// <summary>
        /// OnClick Action
        /// </summary>
        private void OnClick()
        {
            tile.UpdateSelected(horizontal, vertical, this);
        }

        /// <summary>
        /// Select position
        /// </summary>
        public void Select()
        {
            this.GetComponent<Image>().color = selectedColor;
        }

        /// <summary>
        /// Unselect position
        /// </summary>
        public void Unselect()
        {
            this.GetComponent<Image>().color = unselectedColor;
        }

        private void OnDestroy()
        {
            GetComponent<Button>().onClick.RemoveListener(OnClick);
        }
    }
}
