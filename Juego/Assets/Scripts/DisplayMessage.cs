using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMessage : MonoBehaviour {

    private string title = "Bienvenido";
    private string pasos = "siga estos pasos";
    public string[] questions;

    Text title1;
    Text message;
    void Start()
    {
        title1 = GetComponentInChildren<Text>();
        message = this.transform.Find("Message").gameObject.GetComponent<Text>();
    }

	void Update ()
    {
        title1.text = title;
        message.text = pasos;
	}
    void NextDisplay()
    {
        DisplayMessage
    }
}
