using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Aloha.Test
{
    public class TileTest
    {

        // This Test checks if tiles are moving on Z- axis
        [UnityTest]
        public IEnumerator TileMoveForward()
        {
            GameObject tile = new GameObject();
            tile.AddComponent<BasicTile>();
            float initialZPos = tile.transform.position.z;
            yield return null;

            Assert.Less(tile.transform.position.z, initialZPos, "Does the tile move towards the player ?");
            Object.Destroy(tile);
            yield return null;
        }

        // This test checks that a new tile appears and the first one is destroy when tiles move
        /*[UnityTest]
        public IEnumerator TileAutomaticallyAppearsAndDestroyed()
        {
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            TilesManager tilesManager = TilesManager.Instance;
            LevelManager levelManager = LevelManager.Instance;
            levelManager.levelMapping = new LevelMapping();
            yield return null;

            tilesManager.StartGame();
            yield return null;

            GameObject firstTile = tilesManager.GetActiveTileById(0);
            GameObject lastTile = tilesManager.GetActiveTileById(tilesManager.numberOfTiles - 1);

            float timeOfOneTile = (tilesManager.tileSize / tilesManager.tileSpeed);
            yield return new WaitForSeconds(timeOfOneTile * 2);

            Assert.IsTrue(firstTile == null, "Is the first tile deleted when it's behind the player ?");
            Assert.AreNotSame(lastTile, tilesManager.GetActiveTileById(tilesManager.numberOfTiles - 1), "Does a new tile appear ?");

            tilesManager.StopGame();
            yield return null;

            Object.Destroy(manager);
            yield return null;

        }*/
        

        // This Test checks if the game is correctly instanced and destroyed when it's start and stop
        [UnityTest]
        public IEnumerator GameStartAndStop()
        {
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            TilesManager tilesManager = TilesManager.Instance;
            LevelManager levelManager = LevelManager.Instance;
            levelManager.levelMapping = new LevelMapping();
            yield return null;

            tilesManager.StartGame();
            yield return null;
            Assert.IsTrue(tilesManager.gameIsStarted, "Is the game started ?");

            tilesManager.StartGame();
            yield return null;
            Assert.IsTrue(tilesManager.gameIsStarted, "Is the game started ?");

            tilesManager.StopGame();
            yield return null;
            Assert.IsFalse(tilesManager.gameIsStarted, "Is the game stopped ?");

            tilesManager.StopGame();
            yield return null;
            Assert.IsFalse(tilesManager.gameIsStarted, "Is the game stopped ?");

            Object.Destroy(manager);
            yield return null;
        }


    }

}