using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace v1
{
    public class ButtonsMusicMemory : MonoBehaviour
    {
        [SerializeField] private int id = 1;
        [SerializeField] Sprite overSprite;
        [SerializeField] Sprite normalSprite;
        [SerializeField] private AudioClip clip;
        ManagerMusicMemory manager;

        public Sprite OverSprite { get => overSprite; set => overSprite = value; }
        public Sprite NormalSprite { get => normalSprite; set => normalSprite = value; }

        // Start is called before the first frame update
        void Start()
        {
            NormalSprite = GetComponent<Image>().sprite;
            manager = FindObjectOfType<ManagerMusicMemory>();
        }

        IEnumerator waitCorrect()
        {
            yield return new WaitWhile(() => manager.AudioSource.isPlaying);
            yield return new WaitForSeconds(1);
            manager.AudioSource.clip = manager.ClipCorrecto;
            manager.AudioSource.Play();
            yield return new WaitForSeconds(1);

        }

        void compareIndex()
        {
            if (manager.UserResp != null)
            {
                if (!(manager.Niveles[manager.CurrentLevel].idOfSound[manager.UserResp.Count - 1] == manager.UserResp[manager.UserResp.Count - 1]))
                {
                    manager.CurrentLevel = 0;
                    manager.UserResp.Clear();
                    manager.AudioSource.clip = manager.ClipIncorrecto;
                    manager.AudioSource.Play();
                    manager.ventana[1].SetActive(true);
                    StartCoroutine(Waiting());
                    StartCoroutine(manager.StartNivel(manager.CurrentLevel, manager.Niveles[manager.CurrentLevel].speedDificult));
                    return;
                }

                if (manager.UserResp.Count == manager.Niveles[manager.CurrentLevel].idOfSound.Length)
                {
                    manager.UserResp.Clear();
                    manager.CurrentLevel++;
                    StartCoroutine(waitCorrect());
                    if (manager.CurrentLevel == manager.Niveles.Length)
                    {
                        print("Mundo completado");
                        manager.blockButtons(true);
                        manager.CheckButton.SetActive(true);
                        v1.Managersound item = FindObjectOfType<Managersound>();
                        item.correcto.Play();
                        manager.ventana[0].SetActive(true);
                    }
                    else
                    {
                        StartCoroutine(manager.StartNivel(manager.CurrentLevel, manager.Niveles[manager.CurrentLevel].speedDificult));
                       
                       

                    }
                }
            }

        }



        public void play()
        {
            manager.PlaySoundIndex(id);
            manager.UserResp.Add(id);
            compareIndex();

        }

        public AudioClip GetAudioClip()
        {
            return clip;
        }
        public int getId()
        {
            return id;
        }

        // Update is called once per frame
        void Update()
        {

        }

        IEnumerator Waiting()
        {
            yield return new WaitForSeconds(5);
            manager.ventana[1].SetActive(false);
            StopCoroutine(Waiting());
        }
    }
}


