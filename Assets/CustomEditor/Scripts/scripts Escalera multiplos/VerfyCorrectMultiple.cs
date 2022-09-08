using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

namespace v1
{ 

[System.Serializable]
class Levels{
    [SerializeField] public GameObject[] botones;
}
public class VerfyCorrectMultiple : MonoBehaviour
{
    [SerializeField] private Levels[] niveles;
    [SerializeField] private GameObject checkButton;
    [SerializeField] private int multiplo;
    [SerializeField] private Sprite spriteCorrect;
    [SerializeField] private TMP_Text titulo;
        public GameObject[] ventana;
    private int cont;
    private int correctas;
    private int nivelActual;



    public Sprite SpriteCorrect { get => spriteCorrect; set => spriteCorrect = value; }
    public int Cont { get => cont; set => cont = value; }


    // Start is called before the first frame update
    void Start()
    {
        nivelActual = 0;
        
        if (multiplo == 0)
        {
            multiplo = Random.Range(2, 10);              
        }
        titulo.text += $"{multiplo}";
        escalarNivel();

    }

    void blockButtons()
        {
            var lista = FindObjectsOfType<MultipleButtoms>().ToList();
            foreach (var item in lista)
            {
                item.GetComponent<Button>().interactable = false;
            }
        }

    void escalarNivel()
    {
        bool flag = false;
        foreach (var boton in niveles[nivelActual].botones)
        {
            boton.SetActive(true);
            int random = Random.Range(1, 100);
            if (random % multiplo == 0) {               
                flag = true;
                boton.GetComponent<MultipleButtoms>().Correct = true;
            }
            var child = boton.transform.GetChild(0);
            child.GetComponent<TMP_Text>().text = random.ToString();
        }
        if (!flag)
        {
            int size = niveles[nivelActual].botones.Length;
            int randomMult = Random.Range(1, 13) * multiplo;
            var btnRandom = niveles[nivelActual].botones[Random.Range(0, size)];
            btnRandom.GetComponent<MultipleButtoms>().Correct = true;
            var childRandom = btnRandom.transform.GetChild(0);
            childRandom.GetComponent<TMP_Text>().text = randomMult.ToString();
        } 
        nivelActual++;
    }

    public void click()
    {
       
        if (nivelActual >= niveles.Length )
        {
            checkButton.SetActive(true);
            v1.Managersound item = FindObjectOfType < Managersound>();
            item.correcto.Play();
                ventana[0].SetActive(true);

            blockButtons();
        }
        else
        {
            escalarNivel();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
}
