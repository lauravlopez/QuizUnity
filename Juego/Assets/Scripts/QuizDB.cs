using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;


public class QuizDB : MonoBehaviour {
    [SerializeField] private List<Question> n_questionList = null;
    [SerializeField] private List<Question> n_Backup;//A lo que se acaben las preguntas volver a empezar 
    private Text n_text = null;
    int index = 0;
    private GameManager GM = null; //ProblemLists
    public Button closeButton;

    [SerializeField] public GameObject panelGO;
    [SerializeField] public GameObject Quizui;

    private void Awake()
    {
        n_Backup = n_questionList.ToList();
       
    }

  
    public Question Getq(bool remove = true) //Pregunta, y remueve la que salga de la base de datos
    {
       
        if (n_questionList.Count == 0)  // Si no quedan preguntas, restaurar
        {
            RestoreBackup();
        }
        //int index = Random.Range(0, n_questionList.Count);
        /*
        if (!remove)
            // si no queremos remover retorna a index
            return n_questionList[index];
            n_questionList.RemoveAt(index);
            */
        Question question = n_questionList[0];
        n_questionList.RemoveAt(index);    //remover la pregunta contestada de QuizDB
        return question;  
    }

    public void RestoreBackup()
    {
        n_questionList = n_Backup.ToList();

        GM = GameObject.FindObjectOfType<GameManager>();
        GM.CleanLists();
        closeButton.onClick.AddListener(CloseButton);

        panelGO.SetActive(true);
        Quizui.SetActive(false);
        Debug.Log("se acabaron las preguntas... vuelve a empezar");
       
    }

    public void CloseButton()
    {
        panelGO.SetActive(false);
        Quizui.SetActive(true);
    }

   
}
