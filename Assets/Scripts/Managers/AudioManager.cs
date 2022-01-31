using UnityEngine;

namespace Manager
{
    public class AudioManager : MonoBehaviour
    {

        [SerializeField]
        private AudioClip[] _bgmsAudioClips;
        private AudioSource _bgm;
        [SerializeField]
        private AudioClip[] _sfxsAudioClips;
        private AudioSource _sfxs;

        public static AudioManager Instance;

        void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);    
            }
            _bgm = GetComponentInChildren<AudioSource>();
            _sfxs = GetComponent<AudioSource>();

            PlayBGM(0);
        }

        public void PlayBGM(int index)
        {
            _bgm.clip = _bgmsAudioClips[0];
            _bgm.Play();
        }

        public void PlaySoundEffect(int index)
        {
            _sfxs.clip = _sfxsAudioClips[index];
            _sfxs.Play();
        }

    }
}