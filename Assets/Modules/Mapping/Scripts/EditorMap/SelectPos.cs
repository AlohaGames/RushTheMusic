using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha.UI
{
    [RequireComponent(typeof(UnityEngine.UI.Button))]
    public class SelectPos : MonoBehaviour
    {
        CurrentTile tile;
        static Color selectedColor;
        static Color unselectedColor;
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

        private void OnClick()
        {
            tile.UpdateSelected(horizontal, vertical, this);
        }

        public void Select()
        {
            this.GetComponent<Image>().color = Color.green;
        }

        public void Unselect()
        {
            this.GetComponent<Image>().color = Color.gray;
        }

        private void OnDestroy()
        {
            GetComponent<Button>().onClick.RemoveListener(OnClick);
        }
    }
}
