using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha.UI
{
    [RequireComponent(typeof(UnityEngine.UI.Button))]
    public class SelectTile : MonoBehaviour
    {
        static Color selectedColor;
        static Color unselectedColor;
        [SerializeField]
        private int id;
        private Image image;

        public HorizontalTilePos[] Positions;


        private void Awake()
        {
            selectedColor = EditorManager.Instance.SelectedColor;
            unselectedColor = EditorManager.Instance.UnselectedColor;
            image = GetComponent<Image>();
            GetComponent<Button>().onClick.AddListener(OnClick);
            Unselect();

            Positions = GetComponentsInChildren<HorizontalTilePos>();
        }

        public void SetImage(Sprite sprite)
        {
            image.sprite = sprite;
        }
        private void OnClick()
        {
            EditorManager.Instance.UpdateSelectedTile(id);
        }

        public void SetId(int id)
        {
            this.id = id;
        }

        public void Select()
        {
            this.GetComponent<Image>().color = selectedColor;
        }

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
