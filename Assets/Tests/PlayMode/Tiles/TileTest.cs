using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Aloha;

namespace Aloha.Test
{
    public class TileTest
    {
        // A Test behaves as an ordinary method
        [UnityTest]
        public IEnumerator TileMoveForward()
        {
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GlobalManager"));
            TilesManager tilesManager = TilesManager.Instance;

            yield return null;

            tilesManager.SpawnTileAt(0, 0);
            GameObject tile = tilesManager.activeTiles[0];

            float initialZPos = tile.transform.position.z;

            yield return null;

            Assert.Less(tile.transform.position.z, initialZPos);

            Object.Destroy(tile);

        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        /*[UnityTest]
        public IEnumerator TileAutomaticallyAppears()
        {
            //GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/TilesManager"));
            //GameObject go = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Assets/Modules/Tiles/Prefabs/BasicTile"));
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }*/
    }

}