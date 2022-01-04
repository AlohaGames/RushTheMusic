using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// TODO
/// </summary>
public class MainMenu : MonoBehaviour
{
    public int SceneIdToLoad = 1;

    /// <summary>
    /// TODO
    /// <example> Example(s):
    /// <code>
    /// TODO
    /// </code>
    /// </example>
    /// </summary>
    public void LoadGame()
    {
        SceneManager.LoadScene(SceneIdToLoad);
    }

    /// <summary>
    /// TODO
    /// <example> Example(s):
    /// <code>
    /// TODO
    /// </code>
    /// </example>
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
}
