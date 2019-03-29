using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class GameManager : MonoBehaviour {
    int suma1 = 0;
    int suma2 = 0;
    int suma3 = 0;
    [SerializeField] private float WaitTime = 0.0f;
    [SerializeField] private List<int> ListaE = null;
    [SerializeField] private List<int> ListaD = null;
    [SerializeField] private List<int> ListaG = null;
    private QuizDB nQuizDB = null;  //referencia base
    private QuizUI nQuizUI = null;   //referencia interfaz grafica

    private void Start()
    {
        nQuizDB = GameObject.FindObjectOfType<QuizDB>();  //usar la base de datos
        nQuizUI = GameObject.FindObjectOfType<QuizUI>();  //usar la interfaz grafica
        NextQuestion();
        CleanLists();
    }

    private void NextQuestion() //sacar una pregunta aleatoria y la respuesta y mandarla al construct
    {
        nQuizUI.Construct(nQuizDB.Getq(), GiveAnswer);
        
    }

    private void GiveAnswer(OptionButton optionButton)
    {
        StartCoroutine(GiveAnswerRoutine(optionButton));
        int listEmp = optionButton.returnEmp();
        int listDif = optionButton.returnDif();
        int listGeoH = optionButton.returnGeoH();

        ListaE.Add(listEmp);
        ListaD.Add(listDif);
        ListaG.Add(listGeoH);

        suma1 = ListaE.Sum();
        suma2 = ListaD.Sum();
        suma3 = ListaG.Sum();
        ProblemResults.empaquetamientoValue = suma1;
        ProblemResults.DiferencialValue = suma2;
        ProblemResults.GeometriaHoyo = suma3;
        Debug.Log("las sumas son: Empaquetamiento =" + suma1 + ", Diferencial= " + suma2 + ", Geometría del Hoyo= " + suma3);
        

    }

    private IEnumerator GiveAnswerRoutine(OptionButton optionButton)
    {
        
        yield return new WaitForSeconds(WaitTime);
        NextQuestion();

    }
    public void CleanLists()
    {
        ListaE.Clear();
        ListaD.Clear();
        ListaG.Clear();
    }

}
