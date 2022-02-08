using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Aloha;

namespace Aloha.UI
{
    /// <summary>
    /// Current Tile detail (position, etc...)
    /// </summary>
    public class CurrentTile : MonoBehaviour
    {
        public EditorRoot Root;
        [SerializeField]
        private GameObject upLeft;
        [SerializeField]
        private GameObject upCenter;
        [SerializeField]
        private GameObject upRight;
        [SerializeField]
        private GameObject middleLeft;
        [SerializeField]
        private GameObject middleCenter;
        [SerializeField]
        private GameObject middleRight;
        [SerializeField]
        private GameObject downLeft;
        [SerializeField]
        private GameObject downCenter;
        [SerializeField]
        private GameObject downRight;

        private HorizontalPositionEnum horizontalPosition;
        private VerticalPositionEnum verticalPosition;

        private int currentId;

        private SelectPos currentSelect;

        /// <summary>
        /// Load data for a tile based on id and levelMapping
        /// </summary>
        /// <param name="id">id of the tile</param>
        /// <param name="levelMapping">levelMapping to check</param>
        public void LoadTile(int id, LevelMapping levelMapping)
        {
            currentId = id;
            ClearCurrent();
            if (levelMapping.Enemies.ContainsKey(id))
            {
                foreach (EnemyMapping enemy in levelMapping.Enemies[id])
                {
                    GameObject ui = GetGameObjectFromPos(enemy.HorizontalPosition, enemy.VerticalPosition);
                    SetUIType(ui, enemy.EnemyType);
                    GameObject tileUI = GetTileGameObjectFromPos(enemy.HorizontalPosition);
                    SetUIType(tileUI, enemy.EnemyType);
                }
            }
        }

        /// <summary>
        /// Update current select position
        /// </summary>
        /// <param name="h">New HorizontalPosition</param>
        /// <param name="v">New VerticalPosition</param>
        /// <param name="selectPos">New Selected Position</param>
        public void UpdateSelected(HorizontalPositionEnum h, VerticalPositionEnum v, SelectPos selectPos)
        {
            currentSelect?.Unselect();
            currentSelect = selectPos;
            currentSelect.Select();
            horizontalPosition = h;
            verticalPosition = v;
        }

        /// <summary>
        /// Clear all Current Visual UI from Render
        /// </summary>
        public void ClearCurrent()
        {
            upLeft.transform.Clear();
            upCenter.transform.Clear();
            upRight.transform.Clear();
            middleLeft.transform.Clear();
            middleCenter.transform.Clear();
            middleRight.transform.Clear();
            downLeft.transform.Clear();
            downCenter.transform.Clear();
            downRight.transform.Clear();
        }

        /// <summary>
        /// Get the current enemy from current position
        /// </summary>
        /// <param name="levelMapping"></param>
        /// <returns>The EnemyMapping if found, null otherwise</returns>
        public EnemyMapping GetCurrentEnemy(LevelMapping levelMapping)
        {
            List<EnemyMapping> enemyMappings = levelMapping.Enemies[currentId];
            foreach (EnemyMapping enemyMapping in enemyMappings)
            {
                if (enemyMapping.VerticalPosition == verticalPosition && enemyMapping.HorizontalPosition == horizontalPosition)
                {
                    return enemyMapping;
                }
            }
            return null;
        }

        /// <summary>
        /// Add an Enemy to current Position
        /// </summary>
        /// <param name="type">EnemyType to add</param>
        /// <param name="levelMapping">levelMapping to change</param>
        public void AddEnemy(EnemyType type, LevelMapping levelMapping)
        {
            List<EnemyMapping> enemyMappings;
            if (levelMapping.Enemies.ContainsKey(currentId))
            {
                enemyMappings = levelMapping.Enemies[currentId];
                bool found = false;
                foreach (EnemyMapping enemyMapping in enemyMappings)
                {
                    if (enemyMapping.VerticalPosition == verticalPosition && enemyMapping.HorizontalPosition == horizontalPosition)
                    {
                        enemyMapping.EnemyType = type;
                        enemyMapping.VerticalPosition = verticalPosition;
                        enemyMapping.HorizontalPosition = horizontalPosition;
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    EnemyMapping enemyMapping = new EnemyMapping();
                    enemyMapping.EnemyType = type;
                    enemyMapping.VerticalPosition = verticalPosition;
                    enemyMapping.HorizontalPosition = horizontalPosition;
                    enemyMappings.Add(enemyMapping);
                }
            }
            else
            {
                EnemyMapping enemyMapping = new EnemyMapping();
                enemyMapping.EnemyType = type;
                enemyMapping.VerticalPosition = verticalPosition;
                enemyMapping.HorizontalPosition = horizontalPosition;
                enemyMappings = new List<EnemyMapping>();
                enemyMappings.Add(enemyMapping);
            }

            levelMapping.Enemies.Add(currentId, enemyMappings);
            GameObject ui = GetGameObjectFromPos(horizontalPosition, verticalPosition);
            SetUIType(ui, type);
            GameObject tileUI = GetTileGameObjectFromPos(horizontalPosition);
            SetUIType(tileUI, type);
        }

        /// <summary>
        /// Clean the Enemy in this position
        /// </summary>
        /// <param name="levelMapping">levelMapping to change</param>
        public void CleanEnemy(LevelMapping levelMapping)
        {
            List<EnemyMapping> enemyMappings;
            if (levelMapping.Enemies.ContainsKey(currentId))
            {
                enemyMappings = levelMapping.Enemies[currentId];
                EnemyMapping found = null;
                foreach (EnemyMapping enemyMapping in enemyMappings)
                {
                    if (enemyMapping.VerticalPosition == verticalPosition && enemyMapping.HorizontalPosition == horizontalPosition)
                    {
                        found = enemyMapping;
                        break;
                    }
                }
                if (found != null)
                {
                    enemyMappings.Remove(found);
                }
                levelMapping.Enemies.Add(currentId, enemyMappings);
            }

            GameObject ui = GetGameObjectFromPos(horizontalPosition, verticalPosition);
            ui?.transform.Clear();
            GameObject tileUI = GetTileGameObjectFromPos(horizontalPosition);
            tileUI?.transform.Clear();
        }

        /// <summary>
        /// Get the gameObject of the correct position on tile in the map
        /// </summary>
        /// <param name="h">HorizontalPosition</param>
        /// <returns>The GameObject if find, null otherwise</returns>
        private GameObject GetTileGameObjectFromPos(HorizontalPositionEnum h)
        {
            SelectTile tile = EditorManager.Instance.GetSelectTile(currentId);
            List<HorizontalTilePos> hPos = tile.Positions.ToList();
            return hPos.Find(x => x.Pos == h)?.gameObject;
        }

        /// <summary>
        /// Get the right GameObject based on position
        /// </summary>
        /// <param name="h">Horizontal Position</param>
        /// <param name="v">Vertical Position</param>
        /// <returns>
        /// The corresponding GameObject
        /// </returns>
        private GameObject GetGameObjectFromPos(HorizontalPositionEnum h, VerticalPositionEnum v)
        {
            switch (h)
            {
                case HorizontalPositionEnum.LEFT:
                    switch (v)
                    {
                        case VerticalPositionEnum.TOP:
                            return upLeft;
                        case VerticalPositionEnum.MIDDLE:
                            return middleLeft;
                        case VerticalPositionEnum.BOT:
                            return downLeft;
                        default:
                            return null;
                    }
                case HorizontalPositionEnum.CENTER:
                    switch (v)
                    {
                        case VerticalPositionEnum.TOP:
                            return upCenter;
                        case VerticalPositionEnum.MIDDLE:
                            return middleCenter;
                        case VerticalPositionEnum.BOT:
                            return downCenter;
                        default:
                            return null;
                    }
                case HorizontalPositionEnum.RIGHT:
                    switch (v)
                    {
                        case VerticalPositionEnum.TOP:
                            return upRight;
                        case VerticalPositionEnum.MIDDLE:
                            return middleRight;
                        case VerticalPositionEnum.BOT:
                            return downRight;
                        default:
                            return null;
                    }
                default:
                    return null;
            }
        }

        /// <summary>
        /// Add the corresponding Sprite to GameObject based on EnemyType
        /// </summary>
        /// <param name="uiPos">The Corresponding GameObject</param>
        /// <param name="type">The Type of the Enemy</param>
        private void SetUIType(GameObject uiPos, EnemyType type)
        {
            uiPos?.transform.Clear();
            GameObject image = new GameObject("image_" + type);
            image.AddGetComponent<Image>().sprite = EnemyTypeToSprite.Instance.GetEnemySprite(type);
            image.transform.SetParent(uiPos?.transform);
            image.transform.localPosition = new Vector3(0, 0, 0);
            image.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
    }
}
