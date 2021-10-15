using UnityEngine;

namespace Aloha
{
    public class GameManager : Singleton<GameManager>
    {
        public bool isPlaying;

        void Start()
        {
            this.isPlaying = true;
        }

        void Update() {
            Debug.Log("Game is playing");
        }

        public void StopGame(){
            this.isPlaying = false;
        }
    }
}