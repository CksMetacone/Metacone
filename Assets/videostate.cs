using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class videostate : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator mAnimator;

    public Text inp_voice_result;
    public Text inp_result;
    public TMP_Text Out_Speak;
    string St_Out_Speak;

    int Changed_Val = 5;

    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        
           

        if (mAnimator != null)
        {
            

            if (((Input.GetKeyDown(KeyCode.E)) || (inp_voice_result.text.IndexOf("Ezber") != -1))&&(Changed_Val!=0))
            {
                mAnimator.SetTrigger("TrEzber");
                Changed_Val = 0;
            }
            else if((inp_voice_result.text.IndexOf("Ezber") == -1) && (Changed_Val == 0))
            {
                Changed_Val = 5;
            }
            if (((Input.GetKeyDown(KeyCode.S))|| (inp_voice_result.text.IndexOf("Son") != -1))&& (Changed_Val != 1))
            {
                mAnimator.SetTrigger("TrSon");
                //if ((inp_result.text.IndexOf("Results") != -1))
                //
                St_Out_Speak = inp_result.text;//
                //St_Out_Speak = "S10S1G1G1";
                St_Out_Speak = St_Out_Speak.Replace("S", "\n SPEAK: ");
                St_Out_Speak = St_Out_Speak.Replace("G", "\n SYMBOL: ");
                St_Out_Speak = St_Out_Speak.Replace("N", "\n TIMES: ");
                Out_Speak.text = St_Out_Speak;
                //}


                Changed_Val = 1;
            }
            if (((Input.GetKeyDown(KeyCode.H))|| (inp_voice_result.text.IndexOf("Elma") != -1)) && (Changed_Val != 2))
            {
                mAnimator.SetTrigger("TrHappy");
                Changed_Val = 2;
            }
            /*if (((Input.GetKeyDown(KeyCode.A))|| (inp_voice_result.text.IndexOf("0") != -1)) && (Changed_Val != 3))
            {
                //mAnimator.SetTrigger("TrAngry");
                //Changed_Val = 3;
            }*/
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }

    }
}
