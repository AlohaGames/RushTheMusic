using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Aloha.Test
{
    public class PauseMenuTest
    {
        /// <summary>
        /// TODO
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

            yield return null;

            Assert.IsTrue(Time.timeScale == 0f);
            Assert.IsTrue(child.activeSelf);
            Assert.IsTrue(pause.GetComponent<PauseMenu>().IsGamePaused);

            yield return null;

            pause.GetComponent<PauseMenu>().Resume();

            yield return null;

            Assert.IsTrue(Time.timeScale != 0f);
            Assert.IsFalse(child.activeSelf);
            Assert.IsFalse(pause.GetComponent<PauseMenu>().IsGamePaused);

            GameObject.Destroy(pause);
        }
    }
}
