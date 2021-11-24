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
        /// This method create the game over menu and test if the game is well end
        /// </summary>
        /// <returns></returns>
        [UnityTest]
        public IEnumerator GameOverMenuTestWithEnumeratorPasses()
        {
            GameManager manager = MonoBehaviour.Instantiate(Resources.Load<GameManager>("Prefabs/GameManager"));
            GameOverMenu gameOverMenu = UIManager.Instance.GetComponent<GameOverMenu>();
            // the game is start
            manager.SetIsPlaying(true);

            Assert.IsTrue(manager.GetIsPlaying());

            // check if the time is not stopped
            Assert.IsTrue(Time.timeScale != 0f);

            // We show the gameover menu
            gameOverMenu.ShowGameOverUI();

            // Check if the menu is showed, and the game end
            Assert.IsTrue(Time.timeScale == 0f);
            Assert.IsTrue(gameOverMenu.GameOverUI.activeSelf);
            Assert.IsFalse(manager.GetIsPlaying());

            Time.timeScale = 1f;
            manager.SetIsPlaying(true);

            Aloha.Utils.ClearCurrentScene();
            yield return null;
        }
    }
}
