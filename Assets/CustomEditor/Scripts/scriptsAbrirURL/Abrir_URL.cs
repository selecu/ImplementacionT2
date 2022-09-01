using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace v1
{
    public class Abrir_URL : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        // Start is called before the first frame update
        public string URL;

        public GameObject Instruccion;
        private bool mouse_over = false;
        [SerializeField]
        GameObject CheckIntegrador;
        void Start()
        {

            CheckIntegrador.SetActive(false);
            Instruccion.SetActive(false);
        }
        public void AbrirURL()
        {
            Application.OpenURL(URL);
            CheckIntegrador.SetActive(true);

        }



        void Update()
        {

        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            mouse_over = true;
            Instruccion.SetActive(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            mouse_over = false;
            Instruccion.SetActive(false);
        }
    }


}

