using UnityEngine;
using System.Collections.Generic;
using Aloha.Events;

namespace Aloha
{
    /// <summary>
    /// Singleton that manage the sound effects in game
    /// </summary>
    public class SoundEffectManager : Singleton<SoundEffectManager>
    {
        public Sounds Sounds;
        public List<AudioSource> Sources;

        /// <summary>
        /// Basic Awake function
        /// </summary>
        void Awake()
        {
            if (Sounds == null)
            {
                Sounds = ScriptableObject.CreateInstance<Sounds>();
            }
            Sources = new List<AudioSource>();

            GlobalEvent.Pause.AddListener(Pause);
            GlobalEvent.Resume.AddListener(Resume);
            GlobalEvent.Victory.AddListener(PlayVictory);
            GlobalEvent.GameOver.AddListener(PlayDefeat);
        }

        /// <summary>
        /// Called when the game is paused
        /// <example> Example(s):
        /// <code>
        ///     entity.Pause();
        /// </code>
        /// </example>
        /// </summary>
        public void Pause()
        {
            Sources.RemoveAll((source) => { return (source == null); });
            foreach (AudioSource source in Sources)
            {
                if (source.isPlaying == false)
                {
                    DestroyImmediate(source.gameObject);
                }
            }
            Sources.RemoveAll((source) => { return (source == null); });
            foreach (AudioSource source in Sources)
            {
                source.Pause();
            }
        }

        /// <summary>
        /// Called when the game is resumed
        /// <example> Example(s):
        /// <code>
        ///     entity.Resume();
        /// </code>
        /// </example>
        /// </summary>
        public void Resume()
        {
            foreach (AudioSource source in Sources)
            {
                source.UnPause();
            }
        }

        /// <summary>
        ///     Update volume of sound effect sources
        /// <example> Example(s):
        /// <code>
        ///     GlobalEvent.UpdateVolume(0.8f);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="volume">value between 0 and 1</param>
        public void UpdateVolume(float volume)
        {
            GameManager.Instance.Config.GameSoundEffectsVolume = volume;
            foreach (AudioSource source in Sources)
            {
                source.volume = volume;
            }
            Debug.Log($"New sound effect volume : {volume * 100}%");
        }

        /// <summary>
        /// Call to play a sound
        /// <example> Example(s):
        /// <code>
        ///     entity.Play(SoundEffectManager.Instance.Sounds.canon_attack, this.gameObject);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="clip"></param>
        /// <param name="gameObject"></param>
        public void Play(AudioClip clip, GameObject gameObject = null, float delay = -1, bool loop = false)
        {
            GameObject audioSourceGO = new GameObject();

            if (gameObject == null)
            {
                ContainerManager.Instance.AddToContainer(ContainerTypes.Audio, audioSourceGO);
            }
            else
            {
                audioSourceGO.transform.SetParent(gameObject.transform);
            }

            AudioSource audioSource = audioSourceGO.AddComponent<AudioSource>();
            audioSource.volume = GameManager.Instance.Config.GameSoundEffectsVolume;
            audioSource.clip = clip;
            audioSource.loop = loop;

            audioSource.spatialize = true;
            audioSource.spatialBlend = 1;
            audioSource.minDistance = 0;
            audioSource.maxDistance = 30;
            audioSource.rolloffMode = AudioRolloffMode.Linear;

            if (delay < 0)
            {
                audioSource.Play();
            }
            else
            {
                audioSource.PlayDelayed(delay);
            }

            Sources.Add(audioSource);
        }

        /// <summary>
        /// Play the victory sound at the end of the game
        /// <example> Example(s):
        /// <code>
        ///     entity.PlayVictory();
        /// </code>
        /// </example>
        /// </summary>
        public void PlayVictory()
        {
            Play(Sounds.victory, this.gameObject);
        }

        /// <summary>
        /// Play the defeat sound at the end of the game
        /// <example> Example(s):
        /// <code>
        ///     entity.PlayVictory();
        /// </code>
        /// </example>
        /// </summary>
        public void PlayDefeat()
        {
            Play(Sounds.loose, this.gameObject);
        }

        /// <summary>
        /// Called when the object is destroyed
        /// </summary>
        void OnDestroy()
        {
            GlobalEvent.Pause.RemoveListener(Pause);
            GlobalEvent.Resume.RemoveListener(Resume);
            GlobalEvent.Victory.RemoveListener(PlayVictory);
            GlobalEvent.GameOver.RemoveListener(PlayDefeat);
        }
    }
}
