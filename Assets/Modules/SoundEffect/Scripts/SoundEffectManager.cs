using UnityEngine;
using System.Collections.Generic;
using Aloha.Events;

namespace Aloha
{
    public class SoundEffectManager : Singleton<SoundEffectManager>
    {
        public Sounds Sounds;

        public List<AudioSource> sources;

        // TODO: Sons trop forts
        // TODO: Pouvoir clean proprement un loop:true
        // TODO: Supprimer les effets une fois terminés

        // TODO: Lancer idle
        // TODO: Assassin idle
        // TODO: Bat idle
        // TODO: Canon idle


        void Awake()
        {
            sources = new List<AudioSource>();

            GlobalEvent.Pause.AddListener(Pause);
            GlobalEvent.Resume.AddListener(Resume);
            GlobalEvent.Victory.AddListener(PlayVictory);
            GlobalEvent.GameOver.AddListener(PlayDefeat);
        }

        public void Pause()
        {
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

        public void Play(AudioClip clip, GameObject gameObject, float delay = -1, bool loop = false)
        {
            GameObject audioSourceGO = new GameObject(gameObject.GetInstanceID().ToString());
            audioSourceGO.transform.position = gameObject.transform.position;
            ContainerManager.Instance.AddToContainer(ContainerTypes.Audio, audioSourceGO);

            AudioSource audioSource = audioSourceGO.AddComponent<AudioSource>();
            audioSource.volume = GameManager.Instance.Config.GameVolume;
            audioSource.clip = clip;
            audioSource.loop = loop;
            audioSource.spatialize = true;

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
