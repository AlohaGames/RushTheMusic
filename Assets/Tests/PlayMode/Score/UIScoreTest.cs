using UnityEngine;
using NUnit.Framework;
using System.Collections;
using Aloha.Score;

namespace Aloha.Test
{
    public class UIScoreTest
    {
        [Test]
        public void Test1(){
            GameObject score = new GameObject();
            ScoreManager scoreManager = score.AddComponent<ScoreManager>();   
            Debug.Log(scoreManager);
            Debug.Log(scoreManager.GetComponents(typeof(Canvas)));
        }
        
    }
}