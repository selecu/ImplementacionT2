using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using v1;

namespace I2647
{
    public class AudioPlayerController : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private Slider slider;
        [SerializeField] private AudioClip[] playListInOrder;
        private v1.ManagerImagen managerImagen;

        private void Awake()
        {
            if(!managerImagen)
                managerImagen = FindObjectOfType<ManagerImagen>();
        }

        public void SetClipFromPlaylist() =>
            audioSource.clip = playListInOrder[managerImagen.Imagen_Actual];

        public void PlayButton()
        {
            if (audioSource.isPlaying) return;
            else if(audioSource.time != 0)
            {
                audioSource.UnPause();
                return;
            }
            audioSource.Play();
        }

        private void Update()
        {
            Handle();
        }

        public void Handle()
        {
            float value = audioSource.time / audioSource.clip.length;
            slider.value = value;
        }

        public void PauseButton()
        {
            if (!audioSource.isPlaying) return;
            audioSource.Pause();
        }

        public void CutButton()
        {
            audioSource.time = 0;
            audioSource.Stop();
        }

        public void ResetButton()
        {
            audioSource.Play();
        }
    }
}
