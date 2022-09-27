using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace I2625
{
    [System.Serializable]
    public class FrontParameters
    {
        [Header("Front Parameters")]
        public Sprite imageFront;
        [TextArea]
        public string content;
    }

    public class GameManagerCartas : MonoBehaviour
    {
        [Header("Cantidad de cartas (número par).")]
        public int numberOfCards;
        [Header("Objeto Mesa")]
        public GameObject table;
        public GameObject checkIntegrador;

        int limitCards = 100;
        int intFlag;

        [Space()]

        Image[] imgs;
        Button[] btnCards;
        SpriteState[] sprites;
        
        [Space()]

        [SerializeField] GameObject[] cards;
        [SerializeField] Sprite[] fronts;

        [Header("Targets"), Space(30)]
        [SerializeField] Image infoImageTarget;
        [SerializeField] TMP_Text infoTextTarget;
        [Space(5)]
        [SerializeField] FrontParameters[] infoSprites;
        [Space(15)]
        
        [SerializeField] Sprite backImage;
        [SerializeField] float waitTime;
        [SerializeField] float comprobationTime = 1f;

        [SerializeField] private GameObject info;


        public static float infoWaitTime;
        public static bool infoState = false;

        int[] ids;
        int zero = -1;
        int one = -1;
        bool flag = true;
        int pointCounter = 0;



        [Header("Parametrización de las cartas.")]
        [SerializeField] Vector2 cellSize;
        [SerializeField] Vector2 spacing;
        [SerializeField] int columns;

        private void OnValidate()
        {
            GridLayoutGroup layoutCards = table.transform.Find("Cards").GetComponent<GridLayoutGroup>();
            numberOfCards = table.transform.Find("Cards").transform.childCount;

            //if ((numberOfCards > 0 && numberOfCards <= limitCards && numberOfCards % 2 == 0) && (reFill))
            //{
            //    cards = new GameObject[numberOfCards];
            //    fronts = new Sprite[Mathf.RoundToInt(Mathf.Floor(numberOfCards / 2))];
            //    infoSprites = new Sprite[numberOfCards / 2];
            //}

            if (layoutCards.cellSize != cellSize || layoutCards.spacing != spacing || layoutCards.constraintCount != columns)
            {
                layoutCards.cellSize = cellSize;
                layoutCards.spacing = spacing;
                layoutCards.constraintCount = columns;
            }
        }

        void Awake()
        {
            ids = new int[numberOfCards];
            infoWaitTime = waitTime;
            intFlag = 0;

            if (cards.Length != 0)
            {
                for (int i = 0; i < cards.Length; i++)
                {
                    cards[i] = GameObject.Find("Cards").transform.GetChild(i).gameObject;
                }
            }

            if (ids.Length != 0)
            {
                for (int i = 0; i < ids.Length; i += 2)
                {
                    ids[i] = intFlag;
                    ids[i + 1] = intFlag;
                    intFlag++;
                }
            }
        }

        void Start()
        {
            Shuffle(ids);

            btnCards = new Button[cards.Length];
            sprites = new SpriteState[cards.Length];
            imgs = new Image[cards.Length];

            if (cards.Length != 0)
            {
                for (int i = 0; i < cards.Length; i++)
                {
                    btnCards[i] = cards[i].GetComponent<Button>();
                    imgs[i] = cards[i].GetComponent<Image>();
                    imgs[i].sprite = backImage;
                    sprites[i].selectedSprite = fronts[ids[i]];
                    btnCards[i].spriteState = sprites[i];
                }
            }
        }

        void Update()
        {
            if (ButtonManagercartas.state == 0 && ButtonManagercartas.idZero - 1 >= 0) imgs[ButtonManagercartas.idZero - 1].sprite = fronts[ids[(ButtonManagercartas.idZero - 1)]];
            if (ButtonManagercartas.state == 1 && ButtonManagercartas.idOne - 1 >= 0) imgs[(ButtonManagercartas.idOne - 1)].sprite = fronts[ids[(ButtonManagercartas.idOne - 1)]];
            if (ButtonManagercartas.state == 1 && ButtonManagercartas.idZero > 0 && ButtonManagercartas.idOne > 0 && flag)
            {
                flag = false;
                StartCoroutine(Check());
            }

            if (checkIntegrador != null)
                if (pointCounter == fronts.Length)
                {
                    checkIntegrador.SetActive(true);
                }
                else checkIntegrador.SetActive(false);
            else Debug.LogWarning("Hace falta referenciar el botón de checkIntegrador.");
        }

        IEnumerator Check()
        {
            Enabled(false);
            yield return new WaitForSeconds(comprobationTime);
            if (ids[ButtonManagercartas.idOne - 1] == ids[ButtonManagercartas.idZero - 1])
            {
                infoImageTarget.sprite = infoSprites[ids[(ButtonManagercartas.idZero - 1)]].imageFront;
                infoTextTarget.text = infoSprites[ids[(ButtonManagercartas.idZero - 1)]].content;
                infoState = true;
                info.SetActive(true);
                v1.Managersound item = FindObjectOfType<v1.Managersound>();
                item.correcto.Play();
                btnCards[ButtonManagercartas.idOne - 1].interactable = false;
                btnCards[(ButtonManagercartas.idZero - 1)].interactable = false;
                pointCounter++;
            } 
            else
            {
                imgs[ButtonManagercartas.idOne - 1].sprite = backImage;
                imgs[ButtonManagercartas.idZero - 1].sprite = backImage;
                btnCards[ButtonManagercartas.idOne - 1].interactable = true;
                btnCards[(ButtonManagercartas.idZero - 1)].interactable = true;
                v1.Managersound item = FindObjectOfType<v1.Managersound>();
                item.incorrecto.Play();
            }
            

            Enabled(true);
            ButtonManagercartas.idOne = -1;
            ButtonManagercartas.idZero = -1;
            flag = true;
            
        }

        void Enabled(bool active)
        {
            for(int i = 0; i < btnCards.Length; i++)
            {
                if (btnCards[i].interactable) btnCards[i].enabled = active;
            }
        }

        void Shuffle(int[] list)
        {
            for (int i = 0; i < list.Length - 1; i++)
            {
                int temp = list[i];
                int rnd = Random.Range(i, list.Length);
                list[i] = list[rnd];
                list[rnd] = temp;
            }
        }
    }
}

