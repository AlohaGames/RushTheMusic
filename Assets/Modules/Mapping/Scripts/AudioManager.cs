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
        private bool shouldBePlaying = false;

        /// <summary>
        /// Is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        {
            // Create audio source
            audioSourceGO = new GameObject("Audio Source");
            audioSource = audioSourceGO.AddComponent<AudioSource>();
            audioSource.volume = GameManager.Instance.Config.GameVolume;
            ContainerManager.Instance.AddToContainer(ContainerTypes.Audio, audioSourceGO);

            // Listen to events
            GlobalEvent.LevelStart.AddListener(StartMusic);
            GlobalEvent.Pause.AddListener(PauseMusic);
            GlobalEvent.Resume.AddListener(ResumeMusic);
            GlobalEvent.LevelStop.AddListener(StopMusic);
            GlobalEvent.Victory.AddListener(delegate { this.shouldBePlaying = false; });
        }

        public void Update()
        {
            // End of music
            if (shouldBePlaying && !audioSource.isPlaying)
            {
                GlobalEvent.GameOver.Invoke();
            }
        }

        /// <summary>
        ///     Start the music on the map
        /// <example> Example(s):
        /// <code>
        ///     GlobalEvent.LevelStart.AddListener(StartMusic);
        /// </code>
        /// </example>
        /// </summary>
        public void StartMusic()
        {
            AudioClip clip = LevelManager.Instance.LevelMusic;
            audioSource.clip = clip;
            audioSource.Play();
            shouldBePlaying = true;
            Debug.Log($"Play music {LevelManager.Instance.LevelMusic}");
        }

        /// <summary>
        ///     Pause the music if playing
        /// <example> Example(s):
        /// <code>
        ///     GlobalEvent.Pause.AddListener(PauseMusic);
        /// </code>
        /// </example>
        /// </summary>
        public void PauseMusic()
        {
            shouldBePlaying = false;
            audioSource.Pause();
            Debug.Log($"Pause music");
        }

        /// <summary>
        ///     Resume music if was paused
        /// <example> Example(s):
        /// <code>
        ///     GlobalEvent.Resume.AddListener(ResumeMusic);
        /// </code>
        /// </example>
        /// </summary>
        public void ResumeMusic()
        {
            shouldBePlaying = true;
            audioSource.Play();
            Debug.Log($"Resume music");
        }

        /// <summary>
        ///     Update volume of the music
        /// <example> Example(s):
        /// <code>
        ///     GlobalEvent.UpdateVolume(ResumeMusic);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="volume">value between 0 and 1</param>
        public void UpdateVolume(float volume)
        {
            GameManager.Instance.Config.GameVolume = volume;
            if (audioSource)
            {
                audioSource.volume = volume;
            }
            Debug.Log($"New volume : {volume * 100}%");
        }

        /// <summary>
        ///     Stop the music of the map
        /// <example> Example(s):
        /// <code>
        ///     GlobalEvent.LevelStop.AddListener(StopMusic);
        /// </code>
        /// </example>
        /// </summary>
        public void StopMusic()
        {
            audioSource.Stop();
            shouldBePlaying = false;
            Debug.Log($"Stop music");
        }

        /// <summary>
        /// Is called when a Scene or game ends.
        /// </summary>
        void OnDestroy()
        {
            GlobalEvent.LevelStart.RemoveListener(StartMusic);
            GlobalEvent.Pause.RemoveListener(PauseMusic);
            GlobalEvent.Resume.RemoveListener(ResumeMusic);
            GlobalEvent.LevelStop.RemoveListener(StopMusic);
        }
    }
}
