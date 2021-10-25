using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int SceneIdToLoad = 1;
    public void LoadGame()
    {
        SceneManager.LoadScene(SceneIdToLoad);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
