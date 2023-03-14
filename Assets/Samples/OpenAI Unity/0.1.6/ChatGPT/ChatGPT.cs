using UnityEngine;
using UnityEngine.UI;
using System;
namespace OpenAI
{
    public class ChatGPT : MonoBehaviour
    {
        [SerializeField] private InputField inputField;
        [SerializeField] private Button button;
        [SerializeField] private Text textArea;
        [SerializeField] public Text textInput;
        [SerializeField] public Text textInput2;

        [SerializeField] public Button SpeechToText;

        private OpenAIApi openai = new OpenAIApi();

        private string userInput;
        private string Instruction = "Act as a random stranger in a chat room and reply to the questions.\nQ: ";

        private void Start()
        {
            button.onClick.AddListener(SendReply);
        }

        public void SendNow()
        {
             SendReply();
        }

        private async void SendReply()
        {
            int Count = 0;
            string test= textInput2.text;
            //userInput = inputField.text;
            userInput = textInput.text;
            Instruction += $"{userInput}\nA: ";
            
            textArea.text = "...";
            textInput.text = "...";
            inputField.text = "";

            bool isValid = int.TryParse(test, out Count);

            if (isValid)
            {
                // parsing was successful
            }

            
            button.enabled = false;
            inputField.enabled = false;
            
            // Complete the instruction
            var completionResponse = await openai.CreateCompletion(new CreateCompletionRequest()
            {
                Prompt = Instruction,
                Model = "text-davinci-003",
                MaxTokens = 128
            });

            if (completionResponse.Choices != null && completionResponse.Choices.Count > 0)
            {
                Count++;
                textInput2.text = Count.ToString();
                textArea.text = completionResponse.Choices[0].Text;
                Instruction += $"{completionResponse.Choices[0].Text}\nQ: ";

                SpeechToText.onClick.Invoke();
            }
            else
            {
                Debug.LogWarning("No text was generated from this prompt.");
            }

            button.enabled = true;
            inputField.enabled = true;
        }
    }
}
