using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoPickup : MonoBehaviour
{
    public Transform player;
    public GameObject Text;
    public GameObject ammoGuiImage;
    public GameObject reloadFX;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        float dist = Vector2.Distance(player.transform.position, transform.position);
        if (dist <= 2.5)
        {
            Text.GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Azioni da eseguire quando viene premuto il tasto F
                RaccogliAmmo();
                //leggi.chiave = true;
            }
        }
        else
        {
            Text.GetComponent<TMPro.TextMeshProUGUI>().enabled = false;
        }

    }

    void RaccogliAmmo()
    {
        player.GetComponent<Inventario>().ammo = player.GetComponent<Inventario>().ammo + 20;
        GameObject FX = Instantiate(reloadFX, player.position, player.rotation);
        Destroy(FX,0.78f);
        Destroy(Text);
        ammoGuiImage.SetActive(true);
        Destroy(gameObject);
    }
}
