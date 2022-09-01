using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

namespace v1
{
    public class AnswersJourney : MonoBehaviour
    {
        //---------------------- Class Fields ----------------------//

        [SerializeField, Tooltip("The button object to integrate the game")] private GameObject buttonIntegrador;
        [SerializeField, Tooltip("Question where the game is happening")]
        private int actualQuestion;
        //This class field is used to access to the especific event to invoke the EventSystem asociated to the answer.
        private int answersIndex;
        //List of SetUpQuestions to asign the properties
        public List<SetUpQuestion> questionProps;

        //---------------------- Methods ----------------------//

        private void Start()
        {
            questionProps[0].SelfSetUp();
            buttonIntegrador.SetActive(false);
        }

        [ContextMenu("StartParamenters")] //Used just to whatch if the code is running
        public void SendShowIndex() =>
            questionProps[0].SelfSetUp();

        //Choose one question to show on the UI by an index (because is a list, and need to accest to that element)
        //This element is necesary on the answer EVENT SYSTEM to change between questions when you press 
        public void SendShowIndex(int index)
        {
            questionProps[index].SelfSetUp();
            this.ActualQuestion = index;
        }
        public void SendShowIndexActualQuestion() =>
            questionProps[actualQuestion].SelfSetUp();

        public int QuestionIndex
        {
            get { return actualQuestion; }
        }

        public int AnswersIndex
        {
            get { return answersIndex; }
        }
        public int ActualQuestion
        {
            get { return actualQuestion; }
            set { actualQuestion = value; }
        }

        //Agregar en el orden siguiente orden los métodos en el OnClick de cada Button...
        
        //1)
        public void SetAnswersIndex(int answersIndex) =>
            this.answersIndex = answersIndex;

        //2)
        public void InvokeEventFromAnswer() =>
            questionProps[actualQuestion].Answers[answersIndex].EventSystem.Invoke();
        //Esto permite acceder a cada UnityEvent creado en las respectivas preguntas para
        //crear el requerimiento de cada respuesta.
    }

    [System.Serializable]
    public class AnswerClass
    {
        //---------------------- Class Fields ----------------------//
        [Header("Answer Parameters")]
        [SerializeField, Tooltip("TextMeshPro relative to the answer that you want to show on UI")]
        private TMP_Text TMP_linked;

        [SerializeField, Space(5), TextArea(), Tooltip("Answer for the user")]
        private string answer;

        [SerializeField, Space(30), Tooltip("This UnityEvent is used to asign specific events when the user choose this answer")]
        private UnityEvent eventSystem;

        //---------------------- Properties, Setters & Getters ----------------------//
        public string Answer
        {
            get { return answer; }
            set { answer = value; }
        }
        public TMP_Text TMPLinked
        {
            get { return TMP_linked; }
            set { TMP_linked = value; }
        }
        public UnityEvent EventSystem
        {
            get { return eventSystem; }
        }


        //---------------------- Methods Fields ----------------------//
        public void SetAnswer() =>
            TMPLinked.text = Answer;
    }

    [System.Serializable]
    public class SetUpQuestion
    {
        //---------------------- Class Fields ----------------------//

        [Header("Question properties")]

        [SerializeField, Tooltip("TextMeshPro relative to the question that you want to show on UI")]
        private TMP_Text textLinkedQuestion;

        [SerializeField, Tooltip("Sprite where the question is reflected")]
        private Sprite questionSpriteBase;

        [Space(15)]
        [SerializeField, Tooltip("Question that the user is going to answer"), TextArea()]
        private string question;

        [Space(25)]
        [SerializeField, Header("Answers for the user")]
        private List<AnswerClass> answers;

        //---------------------- Properties, Setters & Getters ----------------------//

        public string Question
        {
            get { return question; }
            set { question = value; textLinkedQuestion.text = value; }
        }

        public Sprite QuestionBackGround
        {
            get { return questionSpriteBase; }
            set { questionSpriteBase = value; }
        }

        public void SelfSetUp()
        {
            this.Question = question;

            for (int i = 0; i < answers.Count; i++)
                answers[i].SetAnswer();
        }
        public List<AnswerClass> Answers
        {
            get { return answers; }
        }

    }
}
