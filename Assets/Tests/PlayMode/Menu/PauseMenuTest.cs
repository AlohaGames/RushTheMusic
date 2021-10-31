using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Aloha.Test
{
    public class PauseMenuTest
    {
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator PauseMenuTestWithEnumeratorPasses()
        {
            GameObject pause = new GameObject();
            pause.AddComponent<PauseMenu>();

            GameObject child = new GameObject();

            child.SetActive(false);

            child.transform.SetParent(pause.transform);

            pause.GetComponent<PauseMenu>().MenuPauseUI = child;

            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;

            Assert.IsTrue(Time.timeScale != 0f);

            pause.GetComponent<PauseMenu>().PauseGame();

            // skip one frame
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
