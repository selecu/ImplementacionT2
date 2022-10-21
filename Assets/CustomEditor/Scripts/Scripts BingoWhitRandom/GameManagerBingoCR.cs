using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace BingoCR
{
    public class GameManagerBingoCR : MonoBehaviour
    {

        [SerializeField] string[] names;
        [SerializeField] Sprite[] iconSprites;
        [SerializeField] AudioClip[] audios;
        [SerializeField] GameObject[] gb;
        //[SerializeField] GameObject check_integrador;
        [SerializeField] GameObject audioButton;
        public GameObject[] ventanas;
        public static string nameButton = "star";
        public bool isImageRandom;
        AudioSource audio;
        TMP_Text[] txt;
        List<int> values;
        int[] nextValue;
         int next = 0;
        [HideInInspector]public List<int> T;
        void Start()
        {
            StarGame();
        }
        public void StarGame()
        {
           
           // check_integrador.SetActive(false);

            for (int i = 0; i < names.Length; i++)
            {
                T.Add(i);
            }

            values = T;
            nextValue = new int[audios.Length];

            for (int i = 0; i < values.Count - 1; i++)
            {
                int rnd = Random.Range(i, values.Count);
                var random = values[rnd];
                values[rnd] = values[i];
                values[i] = random;
            }
            for (int i = 0; i < nextValue.Length; i++)
            {
                //nextValue[i] = values[i];
            }
            for (int i = 0; i < nextValue.Length - 1; i++)
            {
                int rnd = Random.Range(i, nextValue.Length);
                var random = nextValue[rnd];
                nextValue[rnd] = nextValue[i];
                nextValue[i] = random;
            }

            txt = new TMP_Text[names.Length];
            for (int i = 0; i < gb.Length; i++)
            {
                txt[i] = gb[i].GetComponentInChildren<TMP_Text>();
                txt[i].text = names[values[i]];
                if (isImageRandom)
                {
                    gb[i].GetComponent<Image>().sprite = iconSprites[values[i]];
                }
               
            }

            audio = gameObject.GetComponent<AudioSource>();
        }

        public void Verify(Button bu)
        {
            
            if (next < audios.Length)
            {
#if UNITY_EDITOR
                print("next" + " " + next);
                print("name" + " "+ nameButton);
#endif
                if (nameButton == audios[next].name)
                {
                   
                    next++;
                    print(next);
                    txt[ButtonManagerBingoCR.value - 1].text = "";
                    bu.interactable = false;

                    if (next == audios.Length)
                    {
                        audio.Stop();
                        //check_integrador.SetActive(true);
                        v1.Managersound item = FindObjectOfType<v1.Managersound>();
                        item.correcto.Play();
                        ventanas[0].SetActive(true);
                        audioButton.SetActive(false);
                    }
                  
                }
                else
                {
                                   
                    v1.Managersound item = FindObjectOfType<v1.Managersound>();
                    item.incorrecto.Play();
                    ventanas[1].SetActive(true);
                }

            }
        }
       
        public void Play()
        {
#if UNITY_EDITOR
            print("next" + next);
#endif
            audio.clip = audios[next];
#if UNITY_EDITOR
            print(audios[next].name);
#endif
            audio.Play();


        }

    
       


    }

}


