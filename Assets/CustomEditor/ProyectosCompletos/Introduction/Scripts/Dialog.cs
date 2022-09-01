using UnityEngine;

namespace E222
{
    public class Dialog : MonoBehaviour
    {
        [SerializeField] private AudioSource[] sounders;

        public AudioSource[] sfxContainers;

        private static AudioSource sounder;

        private static Dialog reproducer;

        private void Awake()
        {
            sounder = GetComponent<AudioSource>();
            reproducer = this;
        }

        private void Start() =>
            sounder = GetComponent<AudioSource>();
            

        public void SetChat(AudioClip[] audioClip)
        {
            for(int i = 0; i < audioClip.Length; i++)
                sounders[i].clip = audioClip[i];
        }

        public void SetSfx(AudioClip[] audioClip)
        {
            for(int i = 0; i < audioClip.Length;i++)
                sfxContainers[i].clip = audioClip[i];
        }

        public void PlaySounder(int id) =>
            sounders[id].Play();

        public void PlaySfx(int id) =>
            sfxContainers[id].Play();


        public static void ReproduceAudio(AudioClip clip)
        {
            try
            {
                sounder.clip = clip;
                sounder.Play();
            }
            catch (System.NullReferenceException)
            {
                reproducer.Awake();
            }
            finally
            {
                Dialog.sounder.clip = clip;
                sounder.Play();
            }
        }
    }
}