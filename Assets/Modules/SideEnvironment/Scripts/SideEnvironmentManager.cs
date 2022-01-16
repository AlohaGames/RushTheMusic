using System.Collections;
using System.Collections.Generic;
using Aloha.Events;
using UnityEngine;

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
            GlobalEvent.LevelStop.AddListener(Reset);
        }

        /// <summary>
        /// Reset the current biome and clear the environment
        /// </summary>
        public void Reset()
        {
            currentBiome = null;
            ContainerManager.Instance.ClearContainer(ContainerTypes.Environment);
        }

        /// <summary>
        /// Even triggered on each Tile to generate side environment
        /// </summary>
        /// <param name="tile">GameObject of the tile</param>
        public void CountTile(GameObject tile)
        {
            GenerateSideEnv(Side.Left, tile);
            GenerateSideEnv(Side.Righ, tile);
            SetSidePanel(tile);
        }

        void SetSidePanel(GameObject tile)
        {
            // Generate random index
            int index_panel_right = Utils.RandomInt(0, currentBiome.SidePanelSprites.Length);
            int index_panel_left = Utils.RandomInt(0, currentBiome.SidePanelSprites.Length);

            // Set tile sprite
            tile.transform.Find("SidePanel_right").GetComponent<SpriteRenderer>().sprite = currentBiome.SidePanelSprites[index_panel_right];
            tile.transform.Find("SidePanel_left").GetComponent<SpriteRenderer>().sprite = currentBiome.SidePanelSprites[index_panel_left];
        }

        /// <summary>
        /// Load biome based on his name
        /// </summary>
        /// <param name="biomeName">The name of the biome</param>
        public void LoadBiome(string biomeName)
        {
            // Look biome to load it
            if (biomeName != null)
            {
                Debug.Log("Load biome " + biomeName);
                Biome biome = biometable[biomeName] as Biome;
                if (biome != null)
                {
                    currentBiome = Instantiate(biome);
                }
            }

            // No biome, reload default one
            if (!currentBiome)
            {
                currentBiome = Instantiate(defaultBiome);
            }

            Camera.main.backgroundColor = currentBiome.BackgroundColor;

            // Set castle in background of biome
            GameObject castleHillGo = Instantiate(currentBiome.CastleHill);
            Vector3 bgPos = TilesManager.Instance.getEndTilesPosition();
            bgPos.y = 20f;
            castleHillGo.transform.position = bgPos;

            // Add castle to env
            ContainerManager.Instance.AddToContainer(ContainerTypes.Environment, castleHillGo);
        }

        /// <summary>
        ///  Generate the side environement of each tile based on the actual tile and the side
        /// </summary>
        /// <param name="side">Side to generate environment on (either Right or Left)</param>
        /// <param name="tile">Gameobject of the actual tile</param>
        void GenerateSideEnv(Side side, GameObject tile)
        {
            //Generate random chance to spawning side environment
            float spawningChance = Utils.RandomFloat(0, 1);

            if(spawningChance >= 0.3f)
            {
                // Generate random index
                int index = Utils.RandomInt(0, currentBiome.SideEnvironmentPrefabs.Length);

                // Instantiate object + position
                SideEnvironment sideEnvInstR = Instantiate(currentBiome.SideEnvironmentPrefabs[index]);
                sideEnvInstR.Initialize();

                // Set scale
                sideEnvInstR.transform.localScale = new Vector3(sideEnvInstR.Width, sideEnvInstR.Height, 1);

                // Set position
                Collider collider = tile.GetComponent<Collider>();
                float tileWidth = collider.bounds.size.x;
                float tileHeight = collider.bounds.size.y;

                // Get the width and height of sprite
                float widthSprite = sideEnvInstR.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
                float realwidthSprite = widthSprite * sideEnvInstR.Width;
                float halfWidthSprite = realwidthSprite / 2;
                float heightSprite = sideEnvInstR.GetComponent<SpriteRenderer>().sprite.bounds.size.y;
                float halfHeightSprite = heightSprite * sideEnvInstR.Height / 2;

                // Generate random position
                float rand_min = (int)side * 2f + ((int)side * halfWidthSprite);
                float rand_max = (int)side * (tileWidth / 2) - ((int)side * halfWidthSprite);
                float randPosition = Utils.RandomFloat(rand_min, rand_max);

                float xPosition = tile.transform.position.x + randPosition;
                float yPosition = halfHeightSprite + (tileHeight / 2);
                sideEnvInstR.transform.position = new Vector3(xPosition, yPosition, tile.transform.position.z);

                // Attach to tile
                sideEnvInstR.transform.SetParent(tile.transform);
            }
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
            GlobalEvent.LevelStop.AddListener(Reset);
        }
    }
}
