using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace v1
{
    public class SliderTexto_Control : MonoBehaviour
    {
        [SerializeField]
        GameObject Checkintegrador;
        [SerializeField]
        float tiepodespera;

        // Start is called before the first frame update
        void Start()
        {

            Checkintegrador.SetActive(false);

        }

        // Update is called once per frame
        void Update()
        {
            tiepodespera -= Time.deltaTime;
            if (tiepodespera < 0)
            {
                Checkintegrador.SetActive(true);
            }
        }


    }

}

