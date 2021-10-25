using UnityEngine;

namespace Aloha
{
    public class Pause : MonoBehaviour
    {

        public static bool isGamePaused = false;
        public GameObject MenuPauseUI;
        // Start is called before the first frame update

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(InputBinding.Instance.pause))
            {
                if (isGamePaused)
                {
                    Resume();
                }
                else
                {
                    PauseGame();
                }

            }
        }

        public void Resume()
        {
            MenuPauseUI.SetActive(false);
            Time.timeScale = 1f;
            isGamePaused = false;
        }

        public void PauseGame()
        {
            MenuPauseUI.SetActive(true);
            Time.timeScale = 0f;
            isGamePaused = true;
        }
    }
}
