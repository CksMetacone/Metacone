using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharScript : MonoBehaviour
{

    public GameObject webcam, canvas;
    public SpeechRecognition speechRec;
    

    private void Start()
    {
        Invoke("SpeechBaslat", 1f);
    }
    public void StartObjects()
    {
        webcam.SetActive(true);
        //speech.SetActive(true);
        canvas.SetActive(true);
        speechRec.StartContinuous();
    }

    private void SpeechBaslat()
    {
        speechRec.StartContinuous();
    }

}
