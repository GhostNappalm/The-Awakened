using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class consoleDoor1 : MonoBehaviour
{
    public Transform player;
    public GameObject door;
    public GameObject Text;
    public GameObject Signal;


    // Start is called before the first frame update
    void Start()
    {
        //Text = GameObject.Find("TextPz1");
    }

    void Update()
    {
        float dist = Vector2.Distance(player.transform.position, transform.position);
        if (dist <= 2)
        {
            Text.GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                gameObject.GetComponent<AudioSource>().enabled=true;
                ApriPorta();
            }
        }
        else
        {
            Text.GetComponent<TMPro.TextMeshProUGUI>().enabled = false;
        }

    }

    void ApriPorta()
    {
        //apri canvas puzzle
        // if puzzle completo
        door.SetActive(false);
        Text.GetComponent<TMPro.TextMeshProUGUI>().text = "Corridoio sbloccato";
        Signal.SetActive(true);
    }
}
