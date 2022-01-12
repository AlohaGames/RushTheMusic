using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;

namespace Aloha.UI
{
    public class EditorManager : Singleton<EditorManager>
    {
        public int? SelectedTilesId = null;
        [SerializeField]
        private LevelMapping levelMapping = null;

        public static IntEvent UpdateSelectedTile = new IntEvent();

        public CurrentTile SelectedTileUI;

        private void Awake()
        {
            levelMapping = new LevelMapping();
            UpdateSelectedTile.AddListener(OnSelectedTileUpdate);
        }

        private void OnSelectedTileUpdate(int id)
        {
            SelectedTileUI.LoadTile(id, levelMapping);
        }

        private void OnDestroy()
        {
            UpdateSelectedTile.RemoveListener(OnSelectedTileUpdate);
        }
    }
}
