using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;

namespace Aloha
{
    /// <summary>
    /// Singleton that manage the audio in game
    /// </summary>
    public class AudioManager : Singleton<AudioManager>
    {

        private GameObject audioSourceGO;
        private AudioSource audioSource;

        /// <summary>
        /// Is called when the script instance is being loaded.
        /// </summary>
        void Awake()
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

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        public void StartMusic()
        {
            AudioClip clip = LevelManager.Instance.LevelMusic;
            audioSource.clip = clip;
            audioSource.Play();
            Debug.Log($"Play music {LevelManager.Instance.LevelMusic}");
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        public void PauseMusic()
        {
            audioSource.Pause();
            Debug.Log($"Pause music");
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        public void ResumeMusic()
        {
            audioSource.Play();
            Debug.Log($"Resume music");
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        public void StopMusic()
        {
            audioSource.Stop();
            Debug.Log($"Stop music");
        }
    }
}
