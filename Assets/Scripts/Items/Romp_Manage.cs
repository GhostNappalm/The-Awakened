using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Romp_Manage : MonoBehaviour
{

    public string hexadecimalColor = "#44CCF1";
    Color celestial_blue;
    
    public string red_hexadec = "#FF0000";
    Color red;

    public string green_hexadec = "#00D901";
    Color green;


    public TextMeshProUGUI text_1;
    public TextMeshProUGUI text_2;
    public TextMeshProUGUI text_3;
    public TextMeshProUGUI text_4;
    public TextMeshProUGUI tent_count;
    public TextMeshProUGUI V_F_text;

    public GameObject Failed;
    public GameObject Romp_1;
    public GameObject TutorialImage;
    public GameObject Istruzioni;
    public GameObject block;

    private AudioSource Ad_S;
    public AudioClip buttonFX;
    public AudioClip successoFX;
    public AudioClip fallimentoFX;


    public int counter = 4;

    public Image line_1;
    public Image line_2;
    public Image line_3;
    public Image line_3_1;
    public Image line_3_2;
    public Image line_3_3;
    public Image line_4;
    public Image line_5;
    public Image line_6;
    public Image line_7; 
    public Image line_8; 
    public Image line_9; 
    public Image line_10; 
    public Image line_11; 
    public Image V_F_box;  

    public void Start()
    {
     ColorUtility.TryParseHtmlString(hexadecimalColor, out celestial_blue);
     ColorUtility.TryParseHtmlString(red_hexadec, out red);
     ColorUtility.TryParseHtmlString(green_hexadec, out green);

     Ad_S = GetComponent<AudioSource>();
    }

    public void Info()
    {
        if(GameObject.Find("TutorialImage")==null)
        {
            TutorialImage.SetActive(true);
            Istruzioni.SetActive(true);
        }
        else
        {
            TutorialImage.SetActive(false);
            Istruzioni.SetActive(false);
        }
    }

    public void Btn_Pressed_1()
    {
        Ad_S.clip = buttonFX;
        Ad_S.Play();
        if (text_1.text == "0")
        {
            text_1.text = "1";
            line_1.color = green;
            line_5.color = red;
        }
        else
        {
            text_1.text = "0";
            line_1.color = red;
            line_5.color = green;

        }
        Decre();
        Or_1();
    }


    public void Btn_Pressed_2()
    {
        Ad_S.clip = buttonFX;
        Ad_S.Play();
        if (text_2.text == "0")
        {
            text_2.text = "1";
            line_2.color = green;
            line_6.color = red;
        }
        else
        {
            text_2.text = "0";
            line_2.color = red;
            line_6.color = green;
        }
        Decre();
        Or_1();
    }

    public void Btn_Pressed_3()
    {
        Ad_S.clip = buttonFX;
        Ad_S.Play();
        if (text_3.text == "0")
        {
            text_3.text = "1";
            line_3.color = green;
            line_3_1.color = green;
            line_3_2.color = green;
            line_3_3.color = green;
        }
        else
        {
            text_3.text = "0";
            line_3.color = red;
            line_3_1.color = red;
            line_3_2.color = red;
            line_3_3.color = red;
        }
        Decre();
        And_1();
        FinalCHeck();
    }

    public void Btn_Pressed_4()
    {
        Ad_S.clip = buttonFX;
        Ad_S.Play();
        if (text_4.text == "0")
        {
            text_4.text = "1";
            line_4.color = green;
            line_7.color = red;
        }
        else
        {
            text_4.text = "0";
            line_4.color = red;
            line_7.color = green;
        }
        Decre();
        And_1();
    }

    public void Decre()
    {
        counter--;
        tent_count.text = counter.ToString(); 
        if(counter == 0)
        {
            Ad_S.clip = fallimentoFX;
            Ad_S.Play();
            Failed.SetActive(true);  
            counter = 4;

        }
    }


    public void Or_1()
    {
        if(line_5.color == green || line_6.color == green)
        {
            line_8.color = green;
            line_10.color = red;
        }
        else
        {
            line_8.color = red;
            line_10.color = green;
        }
        FinalCHeck();
    }   

    public void And_1()
    {
        if(line_3_1.color == green && line_7.color == green)
        {
            line_9.color = green;
            line_11.color = red;
        }
        else
        {
            line_9.color = red;
            line_11.color = green;
        }
        FinalCHeck();
    } 

    public void FinalCHeck()
    {
        if(line_3_3.color == green && line_10.color == green && line_11.color == green)
        {
            V_F_text.text = "TRUE";
            V_F_box.color = Color.green;
            block.SetActive(true);
            Ad_S.clip = successoFX;
            Ad_S.Play();

            Destroy(GameObject.Find("doorPz1"));
            Invoke("Destr_obj", 1f);

        }
    }




    public void Destr_obj()
    {
        GameObject.Find("player").GetComponent<PlayerMovement>().Unfreeze();
        Destroy(Romp_1);
    }
    
}



