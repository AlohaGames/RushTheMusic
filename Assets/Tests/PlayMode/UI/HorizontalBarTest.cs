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
    /// Test the HorizontalBar class
    /// </summary>
    public class HorizontalBarTest
    {
        /// <summary>
        /// Test if the horizontalBar update when a hero take damage
        /// </summary>
        [Test]
        public void HorizonalBarTestSimplePasses()
        {
            // Create a hero
            GameObject heroObject = new GameObject();

            // Create an healthbar 
            GameObject healthBar = new GameObject();
            healthBar.AddComponent<Image>();

            // Create the panel with the VerticalBar script. His parent is healthbar
            GameObject updateBar = new GameObject();
            healthBar.transform.SetParent(updateBar.transform);

            updateBar.AddComponent<HorizontalBar>();
            updateBar.AddComponent<RectTransform>();

            // Give stats to hero
            HeroStats heroStats = ScriptableObject.CreateInstance<HeroStats>();
            heroStats.XP = 100;
            heroStats.MaxHealth = 100;

            // instantiate hero
            Hero myHero = heroObject.AddComponent<Hero>();
            myHero.Init(heroStats);

            int damageGiven = 25;

            float widthBarBefore = (float) healthBar.GetComponent<RectTransform>().sizeDelta.x;

            HorizontalBar horizontalBar = updateBar.GetComponent<HorizontalBar>();

            float expectedBarAfter = -1;
            float widthBarAfter = -1;
            for (int i = 0; i < 4; i++)
            {
                expectedBarAfter = (float) updateBar.GetComponent<RectTransform>().rect.width * ((float) (myHero.CurrentHealth - damageGiven) / (float) myHero.GetStats().MaxHealth);
                myHero.TakeDamage(damageGiven);
                Assert.IsTrue(myHero.CurrentHealth == 75 - 25 * i);
                horizontalBar.UpdateBar(myHero.CurrentHealth, myHero.GetStats().MaxHealth);
                widthBarAfter = (float) healthBar.GetComponent<RectTransform>().sizeDelta.x;
                Assert.IsTrue(Utils.IsEqualFloat(expectedBarAfter, widthBarAfter));
                Assert.IsTrue(widthBarAfter < widthBarBefore);
                Assert.IsTrue(Utils.IsEqualFloat(widthBarAfter, (float) updateBar.GetComponent<RectTransform>().rect.width * (float) (0.75 - 0.25 * i)));
            }

            Assert.IsTrue(expectedBarAfter == 0);
            Assert.IsTrue(widthBarAfter == 0);

            Aloha.Utils.ClearCurrentScene(true);
        }
    }
}
