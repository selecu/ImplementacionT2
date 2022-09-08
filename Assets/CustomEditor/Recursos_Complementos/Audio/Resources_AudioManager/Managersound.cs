using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;





namespace v1
{

    public class Managersound : MonoBehaviour
    {



        public enum Temporadas
        {
            T2, T3, T4, T5, T8, T9,
            Custom
        }
        public Temporadas State;
        [Space(5)]
        [Header("sonidos de ambiente")]
        public bool sonido_Ambiente;
        public AudioSource ambiente;
        [Space(5)]
        [Header("sonidos de temporada primaria")]
        public AudioClip[] primaria_correcto;
        public AudioClip[] primaria_incorrecto;
        [Space(5)]
        [Header("sonidos de temporada secundaria")]
        public AudioClip[] secundaria_correcto;
        public AudioClip[] secundaria_incorrecto;
        [Space(5)]
        [Header("Componentes AudioSource ")]
        public AudioSource correcto;
        public AudioSource incorrecto;

        






        // Start is called before the first frame update
        void Start()
        {

            if (!sonido_Ambiente)
            {
                ambiente.enabled = false;

            }

            if (State == Temporadas.T2)
            {
                correcto.clip = primaria_correcto[0];
                incorrecto.clip = primaria_incorrecto[0];

            }
            if (State == Temporadas.T3)
            {
                correcto.clip = primaria_correcto[1];
                incorrecto.clip = primaria_incorrecto[1];
            }
            if (State == Temporadas.T4)
            {
                correcto.clip = primaria_correcto[2];
                incorrecto.clip = primaria_incorrecto[2];
            }
            if (State == Temporadas.T5)
            {
                correcto.clip = primaria_correcto[3];
                incorrecto.clip = primaria_incorrecto[3];
            }
            if (State == Temporadas.T8)
            {
                correcto.clip = secundaria_correcto[0];
                incorrecto.clip = secundaria_incorrecto[0];
            }
            if (State == Temporadas.T9)
            {
                correcto.clip = secundaria_correcto[1];
                incorrecto.clip = secundaria_incorrecto[1];
            }

        }


        // Update is called once per frame
        void Update()
        {
            
            
        }

        public void Mute()
        {
            if (ambiente.isPlaying)
            {
                ambiente.Pause();
            }
            else
            {
                ambiente.UnPause();
            }

        }

        

        
    }
}
