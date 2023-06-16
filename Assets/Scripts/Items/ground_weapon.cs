using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground_weapon : MonoBehaviour
{
    public Transform player;
    public GameObject RiflePrefab;
    public GameObject Text;
    public GameObject weaponGuiImage;
    public GameObject pickupFX;

    // Start is called before the first frame update
    void Start()
    {

        Text = GameObject.Find("Prova");
    }

    void Update()
    {
        float dist = Vector2.Distance(player.transform.position, transform.position);
        if (dist <= 2)
        {
            Text.GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Azioni da eseguire quando viene premuto il tasto F
                RaccogliOggetto();
                //leggi.chiave = true;
            }
        }
        else
        {
            Text.GetComponent<TMPro.TextMeshProUGUI>().enabled = false;
        }

    }

    void RaccogliOggetto()
    {
        Inventario.weapon = true;
        Instantiate(RiflePrefab, player.position, player.rotation);
        weaponGuiImage.SetActive(true);

        GameObject FX = Instantiate(pickupFX, player.position, player.rotation);
        Destroy(FX, 0.2f);

        Destroy(Text);
        Destroy(gameObject);
        
    }
}
