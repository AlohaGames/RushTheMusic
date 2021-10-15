using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PauseMenuTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void PauseMenuTestSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator PauseMenuTestWithEnumeratorPasses()
    {
        GameObject pause = new GameObject();
        pause.AddComponent<PauseScript>();

        GameObject child = new GameObject();

        child.SetActive(false);

        child.transform.SetParent(pause.transform);

        pause.GetComponent<PauseScript>().MenuPauseUI = child;

        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;

        Assert.IsTrue(Time.timeScale != 0f);

        pause.GetComponent<PauseScript>().Pause();

        // skip one frame
        yield return null;
        yield return null;
        yield return null;

        Assert.IsTrue(Time.timeScale == 0f);
        Assert.IsTrue(child.activeSelf);
        Assert.IsTrue(PauseScript.isGamePaused);

        yield return null;
        yield return null;
        yield return null;

        pause.GetComponent<PauseScript>().Resume();

        yield return null;
        yield return null;
        yield return null;

        Assert.IsTrue(Time.timeScale != 0f);
        Assert.IsFalse(child.activeSelf);
        Assert.IsFalse(PauseScript.isGamePaused);

        GameObject.Destroy(pause);


    }
}
