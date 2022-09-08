using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Regletas
{
    public class InstantiateRegletas : MonoBehaviour
    {

        public void Instance(GameObject toInstantiate)
        {
            Instantiate(toInstantiate, new Vector3(-4, 0, 3), Quaternion.identity);
        }
    }
}

