using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;

namespace Aloha.UI
{
    public class EditorManager : MonoBehaviour
    {
        public int? SelectedTilesId = null;

        public IntEvent UpdateSelectedTile = new IntEvent();

        public CurrentTile SelectedTileUI;

        private void Awake()
        {
            UpdateSelectedTile.AddListener(OnSelectedTileUpdate);
        }

        private void OnSelectedTileUpdate(int id)
        {

        }
    }
}
