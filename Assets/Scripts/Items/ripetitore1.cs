using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ripetitore1 : MonoBehaviour
{
    public Transform player;
    public GameObject Text;
    public Transform antenna;
    public Transform firepoint;
    public GameObject beamPrefab;
    private AudioSource Ad_S;
    public AudioClip interactFX;
    public AudioClip activateFX;



    // Start is called before the first frame update
    void Start()
    {
        Ad_S = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        float dist = Vector2.Distance(player.transform.position, transform.position);
        if (dist <= 2)
        {
            Text.GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
            if (Input.GetKeyDown(KeyCode.E) && CheckSolved()==false)
            {
                Ad_S.clip = activateFX;
                Ad_S.Play();
                Spara();
            }
            else if(Input.GetKeyDown(KeyCode.F))
            {
                Ad_S.clip = interactFX;
                Ad_S.Play();
                antenna.Rotate(0, 0, -45);
            }
            else if(Input.GetKeyDown(KeyCode.C))
            {
                Ad_S.clip = interactFX;
                Ad_S.Play();
                antenna.Rotate(0, 0, 45);
            }
        }
        else
        {
            Text.GetComponent<TMPro.TextMeshProUGUI>().enabled = false;
        }

    }

    void Spara()
    {
        GameObject beam = Instantiate(beamPrefab, firepoint.position, firepoint.rotation);
        beam.GetComponent<beam>().origin = gameObject;
        Rigidbody2D rb = beam.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.right * 10f, ForceMode2D.Impulse);
    }

    private bool CheckSolved()
    {
        GameObject[] ripetitori = GameObject.FindGameObjectsWithTag("ripetitore");
        int h = 0;
        foreach (GameObject ripetitore in ripetitori)
        {
            if (ripetitore.GetComponent<SpriteRenderer>().sprite == gameObject.GetComponent<SpriteRenderer>().sprite)
            {
                h++;
            }
        }
        if (h == ripetitori.Length)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
