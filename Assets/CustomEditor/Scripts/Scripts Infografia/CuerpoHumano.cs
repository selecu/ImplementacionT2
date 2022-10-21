using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace v1
{
    public class CuerpoHumano : MonoBehaviour
    {

        public GameObject ventana;
        public GameObject[] objects;
        public void PlayCuerpoHumano()
        {
            objects[0].SetActive(false);
            objects[1].SetActive(true);
            objects[2].SetActive(true);
        }
        
        
        private void Start()
        {
            
        }

        public void initialcoun()
        {
            StartCoroutine(timerInteraction());
        }

        IEnumerator timerInteraction()
        {
            yield return new WaitForSeconds(60);
            v1.Managersound item = FindObjectOfType<v1.Managersound>();
            item.correcto.Play();
            ventana.SetActive(true);
            
        }



    }
}
