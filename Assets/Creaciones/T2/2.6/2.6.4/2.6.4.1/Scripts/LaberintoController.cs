using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace I2641
{
    public class LaberintoController : MonoBehaviour
    {
        public void End()
        {
            FindObjectOfType<Movemet>().velocidadMovimiento = 20;
            transform.gameObject.SetActive(false);
        }
    }
}
