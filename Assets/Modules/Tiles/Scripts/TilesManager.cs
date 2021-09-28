using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    public class TilesManager : Singleton<TilesManager>
    {
        [SerializeField] private GameObject[] tilePrebabs;
        [SerializeField] private int numberOfTiles;
        public float tileSpeed = 10;
        public float tileSize = 5;

        [HideInInspector] public List<GameObject> activeTiles = new List<GameObject>();
        private GameObject tilesContainer;

        // Start is called before the first frame update
        void Start()
        {
            tilesContainer = new GameObject("TilesContainer");

            for (int position = 0; position < numberOfTiles; position++)
            {
                SpawnTileAt(Random.Range(0, tilePrebabs.Length), position);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if ( activeTiles.Count != 0 && activeTiles[0].transform.position.z + tileSize < 0)
            {
                DeleteFirstTile();
                SpawnTileToQueue(Random.Range(0, tilePrebabs.Length));
            }
        }

        public void SpawnTileToQueue(int tileIndex)
        {
            GameObject tile = Instantiate(tilePrebabs[tileIndex], transform.forward * (activeTiles[activeTiles.Count - 1].transform.position.z + tileSize), transform.rotation, tilesContainer.transform);
            activeTiles.Add(tile);
        }

        public void SpawnTileAt(int tileIndex, int position)
        {
            GameObject tile = Instantiate(tilePrebabs[tileIndex], transform.forward * (tileSize * position), transform.rotation, tilesContainer.transform);
            activeTiles.Add(tile);
        }

        private void DeleteFirstTile()
        {
            Destroy(activeTiles[0]);
            activeTiles.RemoveAt(0);
        }

    }
}