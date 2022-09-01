using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using System.Linq;

namespace v1
{
    public class ManagerImagen : MonoBehaviour
    {


        [System.Serializable]
        public class Contenido
        {

            public Sprite imagen;
            [TextArea]
            public string Info;


        }

        public List<Contenido> imagenes = new List<Contenido>();
        public int Imagen_Actual;

        public Image Image_info;
        public TMP_Text Text_info;

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

            Image_info.sprite = imagenes[Imagen_Actual].imagen;
            Text_info.text = imagenes[Imagen_Actual].Info;

        }
        public void ButtonNext()
        {

            Imagen_Actual++;
            if (Imagen_Actual == imagenes.Count)
            {
                Check_Integrador.SetActive(true);
                v1.Managersound item = FindObjectOfType<Managersound>();
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


   

