using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using v1;

namespace v1
{
    public class GameManagerBingo : MonoBehaviour
    {
        [SerializeField] string[] names;
        [SerializeField] AudioClip[] audios;
        [SerializeField] GameObject[] gb;
        [SerializeField] GameObject exit;
        [SerializeField] GameObject check_integrador;
        [SerializeField] GameObject audioButton;
        public GameObject[] ventanas;


        AudioSource audio;
        TMP_Text[] txt;
        int[] values;
        int[] nextValue;
        int next = 0;

        void Start()
        {
            check_integrador.SetActive(false);
            values = new int[] {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17};
            nextValue = new int[9];
            for (int i = 0; i < values.Length - 1; i++)
            {
                int rnd = Random.Range(i, values.Length);
                var random = values[rnd];
                values[rnd] = values[i];
                values[i] = random;
            }
            for (int i = 0; i < 9; i++)
            {
                nextValue[i] = values[i];
            }
            for (int i = 0; i < nextValue.Length - 1; i++)
            {
                int rnd = Random.Range(i, nextValue.Length);
                var random = nextValue[rnd];
                nextValue[rnd] = nextValue[i];
                nextValue[i] = random;
            }

            txt = new TMP_Text[9];
            for (int i = 0; i < gb.Length; i++)
            {
                txt[i] = gb[i].GetComponentInChildren<TMP_Text>();
                txt[i].text = names[values[i]];
            }

            audio = gameObject.GetComponent<AudioSource>();
        }

        void Update()
        {
            if (next == 9)
            {
                exit.SetActive(true);
                audioButton.SetActive(false);
            }
            if (next < 9)
            {
                if (values[ButtonManagerBingo.value - 1] == nextValue[next])
                {
                    next++;
                    txt[ButtonManagerBingo.value - 1].text = "";
                }
            }
        }

        public void Play()
        {
            audio.clip = audios[nextValue[next]];
            audio.Play();
        }

        public void Exit()
        {
            exit.SetActive(false);
            check_integrador.SetActive(true);
            v1.Managersound item = FindObjectOfType<Managersound>();
            item.correcto.Play();
            ventanas[0].SetActive(true);

        } 
    }
}


