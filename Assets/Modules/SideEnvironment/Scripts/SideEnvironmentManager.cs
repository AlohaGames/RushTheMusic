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

    /// <summary>
    /// Class of the manager for the side environment
    /// </summary>
    public class SideEnvironmentManager : Singleton<SideEnvironmentManager>
    {

        [SerializeField]
        private List<Biome> biomes;

        [SerializeField]
        private Biome defaultBiome;

        [SerializeField]
        private Hashtable biometable = new Hashtable();

        private Biome currentBiome;

        /// <summary>
        /// Is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        {
            currentBiome = Instantiate(defaultBiome);

            foreach (Biome b in biomes)
            {
                biometable.Add(b.BiomeName, b);
            }

            GlobalEvent.TileCount.AddListener(CountTile);
        }

        /// <summary>
        /// Even triggered on each Tile to generate side environment
        /// </summary>
        /// <param name="tile">GameObject of the tile</param>
        public void CountTile(GameObject tile)
        {
            generateSideEnv(Side.Left, tile);
            generateSideEnv(Side.Righ, tile);
        }

        /// <summary>
        /// Load biome based on his name
        /// </summary>
        /// <param name="biomeName">The name of the biome</param>
        public void LoadBiome(string biomeName)
        {
            if (biomeName != null)
            {
                Debug.Log("Load biome " + biomeName);
                Biome biome = biometable[biomeName] as Biome;
                if (biome != null)
                {
                    // Biome found
                    currentBiome = Instantiate(biome);
                }
            }
            Camera.main.backgroundColor = currentBiome.BackgroundColor;

            // Set castle in background of biome
            GameObject castleHillGo = Instantiate(currentBiome.CastleHill);
            Vector3 bgPos = TilesManager.Instance.getEndTilesPosition();
            bgPos.y = 20f;
            castleHillGo.transform.position = bgPos;
        }

        /// <summary>
        ///  Generate the side environement of each tile based on the actual tile and the side
        /// </summary>
        /// <param name="side">Side to generate environment on (either Right or Left)</param>
        /// <param name="tile">Gameobject of the actual tile</param>
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

        /// <summary>
        /// Get current loaded biome
        /// </summary>
        /// <returns>
        /// The current biome
        /// </returns>
        public Biome GetCurrentBiome()
        {
            return currentBiome;
        }

        /// <summary>
        /// Cleanup fonction called on destroy
        /// </summary>
        void OnDestroy()
        {
            GlobalEvent.TileCount.RemoveListener(CountTile);
        }
    }
}
