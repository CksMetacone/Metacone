using System;
using GoogleTextToSpeech.Scripts.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GoogleTextToSpeech.Scripts.Example
{
    public class TextToSpeechExample : MonoBehaviour
    {
        [SerializeField] private VoiceScriptableObject voice;
        [SerializeField] private TextToSpeech textToSpeech;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private TextMeshProUGUI inputField;
        [SerializeField] private Text TextString;

        Animator animator2;
        
        private Action<AudioClip> _audioClipReceived;
        private Action<BadRequestData> _errorReceived;
        
        public void PressBtn()
        {

            animator2 = GetComponent<Animator>();

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

            Debug.Log("Ani:Speak");
            animator2.SetTrigger("Speak");

            audioSource.Play();
        }
    }
}
