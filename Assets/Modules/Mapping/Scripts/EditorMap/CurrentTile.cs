using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Aloha;

namespace Aloha.UI
{
    public class CurrentTile : MonoBehaviour
    {
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

        HorizontalPositionEnum horizontalPosition;
        VerticalPositionEnum verticalPosition;

        int currentId;

        SelectPos currentSelect;

        public void LoadTile(int id, LevelMapping levelMapping)
        {
            Debug.Log("Edit Tile : " + id);
            currentId = id;
            ClearCurrent();
            if (levelMapping.Enemies.ContainsKey(id))
            {
                foreach (EnemyMapping enemy in levelMapping.Enemies[id])
                {
                    GameObject ui = GetGameObjectFromPos(horizontalPosition, verticalPosition);
                    SetUIType(ui, enemy.EnemyType);
                }
            }
        }

        public void UpdateSelected(HorizontalPositionEnum h, VerticalPositionEnum v, SelectPos selectPos)
        {
            currentSelect?.Unselect();
            currentSelect = selectPos;
            currentSelect.Select();
            horizontalPosition = h;
            verticalPosition = v;
        }

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
                levelMapping.Enemies.Add(currentId, enemyMappings);
            }
            GameObject ui = GetGameObjectFromPos(horizontalPosition, verticalPosition);
            SetUIType(ui, type);
        }

        private GameObject GetGameObjectFromPos(HorizontalPositionEnum h, VerticalPositionEnum v)
        {
            switch (horizontalPosition)
            {
                case HorizontalPositionEnum.LEFT:
                    switch (verticalPosition)
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
                    switch (verticalPosition)
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
                    switch (verticalPosition)
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

        private void SetUIType(GameObject uiPos, EnemyType type)
        {
            uiPos.transform.Clear();
            GameObject image = new GameObject("image_" + type);
            image.AddGetComponent<Image>().sprite = EnemyTypeToSprite.Instance.GetEnemySprite(type);
            image.transform.SetParent(uiPos.transform);
            image.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
}
