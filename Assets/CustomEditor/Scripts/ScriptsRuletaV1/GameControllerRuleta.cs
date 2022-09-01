using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace v1
{
    public class GameControllerRuleta : MonoBehaviour
    {
        [Header("Variables")]
        [SerializeField] private float maxDelayToStartRolling = 0.5f;
        //[SerializeField] private int numberOfTurns = 10;
        private int totalRolls;
        [SerializeField] private int minRolls = 10;
        [SerializeField] private int maxRolls = 50;
        [SerializeField] private bool runningRulet;
        [SerializeField] private bool allSpritesAreTheSame;

        [Space]
        [Header("AudioSources")]
        [SerializeField] private AudioSource audioGiroRuleta;
        [SerializeField] private AudioSource audioParoRuleta;

        [Space]
        [Header("Warning")]
        [SerializeField] private Animator warningAnimator;
        [SerializeField] private TMP_Text warningText;
        [SerializeField] private float waitTime;
        [SerializeField] private bool canAppear;
        [SerializeField] private string output;

        [Space]
        [Header("Buttons Integration")]
        [SerializeField] private GameObject buttonCheck;
        [SerializeField] private GameObject buttonIntegration;
        [SerializeField] private GameObject buuttonRuleta;

        [Space]
        [Header("Lists and Arrays")]
        [SerializeField] private AnimationClip[] animationRuletClips;
        [SerializeField] private AnimationClip[] animationWarningClips;
        [SerializeField] private List<Panel> panels;
        [SerializeField] private Sprite[] arrayCurrentSprites;

        private void Awake()
        {
            buttonCheck.SetActive(true);
            buttonIntegration.SetActive(false);

            totalRolls = 0;

            if (!canAppear)
                canAppear = true;
        }

        private void Update()
        {
            if (runningRulet)
            {
                foreach (var item in panels)
                    if (item.GetIsRolling())
                        item.SetTimeRunning(item.GetTimeRunning() + Time.deltaTime);
            }
            else
                StopCoroutine("RunRulet");
        }

        #region Coroutines
        IEnumerator RunRulet(int iteration)
        {
            runningRulet = true;
            panels[iteration].SetTimeRunning(0);
            panels[iteration].SetOffSet(Random.Range(0f, maxDelayToStartRolling));


            GameObject obj = panels[iteration].GetLinkedObj();
            Animator objAnimator = obj.GetComponent<Animator>();

            panels[iteration].SetCurrentSprite(obj.GetComponent<Image>().sprite);

            yield return new WaitForSeconds(panels[iteration].GetOffSet());
            panels[iteration].SetIsRolling(true);

            int animationClipCount = 0;

            for (int i = 0; i < animationRuletClips.Length; i++)
            {

                objAnimator.Play(animationRuletClips[i].name); //Play the "i" animation on the array 'animationClips'



                if (i == 1)
                {
                    if (panels[iteration].GetNumberOfTurns() == 1)
                    {
                        if (!audioGiroRuleta.isPlaying)
                            audioGiroRuleta.Play();
                    }
                    else
                    {
                        while (animationClipCount < panels[iteration].GetNumberOfTurns() - 1)
                        {
                            audioGiroRuleta.Play();
                            yield return new WaitForSeconds(animationRuletClips[i].length);
                            SetNewSprite(obj, iteration);
                            animationClipCount++;
                        }
                    }

                    arrayCurrentSprites[iteration] = panels[iteration].GetCurrentSprite();
                }
                else
                    yield return new WaitForSeconds(animationRuletClips[i].length);

                if (i == 0)
                    SetNewSprite(obj, iteration);
            }
            runningRulet = false;
            panels[iteration].SetIsRolling(false);
            audioParoRuleta.Play();
        }

        IEnumerator WarningTextAnimation(string textOutput)
        {
            if (canAppear)
            {
                canAppear = false;
                warningText.text = textOutput;
                warningAnimator.Play("TurnOn");

                if (waitTime >= animationWarningClips[0].length)
                    yield return new WaitForSeconds(waitTime);
                else
                    yield return new WaitForSeconds(animationWarningClips[0].length * 5);

                warningAnimator.Play("TurnOff");
                yield return new WaitForSeconds(warningAnimator.GetCurrentAnimatorStateInfo(0).length);

                canAppear = true;
            }
        }

        #endregion

        #region PublicMethods
        public void IncrementTotalRolls() =>
            totalRolls++;
        public void StartRulet()
        {
            if (!runningRulet)
            {
                for (int i = 0; i < panels.Count; i++)
                {
                    arrayCurrentSprites = new Sprite[panels.Count];
                    panels[i].SetNumberOfTurns(Random.Range(minRolls, maxRolls));

                    if (!panels[i].GetIsRolling())
                        StartCoroutine(RunRulet(i));
                }

            }
        }
        public void CheckInteraction()
        {
            if (totalRolls != 0)
            {
                output = "";
                if (allSpritesAreTheSame)
                    output = "IGUALES";
                else
                    output = "DIFERENTES";

                if (allSpritesAreTheSame || !allSpritesAreTheSame)
                    if (CheckAllSpritesAreTheSame(arrayCurrentSprites, allSpritesAreTheSame))
                    {
                        buttonCheck.SetActive(false);
                        buttonIntegration.SetActive(true);
                        buuttonRuleta.GetComponent<Button>().interactable = false;
                    }
                    else
                    {
                        output = $"Todas las imágenes deben ser {output}.";
                        StartCoroutine(WarningTextAnimation(output));
                    }
            }
        }

        #endregion

        #region PrivateMethods

        private void SetNewSprite(GameObject objectToChange, int iterationCase)
        {
            Sprite newSprite = panels[iterationCase].GetSprites()[Random.Range(0, panels[iterationCase].GetSprites().Length)];

            while (newSprite == objectToChange.GetComponent<Image>().sprite)
                newSprite = panels[iterationCase].GetSprites()[Random.Range(0, panels[iterationCase].GetSprites().Length)];

            panels[iterationCase].SetCurrentSprite(newSprite);
            objectToChange.GetComponent<Image>().sprite = panels[iterationCase].GetCurrentSprite();

        }
        private bool CheckAllSpritesAreTheSame(Sprite[] sprites, bool sameSprites)
        {
            if (sameSprites)
            {
                for (int i = 0; i < sprites.Length; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (sprites[i] != sprites[j])
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                for (int i = 0; i < sprites.Length; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (sprites[i] == sprites[j])
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }

        #endregion
    }

    #region Class

    [System.Serializable]
    public class Panel
    {
        [SerializeField] private GameObject linkedObj;
        [SerializeField] private Sprite currentSprite;
        
        [Space]
        [SerializeField] private int numberOfTurns;
        [SerializeField] private float timeRunning;
        [SerializeField] private bool isRolling;

        [Header("Sprites To Renderer")]
        [SerializeField] private Sprite[] sprites;

        private float offSetStart;

        #region Setters

        public void SetOffSet(float offSetStart) =>
            this.offSetStart = offSetStart;
        public void SetTimeRunning(float timeRunning) =>
            this.timeRunning = timeRunning;
        public void SetIsRolling(bool isRolling) =>
            this.isRolling = isRolling;
        public void SetCurrentSprite(Sprite currentSprite) =>
            this.currentSprite = currentSprite;
        public void SetNumberOfTurns(int numberOfTurns)
        {
            if (numberOfTurns < 0)
                Debug.LogError("El número de vueltas debe ser mayor que cero.");
            else
                this.numberOfTurns = numberOfTurns;
        }

        #endregion
        
        #region Getters

        public float GetOffSet() =>
            offSetStart;
        public GameObject GetLinkedObj() =>
            linkedObj;
        public Sprite[] GetSprites() =>
            sprites;
        public float GetTimeRunning() =>
            timeRunning;
        public bool GetIsRolling() =>
            isRolling;
        public Sprite GetCurrentSprite() =>
            currentSprite;
        public int GetNumberOfTurns() =>
            numberOfTurns;

        #endregion
    }

    #endregion
}
