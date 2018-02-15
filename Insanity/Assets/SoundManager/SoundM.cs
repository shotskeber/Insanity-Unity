using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace DigitalRuby.SoundManagerNamespace
{
    public class SoundM : MonoBehaviour
    {
        private AudioSource[] SoundAudioSources;
        private AudioSource[] MusicAudioSources;

        #region singleton
        public static SoundM Instance { get { return instance; } }
        private static SoundM instance;   // GameSystem local instance

        void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }
        #endregion

        private void Start()
        {
			SoundAudioSources = new AudioSource[transform.Find("SFXSources").childCount];
			MusicAudioSources = new AudioSource[transform.Find("MusicSources").childCount];
            for (int i = 0; i < SoundAudioSources.Length; i++)
            {
                SoundAudioSources[i] = transform.Find("SFXSources").GetChild(i).GetComponent<AudioSource>();
            }
            for (int i = 0; i < MusicAudioSources.Length; i++)
            {
                MusicAudioSources[i] = transform.Find("MusicSources").GetChild(i).GetComponent<AudioSource>();
            }
        }

        public void PlaySound(string Clip)
        {
            for (int i = 0; i < SoundAudioSources.Length; i++)
            {
                if (Clip == SoundAudioSources[i].name) { PlaySound(i); }
            }
        }

        public void PlayMusic(string Clip)
        {
            for (int i = 0; i < MusicAudioSources.Length; i++)
            {
                if (Clip == MusicAudioSources[i].name) { PlayMusic(i); }
            }
        }

        public void StopMusic(string Clip)
        {
            for (int i = 0; i < MusicAudioSources.Length; i++)
            {
                if (Clip == MusicAudioSources[i].name) { StopMusic(i); }
            }
        }

        private void PlaySound(int index)
        {
            SoundAudioSources[index].PlayOneShotSoundManaged(SoundAudioSources[index].clip);
        }

        private void PlayMusic(int index)
        {
            MusicAudioSources[index].PlayLoopingMusicManaged(1.0f, 2.0f, false);
        }

        private void StopMusic(int index)
        {
            MusicAudioSources[index].Stop();
            MusicAudioSources[index].StopLoopingMusicManaged();
        }

    }
}
