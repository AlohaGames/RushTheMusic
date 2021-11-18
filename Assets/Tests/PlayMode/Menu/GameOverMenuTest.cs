using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Aloha.Test
{
    /// <summary>
    /// TODO @Wilfried
    /// </summary>
    public class GameOverMenuTest
    {
        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
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

            Aloha.Utils.ClearCurrentScene();
            yield return null;
        }
    }
}
