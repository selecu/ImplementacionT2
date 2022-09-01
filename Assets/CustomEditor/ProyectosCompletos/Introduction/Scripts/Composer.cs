using UnityEngine;
using System.Collections;
using Image = UnityEngine.UI.Image;

namespace E222
{
    public enum element
    { 
        WATER = 0,
        AIR = 1,
        FIRE = 2,
        DIRT = 3,
    }

    public class Composer : MonoBehaviour
    {

        public static Composer mini;

        private void Awake() =>
#if mini == null
            mini = this;
#endif

        #region Inspector

        [Header("Herbolaria Settings")]

        [Tooltip("Las animaciones de cada herbolaria")]
        [Space]
        [SerializeField] private element element;
        [Space]
        [SerializeField] private Animator herbalist;

        [Header("Audio Settings")]
        [Space]
        [SerializeField] private AudioClip[] herbalistClips;
        [Space]
        [SerializeField] private AudioClip[] sfx;
        [Space]
        [SerializeField] private Dialog setter;

        #endregion

        private string[] states = { "Agua", "Aire", "Fuego", "Tierra" };

        private void Start()
        {
            setter.SetChat(herbalistClips);
            setter.SetSfx(sfx);

            var state = "";

            if (element == element.WATER)
                state = states[0];
            if (element == element.AIR)
                state = states[1];
            if (element == element.FIRE)
                state = states[2];
            if (element == element.DIRT)
                state = states[3];

            herbalist.SetBool(Animator.StringToHash(state), true);
        }

        public void PlayInstruction() =>
            setter.PlaySounder(1);

        public void PlaySfx(int container) =>
            setter.PlaySfx(container);

        public void StartChat() =>
            StartCoroutine(PlayClip());

        public IEnumerator PlayClip()
        {
            setter.PlaySounder(0);
            yield return new WaitForSeconds(herbalistClips[0].length);
            GetComponent<Animator>().SetTrigger(Animator.StringToHash("Finish"));
        }

    }
}