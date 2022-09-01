using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;



namespace v1
{
    public class WordSearch_StartScript_segundo : MonoBehaviour
    {

        public static WordSearch_StartScript_segundo instance;

        //private CanvasGroup FruitSum_canvas;
        private GameObject WordSearch;

        public TextAsset[] themes;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            //FruitSum_canvas = GameObject.Find("P2_FruitSum").GetComponent<CanvasGroup>();
            //FruitSum_canvas.alpha = 0;
            //FruitSum_canvas.blocksRaycasts = false;

            WordHunt_segundo.instance.wordsSource = themes[0];
            WordHunt_segundo.instance.Setup();

            WordSearch = GameObject.Find("P1_WordSearch");
        }


        public void SecondGame()
        {
            //FruitSum_canvas.alpha = 1;
            // FruitSum_canvas.blocksRaycasts = true;
            WordSearch.SetActive(false);
        }





    }

}
