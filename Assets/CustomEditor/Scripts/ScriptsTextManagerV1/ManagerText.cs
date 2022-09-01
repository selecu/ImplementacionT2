using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using System.Linq;


namespace v1
{
    public class ManagerText : MonoBehaviour
    {


        [System.Serializable]
        public class Contenido
        {
            public Sprite imagen;
            [TextArea]
            public string Info;
            public AudioClip audioClip;

        }

        public List<Contenido> Dialogo;
        public int Imagen_Actual;



        public Image Image_info;
        public TMP_Text Text_info;
        public AudioSource Audio_info;
        public GameObject Buttonnext;
        public float VL_Text;

        [Space(20)]
        public GameObject Mi_Check;
        public GameObject Check_Integrador;







        // Start is called before the first frame update
        void Start()
        {


            StartCoroutine(Spera());
            Buttonnext.SetActive(false);
            Check_Integrador.SetActive(false);





        }

        // Update is called once per frame
        void Update()
        {
            if (!Audio_info.isPlaying)
            {
                Buttonnext.SetActive(true);
            }
        }

        public void Cambio()
        {
            StopAllCoroutines();
            StartCoroutine(sperainicio(Dialogo[Imagen_Actual].Info));
            Image_info.sprite = Dialogo[Imagen_Actual].imagen;
            Audio_info.clip = Dialogo[Imagen_Actual].audioClip;
            Audio_info.Play();
            Buttonnext.SetActive(false);

        }
        public void ButtonNext()
        {


            if (Imagen_Actual == Dialogo.Count - 1)
            {

                Mi_Check.SetActive(false);
                Check_Integrador.SetActive(true);

#if UNITY_EDITOR

                Debug.Log("<color=red> seacabaron los dialogos ❤  </color> ");
#endif




            }
            else if (Imagen_Actual <= Dialogo.Count - 1)
            {
                Imagen_Actual++;
                Cambio();



            }

        }

        IEnumerator sperainicio(string Imagen_Actual)
        {
            Text_info.text = "";
            float v = Dialogo[this.Imagen_Actual].audioClip.length / Dialogo[this.Imagen_Actual].Info.Length;
            foreach (char letter in Imagen_Actual.ToCharArray())
            {
                Text_info.text += letter;

                yield return new WaitForSeconds(v);

            }

        }

        IEnumerator Spera()
        {
            yield return new WaitForSeconds(1);
            Cambio();
        }





    }



}