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
            GameOverMenu gameOverMenu = UIManager.Instance.GetComponent<GameOverMenu>();
            manager.SetIsPlaying(true);

            Assert.IsTrue(manager.GetIsPlaying());

            Assert.IsTrue(Time.timeScale != 0f);

            gameOverMenu.ShowGameOverUI();
            
            Assert.IsTrue(Time.timeScale == 0f);
            Assert.IsTrue(gameOverMenu.GameOverUI.activeSelf);
            Assert.IsFalse(manager.GetIsPlaying());

            Time.timeScale = 1f;
            manager.SetIsPlaying(true);

            GameObject.Destroy(manager);

            yield return null;

            Aloha.Utils.ClearCurrentScene();
        }
    }
}

