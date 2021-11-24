using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;
using Aloha.Events;

namespace Aloha.Test
{
    /// <summary>
    /// Test the VerticalBar  class
    /// </summary>
    public class VerticalBarTest
    {
        /// <summary>
        /// Test if the verticalBar update when a hero take damage
        /// </summary>
        [Test]
        public void VerticalBarTestSimplePasses()
        {
            // Create a hero
            GameObject heroObject = new GameObject();

            // Create an healthbar 
            GameObject healthBar = new GameObject();
            healthBar.AddComponent<Image>();

            // Create the panel with the VerticalBar script. His parent is healthbar
            GameObject updateBar = new GameObject();
            healthBar.transform.SetParent(updateBar.transform);

            updateBar.AddComponent<VerticalBar>();
            updateBar.AddComponent<RectTransform>();

            // Give stats to our hero
            HeroStats heroStats = ScriptableObject.CreateInstance<HeroStats>();
            heroStats.XP = 100;
            heroStats.MaxHealth = 100;

            // instantiate hero
            Hero myHero = heroObject.AddComponent<Hero>();
            myHero.Init(heroStats);

            int damageGiven = 25;

            float heightBarBefore = (float) healthBar.GetComponent<RectTransform>().sizeDelta.x;

            VerticalBar verticalBar = updateBar.GetComponent<VerticalBar>();

            float expectedBarAfter = -1;
            float heightBarAfter = -1;
            for (int i = 0; i < 4; i++)
            {
                expectedBarAfter = (float) updateBar.GetComponent<RectTransform>().rect.height * ((float) (myHero.CurrentHealth - damageGiven) / (float) myHero.GetStats().MaxHealth);
                myHero.TakeDamage(damageGiven);
                Assert.IsTrue(myHero.CurrentHealth == 75 - 25 * i);
                verticalBar.UpdateBar(myHero.CurrentHealth, myHero.GetStats().MaxHealth);
                heightBarAfter = (float) healthBar.GetComponent<RectTransform>().sizeDelta.y;
                Assert.IsTrue(Utils.IsEqualFloat(expectedBarAfter, heightBarAfter));
                Assert.IsTrue(heightBarAfter < heightBarBefore);
                Assert.IsTrue(Utils.IsEqualFloat(heightBarAfter, (float) updateBar.GetComponent<RectTransform>().rect.width * (float) (0.75 - 0.25 * i)));
            }

            Assert.IsTrue(expectedBarAfter == 0);
            Assert.IsTrue(heightBarAfter == 0);

            Aloha.Utils.ClearCurrentScene(true);
        }
    }
}
