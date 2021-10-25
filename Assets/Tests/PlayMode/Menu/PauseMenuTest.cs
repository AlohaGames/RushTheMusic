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
            pause.AddComponent<Pause>();

            GameObject child = new GameObject();

            child.SetActive(false);

            child.transform.SetParent(pause.transform);

            pause.GetComponent<Pause>().MenuPauseUI = child;

            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;

            Assert.IsTrue(Time.timeScale != 0f);

            pause.GetComponent<Pause>().PauseGame();

            // skip one frame
            yield return null;
            yield return null;
            yield return null;

            Assert.IsTrue(Time.timeScale == 0f);
            Assert.IsTrue(child.activeSelf);
            Assert.IsTrue(Pause.isGamePaused);

            yield return null;
            yield return null;
            yield return null;

            pause.GetComponent<Pause>().Resume();

            yield return null;
            yield return null;
            yield return null;

            Assert.IsTrue(Time.timeScale != 0f);
            Assert.IsFalse(child.activeSelf);
            Assert.IsFalse(Pause.isGamePaused);

            GameObject.Destroy(pause);


        }
    }
}