using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public static bool chiave = false;
    public static bool weapon = false;
    public int punteggio = 0;
    public int ammo = 0;
    private float initializationTime;
    public float timeSinceInitialization;
    public int TotDmgTaken = 0;

    void Start()
    {
        initializationTime = Time.timeSinceLevelLoad;
    }

    void Update()
    {
        timeSinceInitialization = Time.timeSinceLevelLoad - initializationTime;
    }
    
    public void Inc_Punt(int punti)
    {
        punteggio += punti;
        GameObject.Find("Punteggio").GetComponent<TMPro.TextMeshProUGUI>().text = punteggio.ToString();
    }

    public void Inc_TotDmgTaken(int dmg)
    {
        TotDmgTaken += dmg;
    }

    public void Inc_Punt_finegioco()
    {
        punteggio += 5000 - ((int)timeSinceInitialization)*2 - TotDmgTaken*4;
        GameObject.Find("Punteggio").GetComponent<TMPro.TextMeshProUGUI>().text = punteggio.ToString();
    }
}
