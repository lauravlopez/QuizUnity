using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class QuizUI : MonoBehaviour
{

    [SerializeField] private Text n_question = null;
    [SerializeField] private List<OptionButton> n_buttonList = null;
    private GameObject b4;
    private GameObject b5;

    public void Awake()
    {
        b4 = GameObject.FindWithTag("b4");
        b5 = GameObject.FindWithTag("b5");
    }
    public void Construct(Question q, Action<OptionButton>callback)
    {
        n_question.text = q.text;
        
       if ((q.options.Count == 5) && !(b4.activeSelf) && !(b5.activeSelf))
        {
          
            b4.SetActive(true);
            b5.SetActive(true);

        }
        else if (q.options.Count == 3 && b4.activeSelf)
            {
               
                b4.SetActive(false);
                b5.SetActive(false);
            }
        for (int n = 0; n < n_buttonList.Count - (n_buttonList.Count - q.options.Count); n++)
        {
            n_buttonList[n].Construct(q.options[n], callback);
        }

    }
}
