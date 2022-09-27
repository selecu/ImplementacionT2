using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Regletas
{
    public class EvaluatePieceRegletasV2 : MonoBehaviour
    {
        public List<int> answers;
        public List<Material> materials;
        bool flag = true;

        void Start()
        {
            answers = new List<int>();
        }

        void Update()
        {
            if (answers.Count > 0)
            {
                GetComponent<MeshRenderer>().enabled = false;

                var temp = GetComponent<BoxCollider>();
                temp.isTrigger = true;
                temp.size = new Vector3(0.3f, 0.3f, 0.3f);
            }
        }

        void OnTriggerStay(Collider col)
        {
            if (col.gameObject.tag == "block" && flag)
            {
                foreach (int i in answers)
                {
                    if (col.gameObject.GetComponent<DragHandlerRegletas>().id == i)
                    {
                        Re.counter++;
                        flag = false;
                    }
                }
            }
        }

        public void ChangeColorStatic(int indx)
        {
            GetComponent<MeshRenderer>().material = materials[indx];
        }
        void OnTriggerExit(Collider col)
        {
            if (col.gameObject.tag == "block" && !flag)
            {
                foreach (int i in answers)
                {
                    if (col.gameObject.GetComponent<DragHandlerRegletas>().id == i)
                    {
                        Re.counter--;
                        flag = true;
                    }
                }
            }
        }
    }
}
