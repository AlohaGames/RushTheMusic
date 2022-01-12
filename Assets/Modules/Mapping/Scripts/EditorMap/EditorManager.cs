using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        private int currentTileId;

        [SerializeField]
        private List<SelectTile> selectTiles;

        public Color SelectedColor;
        public Color UnselectedColor;

        private void Awake()
        {
            levelMapping = new LevelMapping();
            selectTiles = GetComponentsInChildren<SelectTile>().ToList();
            UpdateSelectedTile.AddListener(OnSelectedTileUpdate);
        }

        private void OnSelectedTileUpdate(int id)
        {
            selectTiles[currentTileId].Unselect();
            currentTileId = id;
            selectTiles[id].Select();
            SelectedTileUI.LoadTile(id, levelMapping);
        }

        private void OnDestroy()
        {
            UpdateSelectedTile.RemoveListener(OnSelectedTileUpdate);
        }
    }
}
