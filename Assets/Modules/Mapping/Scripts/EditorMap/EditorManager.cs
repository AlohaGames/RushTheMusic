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

        public CurrentTile SelectedTileUI;
        private int currentTileId;

        [SerializeField]
        private List<SelectTile> selectTiles;

        public Color SelectedColor;
        public Color UnselectedColor;

        private bool needUpdate = false;

        private void Awake()
        {
            levelMapping = new LevelMapping();
            selectTiles = GetComponentsInChildren<SelectTile>().ToList();
        }

        private void Update()
        {
            if (needUpdate)
            {
                needUpdate = false;
                UpdateSelectTiles();
            }
        }

        public void NeedUpdate()
        {
            needUpdate = true;
            selectTiles = new List<SelectTile>();
            selectTiles.TrimExcess();
        }
        public void UpdateSelectTiles()
        {
            selectTiles = GetComponentsInChildren<SelectTile>().ToList();
        }

        public void UpdateSelectedTile(int id)
        {
            selectTiles[currentTileId].Unselect();
            currentTileId = id;
            selectTiles[id].Select();
            SelectedTileUI.LoadTile(id, levelMapping);
        }

        public void AddEnemy(EnemyType type)
        {
            Debug.Log("Add : " + type);
            SelectedTileUI.AddEnemy(type, levelMapping);
        }

        public SelectTile GetSelectTile(int id)
        {
            return selectTiles[id];
        }

        public LevelMapping GetLevelMapping()
        {
            return levelMapping;
        }

    }
}
