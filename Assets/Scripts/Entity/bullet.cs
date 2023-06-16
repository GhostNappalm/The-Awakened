using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject,3f);
    }

    void OnCollisionEnter2D(Collision2D hitInfo)
    {

        GameObject Gobj = hitInfo.gameObject;
        if (Gobj.tag=="enemy")
        {
            Debug.Log("colpito");
            enemy enemy = Gobj.GetComponent<enemy>();
            enemy.TakeDamage(20);
        }
        Destroy(gameObject);
    }

}
