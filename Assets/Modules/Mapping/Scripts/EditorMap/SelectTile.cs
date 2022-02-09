using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha.UI
{
    /// <summary>
    /// Select Tile class
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class SelectTile : MonoBehaviour
    {
        public HorizontalTilePos[] Positions;

        private static Color selectedColor;
        private static Color unselectedColor;

        [SerializeField]
        private int id;

        private Image image;


        private void Awake()
        {
            if (!selectedColor) selectedColor = EditorManager.Instance.SelectedColor;
            if (!unselectedColor) unselectedColor = EditorManager.Instance.UnselectedColor;
            image = GetComponent<Image>();
            GetComponent<Button>().onClick.AddListener(OnClick);
            Unselect();

            Positions = GetComponentsInChildren<HorizontalTilePos>();
        }

        /// <summary>
        /// Set BackGround image
        /// </summary>
        /// <param name="sprite"></param>
        public void SetImage(Sprite sprite)
        {
            image.sprite = sprite;
        }

        /// <summary>
        /// OnClick Action
        /// </summary>
        private void OnClick()
        {
            EditorManager.Instance.UpdateSelectedTile(id);
        }

        /// <summary>
        /// Setter of ID
        /// </summary>
        /// <param name="id">new ID</param>
        public void SetId(int id)
        {
            this.id = id;
        }

        /// <summary>
        /// Select this tile
        /// </summary>
        public void Select()
        {
            this.GetComponent<Image>().color = selectedColor;
        }

        /// <summary>
        /// Unselect this tile
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
