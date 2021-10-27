using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;

namespace Aloha
{
    public class AudioManager : Singleton<AudioManager>
    {

        private GameObject audioSourceGO;
        private AudioSource audioSource;

        public void Awake()
        {
            // Create audio source
            audioSourceGO = new GameObject();
            audioSource = audioSourceGO.AddComponent<AudioSource>();

            // Listen to events
            GlobalEvent.LevelStart.AddListener(StartMusic);
            GlobalEvent.Pause.AddListener(PauseMusic);
            GlobalEvent.Resume.AddListener(ResumeMusic);
            GlobalEvent.LevelStop.AddListener(StopMusic);
        }

        public void StartMusic()
        {
            AudioClip clip = LevelManager.Instance.levelMusic;
            audioSource.clip = clip;
            audioSource.Play();
            Debug.Log($"Play music {LevelManager.Instance.levelMusic}");
        }

        public void PauseMusic()
        {
            audioSource.Pause();
            Debug.Log($"Pause music");
        }

        public void ResumeMusic()
        {
            audioSource.Play();
            Debug.Log($"Resume music");
        }

        public void StopMusic()
        {
            audioSource.Stop();
            Debug.Log($"Stop music");
        }
    }
}
