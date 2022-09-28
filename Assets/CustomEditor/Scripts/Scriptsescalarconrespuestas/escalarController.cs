using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEditor;
using Doozy.Engine.UI;

namespace v1
{
    public class escalarController : MonoBehaviour
    {
        [Range(0,10)]
        public int playerStartLife = 3;
        [SerializeField]
        private int currentLife = 3;
        [SerializeField]
        private Animator animator;
        [SerializeField]
        private GameObject ciudades;
        [SerializeField]
        private UnityEvent whenLifeIsZero;

        private void Start()
        {
            ResetCiudades();
        }

        private void OnValidate()
        {
            CurrentLife = playerStartLife;
        }

        public int CurrentLife 
        { 
            get => currentLife;
            set
            {
                if (value <= 0) currentLife = 0;
                else currentLife = value;
            }
        }
        public UnityEvent WhenLifeIsZero { get => whenLifeIsZero; set => whenLifeIsZero = value; }

        public void DecreaseCurrentLife() =>
            CurrentLife--;

        public void ResetCurrentLife () => 
            CurrentLife = playerStartLife;

        public void ResetCiudades()
        {
            for (int i = 0; i < ciudades.transform.childCount; i++)
            {
                ciudades.transform.GetChild(i).GetComponent<Button>().enabled = true;
                ciudades.transform.GetChild(i).GetComponent<UIButton>().enabled = true;
            }


            for (int i = 0; i < ciudades.transform.childCount-1; i++)
                ciudades.transform.GetChild(i).GetComponent<Button>().interactable = false;
        }

        public void Checker(GameObject sender)
        {
            if (CurrentLife == 0)
            {
                sender.transform.parent.parent.parent.gameObject.SetActive(false);
                WhenLifeIsZero.Invoke();
            }
        }

        public void OnButtonPressed(GameObject button)
        {
            DecreaseCurrentLife();
            Checker(button);
        }
    }
}
