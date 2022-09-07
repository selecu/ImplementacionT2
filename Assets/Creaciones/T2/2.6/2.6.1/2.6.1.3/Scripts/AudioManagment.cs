using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace I2613
{
    public class AudioManagment : MonoBehaviour
    {
        [SerializeField, Tooltip("Componente donde los audios serán reproducidos.")]
        private AudioSource audioSource;

        [SerializeField, Tooltip("Panel que impide que el usuario continue hasta que acabe la playlist.")]
        private GameObject panel;

        [SerializeField]
        private float delay = .5f;

        public List<AudioClip> playlistClips;

        public void AddAudioclipToList(AudioClip audioClip) =>
            playlistClips.Add(audioClip);

        public void StartPlayCoroutine() =>
            StartCoroutine("PlayAudioWithListOfSounds");

        IEnumerator PlayAudioWithListOfSounds()
        {
            if (audioSource.isPlaying)
            {
                playlistClips.Clear();
                audioSource.Stop();
                StopAllCoroutines();
                yield return null;
            }
            var target = panel ? panel : gameObject;

            target.SetActive(true);

            foreach (var item in playlistClips)
            {
                yield return new WaitUntil(() => !audioSource.isPlaying);
                audioSource.clip = item;
                audioSource.Play();
                yield return new WaitUntil(() => !audioSource.isPlaying);
                yield return new WaitForSeconds(delay);
            }

            target.SetActive(false);
            playlistClips.Clear();
        }
    }
}
