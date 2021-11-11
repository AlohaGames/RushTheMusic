using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Aloha.Test
{
    public class UIScoreTest
    {
        /// <summary>
        /// This function tests if UI in game elements is active
        /// </summary>
        [Test]
        public void UIScoreInGameElementsTest()
        {
            //Create Manager instance and ScoreManager instance
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            UIManager instanceUIManager = UIManager.Instance;

            //Show UI in game elements
            instanceUIManager.UIScore.ShowInGameUIScoreElements();

            //Tests if UI in game elements are active
            Assert.IsTrue(instanceUIManager.UIScore.InGameScore.activeSelf);
            Assert.IsTrue(instanceUIManager.UIScore.InGameScoreText.IsActive());

            //Tests if UI end game elements are disable
            Assert.IsFalse(instanceUIManager.UIScore.EndGameScore.activeSelf);

            GameObject.DestroyImmediate(manager);
        }

        /// <summary>
        /// This function tests if UI end game elements is active
        /// </summary>
        [Test]
        public void UIScoreEndGameElementsTest()
        {
            //Create Manager instance and ScoreManager instance
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            UIManager instanceUIManager = UIManager.Instance;

            //Show UI in game elements
            instanceUIManager.UIScore.ShowEndGameUIScoreElements();

            //Tests if UI end game elements are active
            Assert.IsTrue(instanceUIManager.UIScore.EndGameScore.activeSelf);
            Assert.IsTrue(instanceUIManager.UIScore.TotalScoreText.IsActive());
            Assert.IsTrue(instanceUIManager.UIScore.DistanceScoreText.IsActive());
            Assert.IsTrue(instanceUIManager.UIScore.KillScoreText.IsActive());
            Assert.IsTrue(instanceUIManager.UIScore.HitScoreText.IsActive());

            //Tests if UI in game elements are disable
            Assert.IsFalse(instanceUIManager.UIScore.InGameScore.activeSelf);

            GameObject.DestroyImmediate(manager);
        }
    }
}
