using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle1_console : MonoBehaviour
{
    public GameObject door;
    public Transform player;
    public GameObject Romp_1_prefab;
    public Transform Romp_1_pos;
    public GameObject Text;


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
            if(GameObject.Find("doorPz1")!=null)
            {
                Text.GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
                if (Input.GetKeyDown(KeyCode.E) && GameObject.Find("Romp_1(Clone)") == null)
                {
                    GameObject.Find("player").GetComponent<PlayerMovement>().Freeze();
                    GameObject Romp_1 = Instantiate(Romp_1_prefab, Romp_1_pos.position, Romp_1_pos.rotation);
                }
            }
            else
            {
                Text.GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
                Text.GetComponent<TMPro.TextMeshProUGUI>().text = "Console attivata";
            }
        }
        else
        {
            Text.GetComponent<TMPro.TextMeshProUGUI>().enabled = false;
            //Romp_1.Destroy();  
        }



    }

}
