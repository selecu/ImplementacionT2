using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;



namespace v1
{
    [System.Serializable]
    class Nivele
    {
        public int[] idOfSound;
        public float speedDificult;
    }


    public class ManagerMusicMemory : MonoBehaviour
    {
        [SerializeField] private float correctDelay;
        [SerializeField] Nivele[] niveles;
        [SerializeField] private List<int> userResp;
        [Space(10)]
        [SerializeField] GameObject checkButton;
        [SerializeField] AudioClip clipCorrecto;
        [SerializeField] AudioClip clipIncorrecto;
        AudioSource audioSource;
        List<ButtonsMusicMemory> musicButtoms;
        int currentLevel = 0;

        public List<int> UserResp { get => userResp; set => userResp = value; }
        internal Nivele[] Niveles { get => niveles; set => niveles = value; }
        public int CurrentLevel { get => currentLevel; set => currentLevel = value; }
        public AudioSource AudioSource { get => audioSource; set => audioSource = value; }
        public AudioClip ClipIncorrecto { get => clipIncorrecto; set => clipIncorrecto = value; }
        public AudioClip ClipCorrecto { get => clipCorrecto; set => clipCorrecto = value; }
        public float CorrectDelay { get => correctDelay; set => correctDelay = value; }
        public GameObject CheckButton { get => checkButton; set => checkButton = value; }
        public GameObject[] ventana;


        // Start is called before the first frame update
        [ContextMenu("Start")]
        void Start()
        {
            musicButtoms = FindObjectsOfType<ButtonsMusicMemory>().ToList();
            AudioSource = GetComponent<AudioSource>();
            StartCoroutine(StartNivel(CurrentLevel, Niveles[0].speedDificult));
        }

        public void blockButtons(bool flag)
        {
            foreach (var item in musicButtoms)
            {
                item.GetComponent<Button>().interactable = !flag;
            }
        }

        public void PlaySoundIndex(int indexSound)
        {
            AudioClip tempClip = null;
            var buttonMusic = findMusicButtonById(indexSound);
            if (buttonMusic != null)
            {
                AudioSource.clip = buttonMusic.GetAudioClip();
                tempClip = buttonMusic.GetAudioClip();
            }
            AudioSource.clip = tempClip;
            AudioSource.Play();
        }
        ButtonsMusicMemory findMusicButtonById(int index)
        {
            foreach (var item in musicButtoms)
            {
                if (item.getId() == index)
                {
                    return item;
                }
            }
            return null;
        }
        public IEnumerator StartNivel(int indexLevel, float difficult)
        {
            yield return new WaitWhile(() => audioSource.isPlaying);
            blockButtons(true);
            yield return new WaitForSeconds(correctDelay);
            if (indexLevel < Niveles.Length)
            {
                for (int i = 0; i < Niveles[indexLevel].idOfSound.Length; i++)
                {
                    int ind = Niveles[indexLevel].idOfSound[i];
                    var buttonMusic = findMusicButtonById(ind);
                    buttonMusic.GetComponent<Image>().sprite = buttonMusic.OverSprite;
                    PlaySoundIndex(ind);
                    yield return new WaitForSeconds(AudioSource.clip.length + difficult);
                    buttonMusic.GetComponent<Image>().sprite = buttonMusic.NormalSprite;
                    //print(buttonMusic.name);

                }
            }
            blockButtons(false);
        }


    }
}


