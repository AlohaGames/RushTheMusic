using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Aloha.Test
{
    /// <summary>
    /// This test is for testing the game over menu
    /// </summary>
    public class GameOverMenuTest
    {
        /// <summary>
        /// This test create the game over menu and test if the game ends well
        /// </summary>
        [UnityTest]
        public IEnumerator GameOverMenuTestWithEnumeratorPasses()
        {
            GameManager manager = MonoBehaviour.Instantiate(Resources.Load<GameManager>("Prefabs/GameManager"));
            GameOverMenu gameOverMenu = UIManager.Instance.GetComponent<GameOverMenu>();

            // the game is start
            manager.IsPlaying = true;

            Assert.IsTrue(manager.IsPlaying);

            // Check if the time is not stopped
            Assert.IsTrue(Time.timeScale != 0f);

            // Show the gameover menu
            gameOverMenu.ShowGameOverUI();

            // Check if the menu is showed, and the game end
            Assert.IsTrue(Time.timeScale == 0f);
            Assert.IsTrue(gameOverMenu.GameOverUI.activeSelf);
            Assert.IsFalse(manager.IsPlaying);

            Time.timeScale = 1f;
            manager.IsPlaying = true;

            // Clear the scene
            Utils.ClearCurrentScene();
            yield return null;
        }
    }
}
