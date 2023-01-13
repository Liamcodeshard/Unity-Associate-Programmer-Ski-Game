using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutines : MonoBehaviour
{
    public AudioSource audio;

    public GameObject cube;
    float counter;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(PlayAnswer());
    }

    // Update is called once per frame
    void Update()
    {




    }


    public void DelayedChangeAfterAudio()
    {
        audio.Play();
        Debug.Log("Audio Played");

        Invoke("PlayAnswer", audio.clip.length);

    }


    void PlayAnswer()
    {

        Debug.Log(audio.time + " seconds later");

    }
}
