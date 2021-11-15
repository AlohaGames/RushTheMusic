using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

//TODO: explain your FUNCKING TEST (like youyou in Tests/PlayMode/Enemy/ActionZoneTest)

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
            GameObject pause = new GameObject();
            pause.AddComponent<PauseMenu>();

            GameObject child = new GameObject();
            child.SetActive(false);
            child.transform.SetParent(pause.transform);
            pause.GetComponent<PauseMenu>().MenuPauseUI = child;

            yield return null;

            Assert.IsTrue(Time.timeScale != 0f);
            pause.GetComponent<PauseMenu>().PauseGame();

            // skip one frame
            yield return null;

            Assert.AreEqual(true, pause.GetComponent<PauseMenu>().IsGamePaused);
            Assert.AreEqual(0f, Time.timeScale);
            Assert.IsTrue(child.activeSelf);
            Assert.IsTrue(pause.GetComponent<PauseMenu>().IsGamePaused);

            yield return null;

            pause.GetComponent<PauseMenu>().Resume();

            yield return null;

            Assert.IsTrue(Time.timeScale != 0f);
            Assert.IsFalse(child.activeSelf);
            Assert.IsFalse(pause.GetComponent<PauseMenu>().IsGamePaused);

            GameObject.Destroy(child);
            GameObject.Destroy(pause);
        }
    }
}
