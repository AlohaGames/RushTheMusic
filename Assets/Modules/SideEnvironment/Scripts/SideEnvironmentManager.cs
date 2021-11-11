using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;

namespace Aloha
{
    public enum Side
    {
        Righ = 1,
        Left = -1
    }

    public class SideEnvironmentManager : Singleton<SideEnvironmentManager>
    {
        [SerializeField] private SideEnvironment[] sideEnvironmentPrefab = new SideEnvironment[] { };
        [SerializeField] private GameObject castleHill;

        public void Awake()
        {
            GlobalEvent.TileCount.AddListener(CountTile);
            GlobalEvent.LevelStart.AddListener(SpawnCastle);
        }

        public void CountTile(GameObject tile)
        {
            generateSideEnv(Side.Left, tile);
            generateSideEnv(Side.Righ, tile);
        }

        private void SpawnCastle()
        {
            GameObject castleHillGo = Instantiate(castleHill);
            Vector3 bgPos = TilesManager.Instance.getEndTilesPosition();
            bgPos.y = 20f;
            castleHillGo.transform.position = bgPos;
            GlobalEvent.LevelStart.RemoveListener(SpawnCastle);
        }

        private void generateSideEnv(Side side, GameObject tile)
        {
            // Generate random index
            int index = Utils.RandomInt(0, sideEnvironmentPrefab.Length);

            // Instantiate object + position
            SideEnvironment sideEnvInstR = Instantiate(sideEnvironmentPrefab[index]);
            sideEnvInstR.Initialize();

            // Set scale
            sideEnvInstR.transform.localScale = new Vector3(1, sideEnvInstR.height, 1);

            // Set position
            float tileWidth = tile.transform.localScale.x;
            float tileHeight = tile.transform.localScale.y;

            sideEnvInstR.transform.position = new Vector3(tile.transform.position.x + (int)side * tileWidth / 2.5f, sideEnvInstR.height + tileHeight, tile.transform.position.z);

            // Attach to tile
            sideEnvInstR.transform.SetParent(tile.transform);
        }


        public void OnDestroy()
        {
            GlobalEvent.TileCount.RemoveListener(CountTile);
        }
    }
}
