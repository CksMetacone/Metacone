using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//using Mono.Data.Sqlite;
//using System.Data;
using System;


public class CreatorClass
{
    //public int Id; 
    public string Name;
    public int Create;
    public float Theta;
    public float Out;
    public List<int> Conn_List = new List<int>(); //bağlantı sayisi 
    public float Out_Sum;
}

public class NeoBase : MonoBehaviour
{
    public GameObject Input_Voice_1;
    public GameObject Input_Voice_2;
    public GameObject Input_Eyes_1;
    public GameObject Input_Eyes_2;
    public GameObject Input_Eyes_N1;
    public GameObject Input_Eyes_Freq;

    public GameObject Text_Result;

    public GameObject Voice_Result;

    List<CreatorClass> Creator_Class_New = new List<CreatorClass>();//string vers.

    List<int> counts_list = new List<int>(); //Sonraki idler sayisi
    int freq = 0;
    int Nno = 0;
    string namer;
    int used_name = 0;
    int used_no_New = 0;

    public string n1_name_freq;
    string globname;
    int globalmno = 0;
    int lastfreq = 0;
    int creator = 0;


    public void Connection_Search(int x, int y)
    {
        string namers_id;
        namers_id = Creator_Class_New[x].Name + Creator_Class_New[y].Name;
        globname = namers_id;
        Debug.Log("namers_id" + namers_id);
        for (int i = 0; i < Creator_Class_New.Count; i++)
        {
            if (namers_id == Creator_Class_New[i].Name)//daha önce kullanılmış mı isim.
            {
                used_name = 1;
                used_no_New = i;
            }
        }
        if (used_name == 0)
        {
            used_no_New = Creator_Class_New.Count;
            Creator_Class_New.Add(new CreatorClass { Name = namers_id, Create = creator, Out = 20, Theta = 40 }); ;
            /*neuro.Add(GameObject.CreatePrimitive(PrimitiveType.Sphere));
            neuro[creator].transform.position = new Vector3(UnityEngine.Random.Range(-25.0f, -1.0f), UnityEngine.Random.Range(1.0f, 50.0f), UnityEngine.Random.Range(1.0f, 10.0f));//pozisyonunu verecek.
            neuro[creator].transform.localScale = new Vector3(1f, 1f, 1f); //Boyutu sabitliyor.
            neuro[creator].GetComponent<Renderer>().material.color = Color.blue;*/
            creator++;
        }
        else
        {
            used_name = 0;
        }

    }

    public int New_Search(string names, string block)
    {
        string names_id;
        names_id = names;
        if (names != "")
        {
            names_id = block + names_id;
            Debug.Log("name_id" + names_id);
            for (int i = 0; i < Creator_Class_New.Count; i++)
            {
                if (names_id == Creator_Class_New[i].Name)//daha önce kullanılmış mı isim.
                {
                    used_name = 1;
                    used_no_New = i;
                }
            }
            if (used_name == 0)
            {
                used_no_New = Creator_Class_New.Count;
                Creator_Class_New.Add(new CreatorClass { Name = names_id, Create = creator, Out = 20, Theta = 40 }); ;
                //neuro.Add(GameObject.CreatePrimitive(PrimitiveType.Sphere));
                //neuro[creator].transform.position = new Vector3(UnityEngine.Random.Range(-25.0f, -1.0f), UnityEngine.Random.Range(1.0f, 50.0f), UnityEngine.Random.Range(1.0f, 10.0f));//pozisyonunu verecek.
                //neuro[creator].transform.localScale = new Vector3(1f, 1f, 1f); //Boyutu sabitliyor.
                /*if (block == "S")
                    neuro[creator].GetComponent<Renderer>().material.color = Color.red;
                else if (block == "G")
                    neuro[creator].GetComponent<Renderer>().material.color = Color.green;
                else if (block == "N")
                    neuro[creator].GetComponent<Renderer>().material.color = Color.yellow;
                else
                    neuro[creator].GetComponent<Renderer>().material.color = Color.white;*/
                creator++;
                return 1;
            }
            else
            {
                used_name = 0;
                return 1;

            }
        }
        else
        {

            return 0;
        }

    }

    public void Defination3()
    {
        freq = 0;
        Nno = 0;
        counts_list.Clear();
        namer = Input_Voice_1.GetComponent<Text>().text;

        if (New_Search(namer, "S") == 1)
        {
            counts_list.Add(used_no_New);
        }
        namer = Input_Voice_2.GetComponent<Text>().text;
        if (New_Search(namer, "S") == 1)
        {
            counts_list.Add(used_no_New);
        }
        namer = Input_Eyes_1.GetComponent<Text>().text;
        if (New_Search(namer, "G") == 1)
        {
            counts_list.Add(used_no_New);
        }
        namer = Input_Eyes_2.GetComponent<Text>().text;
        if (New_Search(namer, "G") == 1)
        {
            counts_list.Add(used_no_New);
        }
        namer = Input_Eyes_N1.GetComponent<Text>().text;
        if (New_Search(namer, "N") == 1)
        {
            counts_list.Add(used_no_New);

        }
        n1_name_freq = Input_Eyes_Freq.GetComponent<Text>().text;

        if (n1_name_freq != "")
        {
            freq = Int16.Parse(n1_name_freq);
            //Debug.Log(freq);
        }
        else
            freq = 0;

        Debug.Log("count " + counts_list.Count);

        Connection_Search(counts_list[0], counts_list[1]);
        for (int i = 2; i < counts_list.Count; i++)
        {
            Connection_Search(used_no_New, counts_list[i]);
            Text_Result.GetComponent<Text>().text = globname;
            Debug.Log("used_no_New " + used_no_New);
            if (freq == 1)
            {
                globalmno = used_no_New;
                Debug.Log("Nno " + Nno);
            }

        }

        if (freq > 1)
        {
            for (int j = lastfreq; j < freq; j++)//bir öncekine paralel planlanarak.
            {
                Connection_Search(used_no_New, globalmno);
                Debug.Log("New2 " + used_no_New);
            }

            globalmno = used_no_New;
        }
        lastfreq = freq;


    }



    public void Connection_Thing_Search(string x, string y)
    {
        string namers_id;
        namers_id = x + y;
        Debug.Log("namers_id" + namers_id);
        for (int i = 0; i < Creator_Class_New.Count; i++)
        {
            if (namers_id == Creator_Class_New[i].Name)//daha önce kullanılmış mı isim.
            {
                used_name = 1;
                used_no_New = i;
            }
        }
        if (used_name == 0)
        {
            used_no_New = Creator_Class_New.Count;
            Creator_Class_New.Add(new CreatorClass { Name = namers_id, Create = creator, Out = 20, Theta = 40 }); ;
            /*neuro.Add(GameObject.CreatePrimitive(PrimitiveType.Sphere));
            neuro[creator].transform.position = new Vector3(UnityEngine.Random.Range(0.0f, 25.0f), UnityEngine.Random.Range(1.0f, 50.0f), UnityEngine.Random.Range(1.0f, 10.0f));//pozisyonunu verecek.
            neuro[creator].transform.localScale = new Vector3(1f, 1f, 1f); //Boyutu sabitliyor.
            neuro[creator].GetComponent<Renderer>().material.color = Color.magenta;*/
            creator++;
        }
        else
        {
            used_name = 0;
        }

    }
    public int searchsame(string n, string search)
    {
        int m = 0;
        int konum = n.IndexOf(search);
        while (konum != -1)
        {
            konum = n.IndexOf(search, konum + 1);
            m++;
        }
        return m;
    }

    string dif1;
    string dif2;
    string dif3;
    string difresult;
    string changedif1;
    string changedif2;
    string changedif;
    string changedifind2;
    public void Thinks()
    {
        int bulundu = 0;

        int difindex = 0;
        int difagain = 0;
        int difagain2 = 0;
        //int changeindex = 0;

        int changedifindex = 0;
        int changedifindex2 = 0;
        int firstsave = 0;

        n1_name_freq = Input_Eyes_Freq.GetComponent<Text>().text;
        if (n1_name_freq != "")
        {
            freq = Int16.Parse(n1_name_freq);
            Debug.Log(freq);
        }
        else
            freq = 0;
        //benzerler arasında ilişki kurulacak. 
        for (int i = 0; i < Creator_Class_New.Count; i++)// bu kısım daha önce oluşmuş mu ona bakıyor. 
        {
            if (freq == searchsame(Creator_Class_New[i].Name, "N1"))
            {

                Debug.Log("i " + i + " N " + Creator_Class_New[i].Name);
                i = Creator_Class_New.Count;
                bulundu = 1;
            }

        }
        if (bulundu == 0)//bir öncekilerden yola çıkarak karşılaştırma yapıyor. 
        {
            for (int j = 0; j < Creator_Class_New.Count; j++)
            {
                if ((freq - 1) == searchsame(Creator_Class_New[j].Name, "N1"))
                {
                    dif1 = Creator_Class_New[j].Name;
                    Debug.Log("dif1 " + dif1);
                    //S10S3G1G3N1S10S2G1G2N1S10S1G1G1N1S10G1G0N1S9G9N1S8G8N1S7G7N1S6G6N1S5G5N1S4G4N1S3G3N1S2G2N1S1G1N1

                    j = Creator_Class_New.Count;
                }
            }
            for (int k = 0; k < Creator_Class_New.Count; k++)
            {
                if ((freq - 2) == searchsame(Creator_Class_New[k].Name, "N1"))
                {
                    dif2 = Creator_Class_New[k].Name;
                    Debug.Log("dif2 " + dif2);
                    //S10S2G1G2N1S10S1G1G1N1S10G1G0N1S9G9N1S8G8N1S7G7N1S6G6N1S5G5N1S4G4N1S3G3N1S2G2N1S1G1N1
                    k = Creator_Class_New.Count;
                }
            }
            difindex = dif1.IndexOf(dif2);
            //Debug.Log("difind " + difindex);
            changedif1 = dif1.Substring(0, difindex);//S10S3G1G3N1
            //aslında hesaplanmış deil.yukarıdaki gibi hesaplanmalı.
            changedif2 = dif2.Substring(0, difindex);//S10S2G1G2N1
            Debug.Log("difind1 " + changedif1);
            Debug.Log("difind2 " + changedif2);
            //Debug.Log("dif1 " + dif1);//farkı bul. S10 aynı//S2 den S3 olmuş onu bul.
            //S10S3G1G3N1S10S2G1G2N1S10S1G1G1N1S10G1G0N1S9G9N1S8G8N1S7G7N1S6G6N1S5G5N1S4G4N1S3G3N1S2G2N1S1G1N1

            //changeindex = changedif2.IndexOf(changedif2[0], 1);//ilk S mi ?
            if (changedif2.Length == changedif1.Length)
            {
                for (int mm = 1; mm < changedif2.Length - 1; mm++)
                {
                    if ((changedif1[mm] != changedif2[mm]) && (changedif1[mm + 1] == changedif2[mm + 1]))
                    {
                        if (firstsave == 0)
                        {
                            changedif = changedif1.Substring(mm - 1, 2);
                            changedifindex = mm - 1;
                            Debug.Log("dif sub " + changedif);
                            //S3
                            //mm = changedif2.Length;
                            firstsave = 1;
                        }
                        else
                        {
                            changedifind2 = changedif1.Substring(mm - 1, 2);
                            Debug.Log("changedifind2" + changedifind2);
                            //G3
                            changedifindex2 = mm - 1;
                            mm = changedif2.Length;
                        }

                    }

                }
            }
            else
                Debug.Log("changedif eşit deil ");


            difagain = dif1.LastIndexOf(changedif);//"S3",78
            Debug.Log("difagain " + difagain);
            if (difagain > 1)
            {
                difagain2 = dif1.IndexOf("S", (difagain - 9));//78
                Debug.Log("difagain2 " + difagain2);//72
                difresult = dif1.Substring(difagain2, (difagain - difagain2));
                Debug.Log("difagaind " + difresult);
                //S4G4N1
            }



            Debug.Log("changedif " + changedif);//S3
            Debug.Log("difresult1 " + difresult.Substring(0, 2));//S4
            Debug.Log("changedif2 " + changedifind2);//G3
            Debug.Log("difresult2 " + difresult.Substring(2, 2));//G4
                                                                 //changedif1 = changedif1.Replace(changedif, difresult.Substring(0,2)) ;
                                                                 //changedif1 = changedif1.Replace(changedifind2, difresult.Substring(2, 2));

            //changedif1[changedifindex] = changedif[0];

            char[] strdizi = changedif1.ToCharArray();
            Debug.Log("strdizi " + strdizi);//S10S4G1G4N1

            strdizi[changedifindex] = difresult[0];
            strdizi[changedifindex + 1] = difresult[1];
            strdizi[changedifindex2] = difresult[2];
            strdizi[changedifindex2 + 1] = difresult[3];

            string updatechangedif1 = new string(strdizi);
            changedif1 = updatechangedif1;

            Debug.Log("changedif1 " + changedif1);//S10S4G1G4N1
            //dif1 = changedif1 + dif1; //yeni dif oluşturuluyor.
            //Debug.Log("dif1 " + dif1);
            Text_Result.GetComponent<Text>().text = changedif1;
            Connection_Thing_Search(changedif1, dif1);
            //namers_idS10S4G1G4N1S10S3G1G3N1S10S2G1G2N1S10S1G1G1N1S10G1G0N1S9G9N1S8G8N1S7G7N1S6G6N1S5G5N1S4G4N1S3G3N1S2G2N1S1G1N1
            globalmno = used_no_New;
            lastfreq = freq;
            //16
            /*
             
            */
        }



        //Debug.Log("N1_id" + Creator_Class_New[i].Name);

        //Debug.Log("n1 " + searchsame(Creator_Class_New[Creator_Class_New.Count-1].Name,"N1").ToString());
    }

    // Start is called before the first frame update
    void Start()
    {
        //Voice_Result.GetComponent<Text>().text = "Reset";
    }

    int Ezber_Flag = 0;
    int Ezber_Flag2 = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

        }
        if ((Voice_Result.GetComponent<Text>().text.IndexOf("Ezber") != -1) && (Ezber_Flag == 1))
        {
            Ezber_Flag = 0;
            Defination3();
        }
        else if ((Voice_Result.GetComponent<Text>().text.IndexOf("Ezber") == -1) && (Ezber_Flag == 0))
        {
            Ezber_Flag = 1;

        }
        if ((Voice_Result.GetComponent<Text>().text.IndexOf("Son") != -1) && (Ezber_Flag2 == 1))
        {
            Ezber_Flag2 = 0;
            Thinks();
        }
        else if ((Voice_Result.GetComponent<Text>().text.IndexOf("Son") == -1) && (Ezber_Flag2 == 0))
        {
            Ezber_Flag2 = 1;
        }
    }
}
