using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Class for the main menu UI
/// </summary>
public class MainMenu : MonoBehaviour
{
    public int SceneIdToLoad = 1;

    /// <summary>
    /// Load a game
    /// <example> Example(s):
    /// <code>
    ///     mn.LoadGame();
    /// </code>
    /// </example>
    /// </summary>
    public void LoadGame()
    {
        SceneManager.LoadScene(SceneIdToLoad);
    }

    /// <summary>
    /// Quit the application
    /// <example> Example(s):
    /// <code>
    ///     mn.Quit();
    /// </code>
    /// </example>
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
}
