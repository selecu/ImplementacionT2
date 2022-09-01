using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace v1
{
    public class PaintStore_RandomCreator : MonoBehaviour
    {
        Text texto;
        public string pregunta;
        public string pregunta1;

        public GameObject Text;
        public GameObject table_Text;
        public GameObject cantidad_Text;
        Text table_texto;
        Text cantidad_texto;
        public GameObject myPrefab;
        int amount;
        [SerializeField]
        int minimo;
        [SerializeField]
        int maximo;

        // Start is called before the first frame update
        void Start()
        {
            texto = Text.GetComponent<Text>();
            table_texto = table_Text.GetComponent<Text>();
            cantidad_texto = cantidad_Text.GetComponent<Text>();

            amount = Random.Range(minimo, maximo);

            if (amount == 1)
            {
                texto.text = amount.ToString() + "  " + pregunta1;
                table_texto.text = "  " + pregunta1;
                cantidad_texto.text = amount.ToString();
            }
            else
            {
                texto.text = amount.ToString() + "  " + pregunta;
                table_texto.text = "  " + pregunta;
                cantidad_texto.text = amount.ToString();
            }


            for (int i = 0; i < amount; i++)
            {
                var Elements = Instantiate(myPrefab, transform.position, transform.rotation);
                Elements.transform.SetParent(gameObject.transform);
            }

        }
    }

}

