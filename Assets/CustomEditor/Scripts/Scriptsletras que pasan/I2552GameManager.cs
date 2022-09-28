using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace v1
{
    public class I2552GameManager : MonoBehaviour
    {
        [SerializeField] private string word = "PURPURA";
        [SerializeField] private TMP_Text textUser;
        [SerializeField] private GameObject checkIntegrador;
        [SerializeField] private AudioClip correctSound;
        [SerializeField] private AudioClip incorrectSound;

        public static int frecuency = 3;
        public static string userWord;
        public static int currectStepLetter = 0;
        private static int flag = 0;
        public static char[] wordInCharacters;
        public static bool gameRunning;
        public static float minSpeed = .1f;
        public static float maxSpeed = .6f;
        private static string allLetters = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";

        private void Start()
        {
            currectStepLetter = 0;
            flag = 0;
            userWord = "";
            gameRunning = true;
            checkIntegrador.SetActive(false);
            SetWordToCharacter(word);
        }

        private void Update()
        {
            if (textUser.text != userWord)
                textUser.text = userWord;
            if (!gameRunning)
                checkIntegrador.SetActive(true);
        }

        public void SetWordToCharacter(string inputString)
        {
            wordInCharacters = new char[inputString.Length];

            for (int i = 0; i < wordInCharacters.Length; i++)
                wordInCharacters[i] = inputString[i];
        }

        public static string ChooseOneRandomLetter(int showLetterOnStep)
        {
            string letter = "";
            flag++;
            if (currectStepLetter < wordInCharacters.Length)
            {
                gameRunning = true;
                if (flag < showLetterOnStep) letter = allLetters[Random.Range(0, allLetters.Length)].ToString();
                else
                {
                    letter = wordInCharacters[currectStepLetter].ToString();
                    flag = -1;
                }
            }
            else gameRunning = false;
            return letter;
        }

        public void CheckClickButton(GameObject _GameObject)
        {
            if (_GameObject.GetComponentInChildren<TMP_Text>().text == wordInCharacters[currectStepLetter].ToString())
            {
                transform.GetComponent<AudioSource>().clip = correctSound;
                transform.GetComponent<AudioSource>().Play();

                userWord += wordInCharacters[currectStepLetter].ToString();
                _GameObject.transform.GetComponent<Button>().interactable = false;
                currectStepLetter++;
            }
            else
            {
                transform.GetComponent<AudioSource>().clip = incorrectSound;
                transform.GetComponent<AudioSource>().Play();
            }
        }
    }
}
