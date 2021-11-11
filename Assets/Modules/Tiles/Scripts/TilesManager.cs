using System.Collections.Generic;
using Aloha.Events;
using UnityEngine;

namespace Aloha
{
    public class TilesManager : Singleton<TilesManager>
    {
        [HideInInspector] public bool gameIsStarted;
        public int numberOfTiles = 20;
        public float tileSpeed = 10;
        public float tileSize = 5;

        [SerializeField] private GameObject[] tilePrefabs = new GameObject[] { };
        private List<GameObject> activeTiles = new List<GameObject>();
        private GameObject tilesContainer;

        // Start is called before the first frame update
        void Start()
        {
            gameIsStarted = false;
        }

        void Awake()
        {
            GlobalEvent.LevelStart.AddListener(StartGame);
        }

        // Update is called once per frame
        void Update()
        {
            // Delete a tile and replace it by a new one
            if (gameIsStarted && activeTiles.Count != 0 && activeTiles[0].transform.position.z + tileSize < 0)
            {
                DeleteFirstTile();
                SpawnTileToQueue(GetNextTileToSpawn());
            }
        }

        // Init elements to make the game start
        public void StartGame()
        {
            if (gameIsStarted)
                return;

            tilesContainer = new GameObject("TilesContainer");

            gameIsStarted = true;
            for (int position = 0; position < numberOfTiles; position++)
            {
                SpawnTileToQueue(Random.Range(0, tilePrefabs.Length));
            }
        }

        // Stop the game and delete elements
        public void StopGame()
        {
            if (!gameIsStarted)
                return;

            gameIsStarted = false;
            activeTiles.Clear();
            Destroy(tilesContainer);
            GlobalEvent.LevelStop.Invoke();
        }

        // Return background position based on last tile
        public Vector3 getEndTilesPosition()
        {
            return new Vector3(0, 0, tileSize * numberOfTiles);
        }

        // Create a tile at the end of the tile list
        public void SpawnTileToQueue(int tileIndex)
        {
            if (activeTiles.Count == 0)
            {
                SpawnTileAt(tileIndex, 0);
                return;
            }

            GameObject tile = Instantiate(tilePrefabs[tileIndex], transform.forward * (activeTiles[activeTiles.Count - 1].transform.position.z + tileSize), transform.rotation, tilesContainer.transform);
            activeTiles.Add(tile);
            GlobalEvent.TileCount.Invoke(tile);
        }

        // Create a tile at the position the user wants
        // (Only if tiles didn't use at all)
        public void SpawnTileAt(int tileIndex, int position)
        {
            GameObject tile = Instantiate(tilePrefabs[tileIndex], transform.forward * (tileSize * position), transform.rotation, tilesContainer.transform);
            activeTiles.Add(tile);
        }

        // Return the id of the next tile to spawn
        private int GetNextTileToSpawn()
        {
            return Random.Range(0, tilePrefabs.Length);
        }

        // Delete the first tile of the list
        private void DeleteFirstTile()
        {
            Destroy(activeTiles[0]);
            activeTiles.RemoveAt(0);
        }

        public GameObject GetActiveTileById(int index)
        {
            return activeTiles[index];
        }

        public void OnDestroy()
        {
            GameObject.Destroy(tilesContainer);
        }
    }
}
