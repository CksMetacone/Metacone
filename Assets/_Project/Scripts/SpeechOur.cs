using System;
using GoogleTextToSpeech.Scripts.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeechOur : MonoBehaviour
{
    [SerializeField] private VoiceScriptableObject voice;
    [SerializeField] private GoogleTextToSpeech.Scripts.TextToSpeech textToSpeech;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private TextMeshProUGUI inputField;
    [SerializeField] private Text TextString;
    public SpeechRecognition speechRecognition;

    private Action<AudioClip> _audioClipReceived;
    private Action<BadRequestData> _errorReceived;

    public bool isStarted;

    public Animator animator2;

    private void Start()
    {
       // animator2 = GetComponent<Animator>();
    }

    private void Update()
    {
        
        if (audioSource.isPlaying)
        {
            isStarted = true;
            //Debug.Log("evet ");
        }
        else if(isStarted)
        {
            isStarted = false;
            speechRecognition.isMicOk = false;
            speechRecognition.StartContinuous();
            //Debug.Log("hayır ");
        }
    }

    public void PressBtn()
    {
        
        _errorReceived += ErrorReceived;
        _audioClipReceived += AudioClipReceived;
        textToSpeech.GetSpeechAudioFromGoogle(TextString.text, voice, _audioClipReceived, _errorReceived);

    }

    private void ErrorReceived(BadRequestData badRequestData)
    {
        Debug.Log($"Error {badRequestData.error.code} : {badRequestData.error.message}");
    }

    private void AudioClipReceived(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
        Debug.Log("Ani:Speak2");
        animator2.SetTrigger("Speak");

    }
}
