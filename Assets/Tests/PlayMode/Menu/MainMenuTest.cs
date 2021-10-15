using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using Aloha;

namespace Aloha.Test
{
    public class MainMenuTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void MainMenuTestSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator MainMenuTestWithEnumeratorPasses()
        {
            GameObject menu = new GameObject();
            menu.AddComponent<MenuScript>();


            SceneManager.LoadScene("MainMenu");

            string currentName = SceneManager.GetActiveScene().name;

            menu.GetComponent<MenuScript>().Play();

            string lastName = SceneManager.GetActiveScene().name;



            Assert.IsTrue(currentName != lastName);

            //Ne pas test car cela pourrait faire bug en mode non editeur
            //menu.GetComponent<MenuScript>().Quit();

            yield return null; 
        }
    }
}