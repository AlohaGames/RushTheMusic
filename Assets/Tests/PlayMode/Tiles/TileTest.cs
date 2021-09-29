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

        // This Test checks if tiles are moving on Z- axis
        [UnityTest]
        public IEnumerator TileMoveForward()
        {
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GlobalManager"));
            TilesManager tilesManager = TilesManager.Instance;
            yield return null;

            tilesManager.SpawnTileAt(0, 0);
            yield return null;

            GameObject tile = tilesManager.activeTiles[0];
            float initialZPos = tile.transform.position.z;
            yield return new WaitForFixedUpdate();

            Assert.Less(tile.transform.position.z, initialZPos);

            Object.Destroy(tile);
            Object.Destroy(tilesManager);
            Object.Destroy(manager);
            yield return null;
        }

        // This test checks that a new tile appears and the first one is destroy when tiles move
        [UnityTest]
        public IEnumerator TileAutomaticallyAppearsAndDestroyed()
        {
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GlobalManager"));
            TilesManager tilesManager = TilesManager.Instance;
            yield return null;

            tilesManager.StartGame();
            yield return null;

            GameObject firstTile = tilesManager.activeTiles[0];
            GameObject lastTile = tilesManager.activeTiles[tilesManager.activeTiles.Count - 1];
            yield return new WaitForSeconds( tilesManager.tileSize / tilesManager.tileSpeed );

            if (firstTile) Assert.IsFalse(true, "Is first tile deleted ?");
            Assert.AreNotSame(lastTile, tilesManager.activeTiles[tilesManager.activeTiles.Count - 1], "Do tiles spawn ?");

            Object.Destroy(lastTile);
            tilesManager.StopGame();
            yield return null;

            Object.Destroy(tilesManager);
            Object.Destroy(manager);
            yield return null;

        }

        // This Test checks if the game is correctly instanced and destroyed when it's start and stop
        [UnityTest]
        public IEnumerator GameStartAndStop()
        {
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GlobalManager"));
            TilesManager tilesManager = TilesManager.Instance;
            yield return null;

            tilesManager.StartGame();
            yield return null;

            Assert.IsTrue(tilesManager.gameIsStarted);
            Assert.AreEqual(tilesManager.tilesContainer.transform.childCount, tilesManager.numberOfTiles);

            tilesManager.StopGame();
            yield return null;

            Assert.IsFalse(tilesManager.gameIsStarted);
            Assert.AreEqual(tilesManager.tilesContainer.transform.childCount, 0);

            Object.Destroy(tilesManager);
            Object.Destroy(manager);
        }


    }

}