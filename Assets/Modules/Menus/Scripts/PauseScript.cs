using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{

    public static bool isGamePaused = false;
    public GameObject MenuPauseUI;
    public KeyCode keyCode = KeyCode.Escape;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            if (isGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }
    }

    public void Resume()
    {
        MenuPauseUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void Pause()
    {
        MenuPauseUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }
}
