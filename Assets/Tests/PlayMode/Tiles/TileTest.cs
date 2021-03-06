using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using System;
using System.Collections.Generic;

namespace Aloha.Test
{
    /// <summary>
    /// Class for tile test
    /// </summary>
    public class TileTest
    {
        /// <summary>
        /// This Test checks if tiles are moving on Z- axis
        /// </summary>
        [UnityTest]
        public IEnumerator TileMoveForward()
        {
            GameObject tile = new GameObject();
            tile.AddComponent<BasicTile>();
            float initialZPos = tile.transform.position.z;
            yield return null;

            Assert.Less(tile.transform.position.z, initialZPos, "Does the tile move towards the player ?");

            // Clear the scene
            Utils.ClearCurrentScene();
            yield return null;
        }

        /// <summary>
        /// Changes tiles speed
        /// </summary>
        [UnityTest]
        public IEnumerator ChangeTilesSpeed()
        {
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            TilesManager tilesManager = TilesManager.Instance;
            LevelManager levelManager = LevelManager.Instance;
            levelManager.LevelMapping = new LevelMapping();
            tilesManager.getEndTilesPosition();
            yield return null;

            tilesManager.ChangeTileSpeed(1);
            Assert.AreEqual(1, tilesManager.TileSpeed);

            tilesManager.ChangeTileSpeed(10);
            Assert.AreEqual(10, tilesManager.TileSpeed);

            // Clear the scene
            Utils.ClearCurrentScene();
            yield return null;
        }

        /// <summary>
        /// This test checks that a new tile appears and the first one is destroy when tiles move
        /// </summary>
        [UnityTest]
        public IEnumerator TileAutomaticallyAppearsAndDestroyed()
        {
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            TilesManager tilesManager = TilesManager.Instance;
            LevelManager levelManager = LevelManager.Instance;
            levelManager.LevelMapping = new LevelMapping(new SerializeDictionary<int, List<EnemyMapping>>(), 50);
            yield return null;

            tilesManager.OnLevelStart();
            yield return null;

            GameObject firstTile = tilesManager.GetActiveTileById(0);
            GameObject lastTile = tilesManager.GetActiveTileById(tilesManager.NumberOfTiles - 1);

            float timeOfOneTile = (tilesManager.TileSize / tilesManager.TileSpeed);
            yield return new WaitForSeconds(timeOfOneTile * 2);

            Assert.IsTrue(firstTile == null, "Is the first tile deleted when it's behind the player ?");
            Assert.AreNotSame(lastTile, tilesManager.GetActiveTileById(tilesManager.NumberOfTiles - 1), "Does a new tile appear ?");

            tilesManager.Reset();
            yield return null;

            // Clear the scene
            Utils.ClearCurrentScene();
            yield return null;
        }
    }
}
