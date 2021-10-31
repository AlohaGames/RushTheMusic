using System.Collections.Generic;
using Aloha.Events;
using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// TODO
    /// </summary>
    public class TilesManager : Singleton<TilesManager>
    {
        private List<GameObject> activeTiles = new List<GameObject>();
        private GameObject tilesContainer;
        public int NumberOfTiles = 20;
        public float TileSpeed = 10;
        public float TileSize = 5;

        [HideInInspector] 
        public bool GameIsStarted;

        [SerializeField] 
        private GameObject[] tilePrefabs = new GameObject[] { };
        

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        void Start()
        {
            GameIsStarted = false;
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        void Awake()
        {
            GlobalEvent.LevelStart.AddListener(StartGame);
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
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

            tilesContainer = new GameObject("TilesContainer");

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
        /// TODO
        /// </returns>
        public void StopGame()
        {
            if (!GameIsStarted)
                return;

            GameIsStarted = false;
            activeTiles.Clear();
            Destroy(tilesContainer);
            GlobalEvent.LevelStop.Invoke();
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
        public void SpawnTileToQueue(int tileIndex)
        {
            if (activeTiles.Count == 0)
            {
                SpawnTileAt(tileIndex, 0);
                return;
            }

            GameObject tile = Instantiate(tilePrefabs[tileIndex], transform.forward * (activeTiles[activeTiles.Count - 1].transform.position.z + TileSize), transform.rotation, tilesContainer.transform);
            activeTiles.Add(tile);
            GlobalEvent.TileCount.Invoke(tile);
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
            GameObject tile = Instantiate(tilePrefabs[tileIndex], transform.forward * (TileSize * position), transform.rotation, tilesContainer.transform);
            activeTiles.Add(tile);
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
        private int GetNextTileToSpawn()
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
        private void DeleteFirstTile()
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
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        public void OnDestroy()
        {
            GameObject.Destroy(tilesContainer);
        }
    }
}
