using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muzzle_flash : MonoBehaviour
{
    public Transform firepoint;
    public Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        firepoint = GameObject.Find("firePoint").GetComponent<Transform>();
        tr = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        tr.position = firepoint.position;
        tr.rotation = firepoint.rotation;
    }
}
