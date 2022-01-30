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
            _bgm = GetComponent<AudioSource>();
            _sfxs = GetComponent<AudioSource>();

        }

        public void PlaySoundEffect(int index)
        {
            _sfxs.clip = _sfxsAudioClips[index];
            _sfxs.Play();
        }

    }
}