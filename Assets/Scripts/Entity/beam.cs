using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beam : MonoBehaviour
{
    public GameObject origin;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(origin.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    void OnCollisionEnter2D(Collision2D hitInfo)
    {

        GameObject Gobj = hitInfo.gameObject;
        if (Gobj.tag == "ripetitore")
        {
            Destroy(gameObject);
            if(Gobj.name== "ripetitoreEnd")
            {
                Gobj.GetComponent<ripetitore3>().SpriteChangeOn();
            }
            else
            {
                Gobj.GetComponent<ripetitore2>().Spara();
                Gobj.GetComponent<ripetitore2>().SpriteChangeOn();
            }
            
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
