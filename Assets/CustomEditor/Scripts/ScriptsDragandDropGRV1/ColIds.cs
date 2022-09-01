using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;



namespace v1
{
    public class ColIds : MonoBehaviour
    {
        public string idcol;
        public DropSlotGr[] drops;
        

        // Start is called before the first frame update
        void Start()
        {
            drops = GetComponentsInChildren<DropSlotGr>();

            int nm = 20;

            foreach (var item in drops)
            {
                item.id = nm.ToString();
                nm--;
                item.idcol = idcol;
            }
             
             
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

