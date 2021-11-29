using UnityEngine;
using System.Collections;

namespace Aloha
{
    /// <summary>
    /// Manage the main menu
    /// </summary>
    public class MainMenu : MonoBehaviour
    {
        /// <summary>
        /// Exit the game
        /// </summary>
        public void Quit()
        {
            Application.Quit();
        }
    }
}