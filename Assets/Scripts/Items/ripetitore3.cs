using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ripetitore3 : MonoBehaviour
{
    public Transform player;
    public GameObject Text;

    public Sprite RipetitoreOn;
    public Sprite RipetitoreOff;
    public GameObject door;



    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        float dist = Vector2.Distance(player.transform.position, transform.position);
        if (dist <= 2 && gameObject.GetComponent<SpriteRenderer>().sprite == RipetitoreOff)
        {
            Text.GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
        }
        else
        {
            Text.GetComponent<TMPro.TextMeshProUGUI>().enabled = false;
        }

    }


    public void SpriteChangeOn()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = RipetitoreOn;
        Invoke("SpriteChangeOff", 1f);
    }

    public void SpriteChangeOff()
    {
        GameObject[] ripetitori = GameObject.FindGameObjectsWithTag("ripetitore");
        int h = 0;
        foreach (GameObject ripetitore in ripetitori)
        {
            if (ripetitore.GetComponent<SpriteRenderer>().sprite == RipetitoreOn)
            {
                h++;
            }
        }
        //Debug.Log("h=" + h.ToString());
        //Debug.Log("ripetitori.Lengt=" + ripetitori.Length.ToString());
        if (h == ripetitori.Length)
        {
            //Debug.Log("tutti attivi");
            gameObject.GetComponent<AudioSource>().enabled = true;
            Destroy(GameObject.Find("doorToConsole2"));
            Text.GetComponent<TMPro.TextMeshProUGUI>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = RipetitoreOff;
        }
        
    }
}

