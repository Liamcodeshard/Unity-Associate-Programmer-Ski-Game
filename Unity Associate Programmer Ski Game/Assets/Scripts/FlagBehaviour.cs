using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class FlagBehaviour : MonoBehaviour
{
    public static float timer;

    public static bool started=false;

    public TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            StartTimer();
            Debug.Log("StartedUpdate");
        }
        else
        {
            //StopTimer();
            Debug.Log("Stpopped");

        }
        UpdateTimerText();

    }

    void OnTriggerEnter()
    {
        if (started)
        {
            //StartTimer();
            Debug.Log("Started");

            started = false;
        }
        else
        {
            //StopTimer();
            Debug.Log("Stpopped");
            started = true;
        }


    }

    void StartTimer()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);

    }

    void UpdateTimerText()
    {
        timerText.text = "Current Time: " + timer.ToString();
    }



    IEnumerator Timer()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
        yield return null;
    }
}
