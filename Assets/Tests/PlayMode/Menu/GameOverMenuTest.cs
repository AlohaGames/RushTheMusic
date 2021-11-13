using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Aloha.Test
{
    public class GameOverMenuTest
    {
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator GameOverMenuTestWithEnumeratorPasses()
        {
            GameManager manager = MonoBehaviour.Instantiate(Resources.Load<GameManager>("Prefabs/GameManager"));
            manager.SetIsPlaying(true);

            Assert.IsTrue(manager.GetIsPlaying());

            GameObject gameOver = new GameObject();
            gameOver.AddComponent<GameOverMenu>();

            GameObject ui = new GameObject();
            ui.SetActive(false);

            gameOver.GetComponent<GameOverMenu>().GameOverUI = ui;

            // Use the Assert class to test conditions.
            // Use yield to skip a frame.

            Assert.IsTrue(Time.timeScale != 0f);

            gameOver.GetComponent<GameOverMenu>().ShowGameOverUI();
            

            Assert.IsTrue(Time.timeScale == 0f);
            Assert.IsTrue(ui.activeSelf);
            Assert.IsFalse(manager.GetIsPlaying());

            Time.timeScale = 1f;
            manager.SetIsPlaying(true);

            GameObject.Destroy(manager);
            GameObject.Destroy(gameOver);
            GameObject.Destroy(ui);

            yield return null;


        }
    }
}

