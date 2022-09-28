using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class QuestionAndAnswers 
{
    public string Pregunta;
    //public int RespuestaCorrecta;
    public respuestas[] respuestas;


}

[System.Serializable]
public class respuestas
{
    public string solucion;
    public bool correcta;

}