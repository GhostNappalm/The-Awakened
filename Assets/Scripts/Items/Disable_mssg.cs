using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disable_mssg : MonoBehaviour
{
    public GameObject Descr;


    public void Disable()
    {
         Descr.SetActive(false);  
    }

    public void Enable()
    {
         //Descr.SetActive(true);  
         Debug.Log("clicked");
    }
}
