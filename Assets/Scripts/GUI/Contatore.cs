using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Contatore : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = player.GetComponent<Inventario>().ammo.ToString();
        
    }
}
