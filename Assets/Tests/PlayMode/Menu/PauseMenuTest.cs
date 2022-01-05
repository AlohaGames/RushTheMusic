using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Aloha.Test
{
    public class PauseMenuTest
    {
        /// <summary>
        /// This class test the pause menu class functions.
        /// </summary>
        [UnityTest]
        public IEnumerator PauseMenuTestWithEnumeratorPasses()
        {
            // Create pause menu component
            GameObject pause = new GameObject();
            pause.AddComponent<PauseMenu>();

            // Add UI to pause menu
            GameObject child = new GameObject();
            child.SetActive(false);
            child.transform.SetParent(pause.transform);
            pause.GetComponent<PauseMenu>().MenuPauseUI = child;
            yield return null;

            // Check if the game is playing
            Assert.IsTrue(Time.timeScale != 0f);

            // Pause the game
            pause.GetComponent<PauseMenu>().PauseGame();
            yield return null;

            // Check if the game is paused/stopped
            Assert.AreEqual(true, pause.GetComponent<PauseMenu>().IsGamePaused);
            Assert.AreEqual(0f, Time.timeScale);
            Assert.IsTrue(child.activeSelf);
            Assert.IsTrue(pause.GetComponent<PauseMenu>().IsGamePaused);
            yield return null;

            // Resume the game
            pause.GetComponent<PauseMenu>().Resume();
            yield return null;

            // Check the game is playing again
            Assert.IsTrue(Time.timeScale != 0f);
            Assert.IsFalse(child.activeSelf);
            Assert.IsFalse(pause.GetComponent<PauseMenu>().IsGamePaused);

            // Clear the scene
            Utils.ClearCurrentScene();
            yield return null;
        }
    }
}
