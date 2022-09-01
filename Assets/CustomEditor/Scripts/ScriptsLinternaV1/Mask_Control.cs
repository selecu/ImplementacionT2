using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace v1
{
    public class Mask_Control : MonoBehaviour
    {
        // Start is called before the first frame update
        public GameObject[] AnimalTextures;
        public GameObject[] AnimalObjects;
        Transform Ave;
        Transform Pez;
        Vector3 posAve;
        Vector3 posPez;
        int index;

        void Awake()
        {
            Ave = gameObject.transform.GetChild(0).transform;
            Pez = gameObject.transform.GetChild(1).transform;
            posPez = Pez.position;
            posAve = Ave.position;
        }

        void Start()
        {

            //AnimalObjects = GameObject.FindGameObjectsWithTag("51320_AnimalObjects");
            //AnimalTextures = GameObject.FindGameObjectsWithTag("51320_AnimalTextures");
            index = Random.Range(0, 2);
            AnimalObjects[index].SetActive(false);
            AnimalTextures[index].SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            gameObject.transform.GetChild(0).transform.position = posAve;
            gameObject.transform.GetChild(1).transform.position = posPez;
        }
    }
}

