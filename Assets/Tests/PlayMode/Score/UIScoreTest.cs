using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

//TODO: explain your FUNCKING TEST (like youyou in 17-Add-Lancer-Prefab tests of lancer)

namespace Aloha.Test
{
    /// <summary>
    /// This class test the UIScore class functions.
    /// </summary>
    public class UIScoreTest
    {
        //TODO: refaire tests
        /*
        [Test]
        public void UIScoreInGameTest()
        {
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GlobalManager"));
            ScoreManager scoreManager = ScoreManager.Instance;

            Assert.IsTrue(scoreManager != null);

            Debug.Log(scoreManager.GetComponent<UIScore>());

            Assert.IsFalse(scoreManager.GetComponent<UIScore>().canvasUIScoreLevel.activeSelf);
            Assert.IsTrue(scoreManager.GetComponent<UIScore>().scoreText.IsActive());

            GameObject.DestroyImmediate(manager);
        }

        [UnityTest]
        public IEnumerator UIScoreEndLevelTest()
        {
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GlobalManager"));
            GameObject guerrierGO = new GameObject();
            Warrior guerrier = guerrierGO.AddComponent<Warrior>();
            ScoreManager scoreManager = ScoreManager.Instance;

            Assert.IsTrue(scoreManager != null);

            guerrier.Die();

            yield return null;

            Assert.IsTrue(scoreManager.GetComponent<UIScore>().canvasUIScoreLevel.activeSelf);
            Assert.IsFalse(scoreManager.GetComponent<UIScore>().scoreText.IsActive());

            Debug.Log(scoreManager.GetComponent<UIScore>().canvasUIScoreLevel.activeSelf);

            GameObject.DestroyImmediate(guerrierGO);
            GameObject.DestroyImmediate(manager);

            yield return null;
        }
        */
    }
}