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
        private Btn targetBtn;

        #endregion

        private bool slide = false, casting = true, hasFinished;

        private Btn play, pause, volume;

        private AudioSource player;

        private int innerCount = 0;

        private Slider bar;

        private void OnValidate()
        {
            player = GetComponent<AudioSource>();

            play = transform.GetChild(0).GetComponent<Btn>();

            pause = transform.GetChild(1).GetComponent<Btn>();

            volume = transform.GetChild(2).GetComponent<Btn>();

            bar = transform.GetChild(3).GetComponent<Slider>();


            play.onClick.AddListener(() => Play());
            pause.onClick.AddListener(() => Pause());
            volume.onClick.AddListener(() => Mute());
        }

        private void Start()
        {
            bar.value = 0;
            player.clip = queue[innerCount];
            bar.maxValue = player.clip.length;
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
                if(!slide)
                    bar.value += Time.deltaTime;
                

                hasFinished = ((int) bar.value == (int) bar.maxValue && targetBtn);

                targetBtn.interactable = (hasFinished);
            }
        }
    }
}