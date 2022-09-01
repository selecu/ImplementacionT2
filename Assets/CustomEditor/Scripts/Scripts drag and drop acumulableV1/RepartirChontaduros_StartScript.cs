using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace v1
{
    public class RepartirChontaduros_StartScript : MonoBehaviour
    {
        public static RepartirChontaduros_StartScript instance;
        // public List<Sprite> Images = new List<Sprite>();
        public GameObject ImageCellPrefab;
        public GameObject SlotCellPrefab;
        [SerializeField]
        GameObject ContainerGrid;
        [SerializeField]
        int objetos_instancia;


        private void Awake()
        {
            instance = this;
        }

      public void Start()
        {



            for (int i = 0; i < objetos_instancia; i++)
            {
                GameObject slot = Instantiate(SlotCellPrefab);
                slot.transform.SetParent(ContainerGrid.transform);
            }

        }



    }
}


