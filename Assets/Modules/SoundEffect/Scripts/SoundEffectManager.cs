using UnityEngine;
using System.Collections.Generic;
using Aloha.Events;

namespace Aloha
{
    public class SoundEffectManager : Singleton<SoundEffectManager>
    {
        public Sounds Sounds;

        public List<AudioSource> sources;

        void Awake()
        {
            if (Sounds == null)
            {
                Sounds = ScriptableObject.CreateInstance<Sounds>();
            }
            sources = new List<AudioSource>();

            GlobalEvent.Pause.AddListener(Pause);
            GlobalEvent.Resume.AddListener(Resume);
            GlobalEvent.Victory.AddListener(PlayVictory);
            GlobalEvent.GameOver.AddListener(PlayDefeat);
        }

        public void Pause()
        {
            sources.RemoveAll((source) => { return (source == null); });
            foreach (AudioSource source in sources)
            {
                if (source.isPlaying == false)
                {
                    DestroyImmediate(source.gameObject);
                }
            }
            sources.RemoveAll((source) => { return (source == null); });
            foreach (AudioSource source in sources)
            {
                source.Pause();
            }
        }

        public void Resume()
        {
            foreach (AudioSource source in sources)
            {
                source.UnPause();
            }
        }

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
            audioSource.volume = GameManager.Instance.Config.GameVolume / 2;
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

            sources.Add(audioSource);
        }

        public void PlayVictory()
        {
            Play(Sounds.victory, this.gameObject);
        }

        public void PlayDefeat()
        {
            Play(Sounds.loose, this.gameObject);
        }

        void OnDestroy()
        {
            GlobalEvent.Pause.RemoveListener(Pause);
            GlobalEvent.Resume.RemoveListener(Resume);
            GlobalEvent.Victory.RemoveListener(PlayVictory);
            GlobalEvent.GameOver.RemoveListener(PlayDefeat);
        }
    }
}
