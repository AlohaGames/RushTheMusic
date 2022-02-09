using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Aloha.Events;

namespace Aloha.UI
{
    /// <summary>
    /// Main Manager of the MapEditor
    /// </summary>
    public class EditorManager : Singleton<EditorManager>
    {
        public EditorRoot EditorRoot;
        public Color SelectedColor;
        public Color UnselectedColor;
        public int? SelectedTilesId = null;

        [SerializeField]
        private LevelMapping levelMapping = null;
        private Biome biome = null;

        public CurrentTile SelectedTileUI;
        private int currentTileId;

        [SerializeField]
        private List<SelectTile> selectTiles;

        [SerializeField]
        private BiomeSelector biomeSelector;

        private bool needUpdate = false;

        private void Awake()
        {
            levelMapping = new LevelMapping();
            selectTiles = GetComponentsInChildren<SelectTile>().ToList();

            if (LevelManager.Instance.URLToLoad != "")
            {
                EditorRoot.Information.Import.GetComponent<Import>().Load(LevelManager.Instance.URLToLoad);
            }
        }

        private void Update()
        {
            if (needUpdate)
            {
                needUpdate = false;
                UpdateSelectTiles();
            }
        }

        /// <summary>
        /// Set Tile Count
        /// </summary>
        /// <param name="count"></param>
        public void SetTilesCount(int count)
        {
            levelMapping.TileCount = count;
        }

        /// <summary>
        /// Define the current Biome
        /// </summary>
        /// <param name="biome">New Biome</param>
        public void SetBiome(Biome biome)
        {
            this.biome = biome;
            levelMapping.BiomeName = biome.BiomeName;
            foreach (SelectTile tile in selectTiles)
            {
                tile.SetImage(biome.TileSprite);
            }
        }

        /// <summary>
        /// Editor need to update the map element
        /// </summary>
        public void NeedUpdate()
        {
            needUpdate = true;
            selectTiles = new List<SelectTile>();
            selectTiles.TrimExcess();
        }

        /// <summary>
        /// Update SelectTiles list
        /// </summary>
        public void UpdateSelectTiles()
        {
            selectTiles = GetComponentsInChildren<SelectTile>().ToList();
            if (biome) SetBiome(biome);
            for (int i = 0; i < selectTiles.Count; i++)
            {
                UpdateSelectedTile(i);
            }
            if (selectTiles.Count > 15) UpdateSelectedTile(4);
        }

        /// <summary>
        /// Update Current Selected Tile
        /// </summary>
        /// <param name="id">id of the tile</param>
        public void UpdateSelectedTile(int id)
        {
            selectTiles[currentTileId].Unselect();
            currentTileId = id;
            selectTiles[id].Select();
            SelectedTileUI.LoadTile(id, levelMapping);
        }

        /// <summary>
        /// Add Enemy based on Type
        /// </summary>
        /// <param name="type">Type of the enemy</param>
        public void AddEnemy(EnemyType type)
        {
            SelectedTileUI.AddEnemy(type, levelMapping);
        }

        /// <summary>
        /// Clean Enemy
        /// </summary>
        public void CleanEnemy()
        {
            SelectedTileUI.CleanEnemy(levelMapping);
        }

        /// <summary>
        /// Get SelectTile based on id
        /// </summary>
        /// <param name="id">id of the tile</param>
        /// <returns>SelectTile</returns>
        public SelectTile GetSelectTile(int id)
        {
            return selectTiles[id];
        }

        /// <summary>
        /// Getter of levelMapping
        /// </summary>
        /// <returns>levelMapping</returns>
        public LevelMapping GetLevelMapping()
        {
            return levelMapping;
        }

        /// <summary>
        /// Setter of levelMapping
        /// </summary>
        /// <param name="levelMapping">New LevelMapping</param>
        public void SetLevelMapping(LevelMapping levelMapping)
        {
            this.levelMapping = levelMapping;
            biomeSelector.transform.parent.gameObject.SetActive(true);
            Debug.Log(levelMapping.BiomeName);
            biomeSelector.SelectBiome(levelMapping.BiomeName);
            biomeSelector.transform.parent.gameObject.SetActive(false);
        }

        /// <summary>
        /// Return to MainMenu
        /// </summary>
        public void ReturnToMenu()
        {
            SceneManager.LoadScene(0); // Load scene with index 0 (TheGame)
        }
    }
}
