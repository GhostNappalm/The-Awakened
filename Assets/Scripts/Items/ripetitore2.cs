using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ripetitore2 : MonoBehaviour
{
    public Transform player;
    public GameObject Text;
    public Transform antenna;
    public Transform firepoint;
    public GameObject beamPrefab;
    public Sprite RipetitoreOn;
    public Sprite RipetitoreOff;




    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        float dist = Vector2.Distance(player.transform.position, transform.position);
        if (dist <= 2)
        {
            Text.GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
            if (Input.GetKeyDown(KeyCode.F))
            {
                gameObject.GetComponent<AudioSource>().Play();
                antenna.Rotate(0, 0, -45);
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                gameObject.GetComponent<AudioSource>().Play();
                antenna.Rotate(0, 0, 45);
            }
        }
        else
        {
            Text.GetComponent<TMPro.TextMeshProUGUI>().enabled = false;
        }

    }

    public void Spara()
    {
        GameObject beam = Instantiate(beamPrefab, firepoint.position, firepoint.rotation);
        beam.GetComponent<beam>().origin = gameObject;
        Rigidbody2D rb = beam.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.right * 10f, ForceMode2D.Impulse);

    }
    

    public void SpriteChangeOn()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = RipetitoreOn;
        Invoke("SpriteChangeOff", 3f);
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
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = RipetitoreOff;
        }

    }
}

