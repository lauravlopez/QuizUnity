using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProblemResults : MonoBehaviour {

    // Use this for initialization
    public static int empaquetamientoValue = 0;
    public static int DiferencialValue = 0;
    public static int GeometriaHoyo = 0;
    Text score;

	void Start ()
    {
        score = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        score.text = "Empaquetamiento = " + empaquetamientoValue + ", Diferencial = " + DiferencialValue +", Geometria del Hoyo = " + GeometriaHoyo;
	}
}
