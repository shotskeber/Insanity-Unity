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
			//AudioSource[] SoundAudioSources = GameObject.Find ("SFXSources").gameObject.GetComponentsInChildren<AudioSource> ();
			MusicAudioSources = new AudioSource[transform.Find("MusicSources").childCount];
			//AudioSource[] MusicAudioSources = GameObject.Find("MusicSources").gameObject.GetComponentsInChildren<AudioSource> ();
		
            for (int i = 0; i < SoundAudioSources.Length; i++)
            {
                SoundAudioSources[i] = transform.Find("SFXSources").transform.GetChild(i).GetComponent<AudioSource>();
            }
            for (int i = 0; i < MusicAudioSources.Length; i++)
            {
				MusicAudioSources[i] = transform.Find("MusicSources").transform.GetChild(i).GetComponent<AudioSource>();
            }
        }

        public void PlaySound(string Clip)
        {
            for (int i = 0; i < SoundAudioSources.Length; i++)
            {
				print (Clip);
				print (SoundAudioSources [i].name);
                if (Clip == SoundAudioSources[i].name) { PlaySound(i); }
            }
        }

       /* public void PlayMusic(string Clip)
        {
			print ("calledfunc");
            for (int i = 0; i < MusicAudioSources.Length; i++)
            {
				if (Clip == MusicAudioSources [i].name) {
					print ("found clip");
					PlayMusic (i);
				} else {
					print (Clip + " : " + MusicAudioSources [i].name);
				}
            }
        }*/

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

		public void PlayMusic(int index)
        {
			//print ("MusicStarted");
            MusicAudioSources[index].PlayLoopingMusicManaged(1.0f, 2.0f, false);
        }

        private void StopMusic(int index)
        {
            MusicAudioSources[index].Stop();
            MusicAudioSources[index].StopLoopingMusicManaged();
        }

    }
}
