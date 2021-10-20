using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Aloha;

namespace Aloha.Test
{
    public class UIScoreTest
    {
        [Test]
        public void UIScoreInGameTest()
        {
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GlobalManager"));
            ScoreManager scoreManager = ScoreManager.Instance;

            Assert.IsTrue(scoreManager != null);

            Debug.Log(scoreManager);

            Assert.IsFalse(scoreManager.GetComponent<UIManager>().canvasUIScoreLevel.activeSelf);
            Assert.IsTrue(scoreManager.GetComponent<UIManager>().scoreText.IsActive());

            GameObject.DestroyImmediate(manager);
        }

        [UnityTest]
        public IEnumerator UIScoreEndLevelTest()
        {
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GlobalManager"));
            ScoreManager scoreManager = ScoreManager.Instance;
            GameManager gameManager = GameManager.Instance;

            Assert.IsTrue(scoreManager != null);

            yield return null;

            Debug.Log(gameManager.isPlaying);

            gameManager.StopGame();

            Debug.Log(gameManager.isPlaying);

            yield return null;

            Assert.IsTrue(scoreManager.GetComponent<UIManager>().canvasUIScoreLevel.activeSelf);
            Assert.IsFalse(scoreManager.GetComponent<UIManager>().scoreText.IsActive());

            Debug.Log(scoreManager.GetComponent<UIManager>().canvasUIScoreLevel.activeSelf);

            GameObject.Destroy(manager);

            yield return null;
        }
    }
}