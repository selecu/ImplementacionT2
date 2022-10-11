using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using System.Linq;

namespace I2756
{
    public class ManagerImagen : MonoBehaviour
    {


        [System.Serializable]
        public class Contenido
        {
            public Sprite imagen;
            public AudioClip audioClip;
        }

        public List<Contenido> imagenes = new List<Contenido>();
        public int Imagen_Actual;

        public Image Image_info;
        public TMP_Text Text_info;
        public AudioSource targetAudioSource;

        [Space(20)]
        public GameObject buton_previus;
        public GameObject Check_Integrador;
        public GameObject ventana;



        // Start is called before the first frame update
        void Start()
        {
            Cambio();
            Check_Integrador.SetActive(false);
            buton_previus.SetActive(false);

        }

        // Update is called once per frame
        void Update()
        {
            if (Imagen_Actual == 1)
            {
                buton_previus.SetActive(true);
            }

            if (Imagen_Actual == 0)
            {
                buton_previus.SetActive(false);
            }
        }

        public void Cambio()
        {
            if(targetAudioSource.isPlaying)
                targetAudioSource.Stop();

            Image_info.sprite = imagenes[Imagen_Actual].imagen;
            targetAudioSource.clip = imagenes[Imagen_Actual].audioClip;

            targetAudioSource.Play();
        }
        public void ButtonNext()
        {

            Imagen_Actual++;
            if (Imagen_Actual == imagenes.Count)
            {
                Check_Integrador.SetActive(true);
                v1.Managersound item = FindObjectOfType<v1.Managersound>();
                item.correcto.Play();
                ventana.SetActive(true);
                Imagen_Actual = 0;

            }
            Cambio();




        }

        public void ButtonPrevius()
        {
            Imagen_Actual--;
            if (Imagen_Actual < 0)
            {
                Imagen_Actual = imagenes.Count - 1;

            }
            Cambio();


        }


    }
}


   

