using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equiped_weapon : MonoBehaviour
{
    public Camera cam;
    public Transform player;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Transform tr;

    public float z_rot;
    Vector3 temp = new Vector3(0, 0.6f, 0);
    Vector2 mousePos;


    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        player = GameObject.Find("player").GetComponent<Transform>();
    }


    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        sr = GetComponent<SpriteRenderer>();
        tr = GetComponent<Transform>();
        
    }

    void FixedUpdate()
    {
        transform.position = player.position + temp;

        Vector2 lookDir = mousePos - rb.position;
        float angle = (Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f) - 90;
        rb.rotation = angle;
        z_rot = tr.localEulerAngles.z;
        if (tr.localEulerAngles.z >= 90 && tr.localEulerAngles.z <= 270)
        {
            sr.flipY = true;
        }
        else
        {
            sr.flipY = false;
        }


        if (Input.GetAxis("Vertical") <= 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 4;
        }
        else if(Input.GetAxis("Vertical")>0)
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }

    }
}
