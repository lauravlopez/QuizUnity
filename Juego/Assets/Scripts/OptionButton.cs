using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]


//Optiones que el jugador va a tener
public class OptionButton : MonoBehaviour
{
    [SerializeField] private List<int>SumaEmp = null;
    private Button n_button = null;
    private Image n_image = null; //backgorund
    private Text n_text = null;
    public int num = 0;
    public int num2 = 0;
    public int num3 = 0;
    int index = 0;


    public Option Option { get; set; }  //guarda la opcion que queremos crear
   // public ConstructProblOptionsProblems ans {get; set;}

    public void Awake()
    {
        n_button = GetComponent<Button>();
        n_image = GetComponent<Image>();
        n_text = transform.GetChild(0).GetComponent<Text>(); //buscar en el objeto que esta dentro del objeto
    
    }

    public void Construct(Option option, Action<OptionButton> callback)
    {
        num = option.empaquetamiento;            //Obtenemos los 3 valores del boton seleccionado
        num2 = option.diferencial;
        num3 = option.geometriaH;
        n_text.text = option.text;
        n_button.onClick.RemoveAllListeners();
        //n_button.enabled = true;
        Option = option;
        n_button.onClick.AddListener(() => { Click(num, num2, num3);});
      
      // n_button.onClick.AddListener(() => {returnEmp(num); returnDif(num2); returnGeoH(num3); });  //Enviamos los 3 numeros 
        n_button.onClick.AddListener(delegate     // cuando hagamos click sobre la opcion envie la respuesta y la evalue
        {
            callback(this);
        });
    }
  
    public int returnEmp()
    {
        int em = num;
        return em;
    }
  
    public int returnDif()
    {
        return num2;
    }
    public int returnGeoH()
    {
        return num3;
    }
   
    public void Click(int num, int num2, int num3)
    { 
        Debug.Log("los numeros ingresados son: Empaquetamiento= "+ num + " diferencial= "+ num2 + " Geometria del Hoyo"+ num3 );
       
    }
}
