using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    public class TilesManager : Singleton<TilesManager>
    {
        [HideInInspector] public List<GameObject> activeTiles = new List<GameObject>();
        public GameObject tilesContainer;
        public bool gameIsStarted;
        public int numberOfTiles; // min : 2
        public float tileSpeed = 10;
        public float tileSize = 5;

        [SerializeField] private GameObject[] tilePrefabs;

        // Start is called before the first frame update
        void Start()
        {
            gameIsStarted = false;
            tilesContainer = new GameObject("TilesContainer");
        }

        // Update is called once per frame
        void Update()
        {
            // Start the game
            if (!gameIsStarted && Input.GetKeyDown(KeyCode.Space) )
            {
                StartGame();
            }

            // Stop the game
            if (gameIsStarted && Input.GetKeyDown(KeyCode.Escape))
            {
                StopGame();
            }

            // Delete a tile and replace it by a new one
            if ( activeTiles.Count != 0 && activeTiles[0].transform.position.z + tileSize < 0)
            {
                DeleteFirstTile();
                SpawnTileToQueue(Random.Range(0, tilePrefabs.Length));
            }
        }

        public void StartGame()
        {
            if (gameIsStarted)
                return;

            gameIsStarted = true;
            for (int position = 0; position < numberOfTiles; position++)
            {
                SpawnTileAt(Random.Range(0, tilePrefabs.Length), position);
            }
        }

        public void StopGame()
        {
            if (!gameIsStarted)
                return;

            gameIsStarted = false;
            for (int i = 0; i < numberOfTiles; i++)
            {
                DeleteFirstTile();
            }
        }

        public void SpawnTileToQueue(int tileIndex)
        {
            if (activeTiles.Count == 0)
            {
                SpawnTileAt(tileIndex, 0);
                return;
            }

            GameObject tile = Instantiate(tilePrefabs[tileIndex], transform.forward * (activeTiles[activeTiles.Count - 1].transform.position.z + tileSize), transform.rotation, tilesContainer.transform);
            activeTiles.Add(tile);
        }

        public void SpawnTileAt(int tileIndex, int position)
        {
            GameObject tile = Instantiate(tilePrefabs[tileIndex], transform.forward * (tileSize * position), transform.rotation, tilesContainer.transform);
            activeTiles.Add(tile);
        }

        private void DeleteFirstTile()
        {
            Destroy(activeTiles[0]);
            activeTiles.RemoveAt(0);
        }
    }
}