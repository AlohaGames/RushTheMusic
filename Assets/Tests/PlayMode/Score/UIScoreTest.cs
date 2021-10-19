using UnityEngine;
using NUnit.Framework;
using Aloha.Score;

namespace Aloha.Test
{
    public class UIScoreTest
    {
        [Test]
        public void UIScoreInGame(){
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GlobalManager"));
            ScoreManager scoreManager = ScoreManager.Instance;

            Assert.IsTrue(scoreManager != null);

            Assert.IsFalse(scoreManager.GetComponent<UIManager>().canvasUIScoreLevel.activeSelf);
            Assert.IsTrue(scoreManager.GetComponent<UIManager>().scoreText.IsActive());
        }
    }
}