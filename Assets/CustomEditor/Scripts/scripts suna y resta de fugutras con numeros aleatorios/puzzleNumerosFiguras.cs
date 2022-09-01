using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class puzzleNumerosFiguras : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int numMin;
    [SerializeField] int numMax;

    [SerializeField] GameObject contenedor1;
    [SerializeField] GameObject contenedor2;
    [SerializeField] GameObject centena;
    [SerializeField] GameObject decena;
    [SerializeField] GameObject unidadMil;
    [SerializeField] GameObject unidad;
    [SerializeField] TMP_Text texto1;
    [SerializeField] TMP_InputField input;
    [SerializeField] GameObject check;
    [SerializeField] GameObject checkIntegrador;


    string resultado;
    void rellenarContenedor(GameObject cont,TMP_Text txt,bool conInput)
    {
        int numeroMil = Random.Range(numMin, numMax);
        int numeroCen = Random.Range(numMin, numMax);
        int numeroDec = Random.Range(numMin, numMax);
        int numeroUni = Random.Range(numMin, numMax);
       
        for (int i = 0; i < numeroCen; i++)
        {
            GameObject obj = Instantiate(centena);
            obj.SetActive(true);
            obj.GetComponent<Image>().SetNativeSize();
            obj.transform.SetParent(cont.transform);
            obj.transform.localScale = new Vector3(1,1,1);
        }
        for (int i = 0; i < numeroMil; i++)
        {
            GameObject obj = Instantiate(unidadMil);
            obj.transform.SetParent(cont.transform);
            obj.GetComponent<Image>().SetNativeSize();
            obj.SetActive(true);
            obj.transform.localScale = new Vector3(1, 1, 1);

        }
        for (int i = 0; i < numeroUni; i++)
        {
            GameObject obj = Instantiate(unidad);
            obj.transform.SetParent(cont.transform);
            obj.GetComponent<Image>().SetNativeSize();
            obj.SetActive(true);
            obj.transform.localScale = new Vector3(1, 1, 1);

        }
        for (int i = 0; i < numeroDec; i++)
        {
            GameObject obj = Instantiate(decena);
            obj.transform.SetParent(cont.transform);
            obj.GetComponent<Image>().SetNativeSize();
            obj.SetActive(true);
            obj.transform.localScale = new Vector3(1, 1, 1);

        }
        string mensaje = "" + numeroMil + "" + numeroCen + "" + numeroDec + "" + numeroUni;
        if (txt != null)
        {
            txt.text = mensaje;
        }
        if (conInput)
        {
            resultado = mensaje;
            //Debug.Log(resultado);
        }
    }

    public void checkInput()
    {
        if (input.text == resultado)
        {
            checkIntegrador.SetActive(true);
            check.SetActive(false);
        }
    }

    void Start()
    {
        checkIntegrador.SetActive(false);
        check.SetActive(true);
        rellenarContenedor(contenedor1,texto1,false);
        rellenarContenedor(contenedor2, null, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
