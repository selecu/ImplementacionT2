using UnityEngine;

using Btn = UnityEngine.UI.Button;
using Slider = UnityEngine.UI.Slider;

namespace v1

{
    public class AudioPlayer : MonoBehaviour
    {

        #region Inspector

        [Header("Settings")]
        [Tooltip("The audio clips array")]
        [SerializeField]
        private AudioClip[] queue;

        [Space]

        [SerializeField]
        [Tooltip("The Button Check or the Checker")]
        private Btn targetButton;

        #endregion

        private bool  casting = true, hasFinished;

        private Btn play, pause, volume;

        private AudioSource player;

        private int innerCount = 0;

        private Slider bar;

        private bool isRunning
        {
            get => player.isPlaying;
        }


        private void Awake()
        {
            player = GetComponent<AudioSource>();

            play = transform.GetChild(0).GetComponent<Btn>();

            pause = transform.GetChild(1).GetComponent<Btn>();

            volume = transform.GetChild(2).GetComponent<Btn>();

            bar = transform.GetChild(3).GetComponent<Slider>();


            play.onClick.AddListener(() => Play());
            pause.onClick.AddListener(() => Pause());
            volume.onClick.AddListener(() => Mute());

            bar.value = 0;
            player.clip = queue[innerCount];
            bar.maxValue = player.clip.length;
            targetButton.interactable = false;
        }

        private void DisableThing()
        {
            play.interactable = 
            pause.interactable = 
            volume.interactable = false;
        }

        public void StartPlaying() =>
            Play();

        public void StopPlaying() =>
            Pause();


        ///<summary>
        /// Reproduce the Audio settled
        ///</summary>
        private void Play()
        {
            if(!player.isPlaying)
                player.Play();
        }

        ///<summary>
        /// Stop the reproduction of the rolling audio.
        ///</summary>
        private void Pause()
        {
            player.Pause();
            bar.value = player.time;
        }


        ///<summary>
        /// Mute the AudioSource component
        ///</summary>
        private void Mute()
        {
            player.mute = casting;
            casting = !casting;
        }

        ///<summary>
        /// Constantly, if the player is rolling, add value to the progression bar.
        ///</summary>
        private void Update()
        {
            if(player.isPlaying)
            {
                if(isRunning)
                    bar.value += Time.deltaTime;
                

                hasFinished = ((int) bar.value == (int) bar.maxValue && targetButton);

                targetButton.interactable = (hasFinished);

                if(targetButton && hasFinished)
                    DisableThing();
            }
        }
    }
}