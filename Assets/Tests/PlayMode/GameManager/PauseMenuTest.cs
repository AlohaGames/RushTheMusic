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
        public IEnumerator PauseResumeTest()
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
            GameManager.Instance.PauseGame();

            yield return null;

            Assert.AreEqual(0f, Time.timeScale);
            Assert.IsTrue(GameManager.Instance.IsGamePaused());

            yield return null;

            GameManager.Instance.ResumeGame();

            yield return null;

            // Check the game is playing again
            Assert.IsTrue(Time.timeScale != 0f);
            Assert.IsFalse(GameManager.Instance.IsGamePaused());

            Utils.ClearCurrentScene();
            yield return null;
        }
    }
}
