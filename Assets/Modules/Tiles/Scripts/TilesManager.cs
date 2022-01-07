using System.Collections.Generic;
using Aloha.Events;
using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// Singleton that manage the tiles
    /// </summary>
    public class TilesManager : Singleton<TilesManager>
    {
        [HideInInspector] public bool gameIsStarted;
        private List<GameObject> activeTiles = new List<GameObject>();
        private GameObject[] tilePrefabs;
        public int NumberOfTiles = 20;
        public float TileSpeed = 10;
        public float TileSize = 5;

        [HideInInspector]
        public bool GameIsStarted;

        /// <summary>
        /// Is called on the frame when a script is enabled just before any of the Update methods are called the first time.
        /// </summary>
        void Start()
        {
            GameIsStarted = false;
        }

        /// <summary>
        /// Is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        {
            GlobalEvent.LevelStart.AddListener(StartGame);
            GlobalEvent.GameStop.AddListener(Reset);
        }

        /// <summary>
        /// Is called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        void Update()
        {
            // Delete a tile and replace it by a new one
            if (GameIsStarted && activeTiles.Count != 0 && activeTiles[0].transform.position.z + TileSize < 0)
            {
                DeleteFirstTile();
                SpawnTileToQueue(GetNextTileToSpawn());
            }
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>
        /// TODO
        /// </returns>
        public void StartGame()
        {
            if (GameIsStarted)
                return;

            this.tilePrefabs = SideEnvironmentManager.Instance.GetCurrentBiome().TilePrefabs;

            GameIsStarted = true;
            for (int position = 0; position < NumberOfTiles; position++)
            {
                SpawnTileToQueue(Random.Range(0, tilePrefabs.Length));
            }
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>
        /// Return background position based on last tile
        /// </returns>
        public Vector3 getEndTilesPosition()
        {
            return new Vector3(0, 0, TileSize * NumberOfTiles);
        }

        /// <summary>
        /// Create a tile at the end of the tile list
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        public void SpawnTileToQueue(int tileIndex)
        {
            if (activeTiles.Count == 0)
            {
                SpawnTileAt(tileIndex, 0);
                return;
            }
            GameObject tile = Instantiate(tilePrefabs[tileIndex], transform.forward * (activeTiles[activeTiles.Count - 1].transform.position.z + TileSize), transform.rotation);
            ContainerManager.Instance.AddToContainer(ContainerTypes.Tile, tile);
            activeTiles.Add(tile);
            GlobalEvent.TileCount.Invoke(tile);
            GlobalEvent.OnProgressionUpdate.Invoke(EnemySpawner.Instance.TilesCounter - NumberOfTiles, LevelManager.Instance.LevelMapping.TileCount);

            if (EnemySpawner.Instance.TilesCounter - NumberOfTiles >= LevelManager.Instance.LevelMapping.TileCount)
            {
                Time.timeScale = 0f;
                Cursor.visible = true;
                GameManager.Instance.FinishLevel();
            }
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="tileIndex"></param>
        /// <param name="position"></param>
        public void SpawnTileAt(int tileIndex, int position)
        {
            GameObject tile = Instantiate(tilePrefabs[tileIndex], transform.forward * (TileSize * position), transform.rotation);
            ContainerManager.Instance.AddToContainer(ContainerTypes.Tile, tile);
            activeTiles.Add(tile);
        }

        /// <summary>
        /// Change speed of tiles
        /// <example> Example(s):
        /// <code>
        ///     TilesManager.Instance.ChangeTileSpeed(0);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="tileSpeed"></param>
        public void ChangeTileSpeed(float tileSpeed)
        {
            this.TileSpeed = tileSpeed;
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>
        /// TODO
        /// </returns>
        int GetNextTileToSpawn()
        {
            return Random.Range(0, tilePrefabs.Length);
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        void DeleteFirstTile()
        {
            Destroy(activeTiles[0]);
            activeTiles.RemoveAt(0);
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="index"></param>
        /// <returns>
        /// TODO
        /// </returns>
        public GameObject GetActiveTileById(int index)
        {
            return activeTiles[index];
        }

        /// <summary>
        /// Reset the tiles
        /// </summary>
        public void Reset()
        {
            if (!GameIsStarted)
                return;
            GameIsStarted = false;
            activeTiles.Clear();
            ContainerManager.Instance.ClearContainer(ContainerTypes.Tile);
            GlobalEvent.GameStop.Invoke();
        }

        /// <summary>
        /// Is called when a Scene or game ends.
        /// </summary>
        void OnDestroy()
        {
            ContainerManager.Instance.ClearContainer(ContainerTypes.Tile);
            GlobalEvent.GameStop.RemoveListener(Reset);
        }
    }
}
