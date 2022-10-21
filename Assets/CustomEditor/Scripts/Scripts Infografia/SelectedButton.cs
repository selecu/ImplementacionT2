using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace v1
{
    public class SelectedButton : MonoBehaviour
    {
        [SerializeField] GameObject sistema, respiratorio, inmune, corazon, cerebro;
        public void TargetButton()
        {
            GameObject[] btns = GameObject.FindGameObjectsWithTag("CuerpoButton");
            GameObject[] paneles = GameObject.FindGameObjectsWithTag("Sistemas");

            for (int i = 0; i < btns.Length; i++)
            {
                btns[i].transform.GetChild(0).gameObject.SetActive(false);
            }
            for (int i = 0; i < paneles.Length; i++)
            {
                paneles[i].SetActive(false);
            }
            sistema.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(true);
            respiratorio.transform.GetChild(1).gameObject.SetActive(false);
            respiratorio.transform.GetChild(2).gameObject.SetActive(false);
            inmune.transform.GetChild(1).gameObject.SetActive(false);
            corazon.SetActive(false);
            cerebro.SetActive(false);
        }
        public void ActivePanel()
        {
            GameObject[] paneles = GameObject.FindGameObjectsWithTag("Sistemas");
            for (int i = 0; i < paneles.Length; i++)
            {
                paneles[i].SetActive(false);
            }
            sistema.SetActive(true);
            GameObject[] btns = GameObject.FindGameObjectsWithTag("RespirarButton");
            for (int i = 0; i < btns.Length; i++)
            {
                btns[i].SetActive(false);
            }
            GameObject[] menu = GameObject.FindGameObjectsWithTag("CuerpoButton");
            for (int i = 0; i < menu.Length; i++)
            {
                menu[i].transform.GetChild(0).gameObject.SetActive(false);
            }
            transform.parent.parent.GetChild(0).gameObject.SetActive(true);
            transform.parent.parent.GetChild(1).gameObject.SetActive(false);
            transform.parent.parent.GetChild(2).gameObject.SetActive(false);
        }
        public void RespiratorioButton()
        {
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(true);
            corazon.SetActive(false);
            cerebro.SetActive(false);
        }
        public void RespiratorioSuperiorButton()
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(true);
        }
        public void RespiratorioInferiorButton()
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        public void InmuneButton()
        {
            GameObject[] btns = GameObject.FindGameObjectsWithTag("CuerpoButton");
            GameObject[] paneles = GameObject.FindGameObjectsWithTag("Sistemas");

            for (int i = 0; i < btns.Length; i++)
            {
                btns[i].transform.GetChild(0).gameObject.SetActive(false);
            }
            for (int i = 0; i < paneles.Length; i++)
            {
                paneles[i].SetActive(false);
            }
            sistema.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
            respiratorio.transform.GetChild(1).gameObject.SetActive(false);
            respiratorio.transform.GetChild(2).gameObject.SetActive(false);
            corazon.SetActive(false);
            cerebro.SetActive(false);
        }
        public void InmuneButtons()
        {
            
            GameObject[] btns = GameObject.FindGameObjectsWithTag("CuerpoButton");
            GameObject[] paneles = GameObject.FindGameObjectsWithTag("Sistemas");

            for (int i = 0; i < btns.Length; i++)
            {
                btns[i].transform.GetChild(0).gameObject.SetActive(false);
            }
            for (int i = 0; i < paneles.Length; i++)
            {
                paneles[i].SetActive(false);
            }
            sistema.SetActive(true);
            transform.parent.gameObject.SetActive(false);
            transform.parent.parent.GetChild(0).gameObject.SetActive(true);
        }
        public void NerviosoButton()
        {
            GameObject[] btns = GameObject.FindGameObjectsWithTag("CuerpoButton");
            GameObject[] paneles = GameObject.FindGameObjectsWithTag("Sistemas");

            for (int i = 0; i < btns.Length; i++)
            {
                btns[i].transform.GetChild(0).gameObject.SetActive(false);
            }
            for (int i = 0; i < paneles.Length; i++)
            {
                paneles[i].SetActive(false);
            }
            sistema.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
            respiratorio.transform.GetChild(1).gameObject.SetActive(false);
            respiratorio.transform.GetChild(2).gameObject.SetActive(false);
            inmune.transform.GetChild(1).gameObject.SetActive(false);
            corazon.SetActive(false);
        }
        public void Cerebro()
        {
            GameObject[] btns = GameObject.FindGameObjectsWithTag("CuerpoButton");
            GameObject[] paneles = GameObject.FindGameObjectsWithTag("Sistemas");

            for (int i = 0; i < btns.Length; i++)
            {
                btns[i].transform.GetChild(0).gameObject.SetActive(false);
            }
            for (int i = 0; i < paneles.Length; i++)
            {
                paneles[i].SetActive(false);
            }
            sistema.SetActive(true);
            transform.parent.GetChild(0).gameObject.SetActive(true);
            transform.gameObject.SetActive(false);
        }
        public void CirculatorioButton()
        {
            GameObject[] btns = GameObject.FindGameObjectsWithTag("CuerpoButton");
            GameObject[] paneles = GameObject.FindGameObjectsWithTag("Sistemas");

            for (int i = 0; i < btns.Length; i++)
            {
                btns[i].transform.GetChild(0).gameObject.SetActive(false);
            }
            for (int i = 0; i < paneles.Length; i++)
            {
                paneles[i].SetActive(false);
            }
            sistema.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
            respiratorio.transform.GetChild(1).gameObject.SetActive(false);
            respiratorio.transform.GetChild(2).gameObject.SetActive(false);
            inmune.transform.GetChild(1).gameObject.SetActive(false);
            cerebro.SetActive(false);
        }
        public void Corazon()
        {
            GameObject[] btns = GameObject.FindGameObjectsWithTag("CuerpoButton");
            GameObject[] paneles = GameObject.FindGameObjectsWithTag("Sistemas");

            for (int i = 0; i < btns.Length; i++)
            {
                btns[i].transform.GetChild(0).gameObject.SetActive(false);
            }
            for (int i = 0; i < paneles.Length; i++)
            {
                paneles[i].SetActive(false);
            }
            sistema.SetActive(true);
            transform.parent.GetChild(0).gameObject.SetActive(true);
            transform.gameObject.SetActive(false);
        }
    }
}