using UnityEngine;
using UnityEngine.SceneManagement;

namespace Aloha
{
    public class Menu : MonoBehaviour
    {

        public void Play()
        {
            SceneManager.LoadScene("SampleScene");
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
