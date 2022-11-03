using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using System.Linq;

namespace v1
{
    public class Managergaleria : MonoBehaviour
    {

        public List<GameObject> imagenes = new List<GameObject>();
        public int Imagen_Actual;

        //public Image Image_info;
        //public TMP_Text Text_info;

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

            imagenes[Imagen_Actual].SetActive(true);

        }
        public void ButtonNext()
        {

            Imagen_Actual++;
         
            try
            {
                if (Imagen_Actual >= imagenes.Count)
                {
                    
                    Check_Integrador.SetActive(true);
                    v1.Managersound item = FindObjectOfType<Managersound>();
                    item.correcto.Play();
                    ventana.SetActive(true);
                    Imagen_Actual = 0;

                }
                imagenes[Imagen_Actual].SetActive(true);
                imagenes[Imagen_Actual - 1].SetActive(false);
                
            }
            catch (System.Exception e)
            {
                Debug.LogWarning(e);
            }

        }

        public void ButtonPrevius()
        {
            Imagen_Actual--;
            if (Imagen_Actual < 0)
            {
                Imagen_Actual = imagenes.Count - 1;
                
            }
            imagenes[Imagen_Actual + 1].SetActive(false);
            imagenes[Imagen_Actual].SetActive(true);


        }


    }
}


   

