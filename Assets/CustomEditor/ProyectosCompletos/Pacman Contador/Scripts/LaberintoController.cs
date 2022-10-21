using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace v1.Pacmancontador
{
public class LaberintoController : MonoBehaviour
{
    

    public void End()
    {
        
            FindObjectOfType<v1.Movemet>().velocidadMovimiento = 20;
            transform.gameObject.SetActive(false);
        
    }
}
}