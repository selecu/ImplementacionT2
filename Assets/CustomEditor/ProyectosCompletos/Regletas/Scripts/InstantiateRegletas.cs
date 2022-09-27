using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Regletas
{    
    public class InstantiateRegletas : MonoBehaviour
    {
        public Vector3 spawnPointRegletas;
        public void Instance(GameObject toInstantiate)
        {
            Instantiate(toInstantiate, spawnPointRegletas, Quaternion.identity);
        }
    }
}

