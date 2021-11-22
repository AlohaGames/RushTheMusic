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

        [SerializeField]
        public Biome baseBiome;

        [SerializeField]
        public Biome redBiome;

        private Biome currentBiome;

        public void Awake()
        {
            GlobalEvent.TileCount.AddListener(CountTile);
        }

        public void CountTile(GameObject tile)
        {
            generateSideEnv(Side.Left, tile);
            generateSideEnv(Side.Righ, tile);
        }

        public void LoadBiome(string biomeName)
        {
            // Load biome
            Debug.Log("Load biome " + biomeName);
            if(biomeName == "red") {
                currentBiome = Instantiate(redBiome);
            } else {
                currentBiome = Instantiate(baseBiome);
            }
            Camera.main.backgroundColor = currentBiome.BackgroundColor;

            GameObject castleHillGo = Instantiate(currentBiome.CastleHill);
            Vector3 bgPos = TilesManager.Instance.getEndTilesPosition();
            bgPos.y = 20f;
            castleHillGo.transform.position = bgPos;
        }

        void generateSideEnv(Side side, GameObject tile)
        {
            // Generate random index
            int index = Utils.RandomInt(0, currentBiome.SideEnvironmentPrefabs.Length);

            // Instantiate object + position
            SideEnvironment sideEnvInstR = Instantiate(currentBiome.SideEnvironmentPrefabs[index]);
            sideEnvInstR.Initialize();

            // Set scale
            sideEnvInstR.transform.localScale = new Vector3(1, sideEnvInstR.Height, 1);

            // Set position
            float tileWidth = tile.transform.localScale.x;
            float tileHeight = tile.transform.localScale.y;

            sideEnvInstR.transform.position = new Vector3(tile.transform.position.x + (int)side * tileWidth / 2.5f, sideEnvInstR.Height + tileHeight, tile.transform.position.z);

            // Attach to tile
            sideEnvInstR.transform.SetParent(tile.transform);
        }

        public Biome GetCurrentBiome() {
            return currentBiome;
        }


        public void OnDestroy()
        {
            GlobalEvent.TileCount.RemoveListener(CountTile);
        }
    }
}
