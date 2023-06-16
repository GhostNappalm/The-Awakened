using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D rb;
    public GameObject lifeBar;

    public Vector2 movement;
    public float moveSpeed;
    public float hp = 100;

    public GameObject dieFX;

    private bool frozen;
    public bool wasTriggered;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if(GameObject.Find("player")!=null)
        { 
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;  
        }
        else
        {
            frozen = true;
        }

        if (hp <= 0) gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }


    void moveCharacter(Vector2 direction)
    {
        float dist = Vector2.Distance(player.transform.position, transform.position);
        if(dist<=7 || wasTriggered==true)
        {
            if(wasTriggered==true)Invoke("wasTriggeredReset", 3f);
            moveSpeed = 4.5f;
            rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
        }
        else
        {
            
            if(moveSpeed > 1f)
            {
                moveSpeed = moveSpeed * 0.99f;
                rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
            }
        }
    }

    private void wasTriggeredReset()
    {
        wasTriggered = false;
    }

    private void FixedUpdate()
    {
        if(frozen!=true && hp>0)
        {
            moveCharacter(movement);
        }
        else
        {
            movement = Vector3.down;
        }
    }

    public void TakeDamage(int damage)
    {
        if(hp>0)
        {
            hp -= damage;
            lifeBar.GetComponent<Bar>().UpdateBar(-damage);
            if (hp <= 0)
            {
                GameObject FX = Instantiate(dieFX, this.GetComponent<Transform>().position, this.GetComponent<Transform>().rotation);
                Destroy(FX, 1f);
                lifeBar.SetActive(false);
                frozen = true;
                Invoke("Die", 1.49f);
            }
        }
        
    }

    public void Die()
    {
        GameObject.Find("player").GetComponent<Inventario>().Inc_Punt(100);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        GameObject Gobj = hitInfo.gameObject;
        
        if(Gobj.name=="player" && frozen==false && hp>0)
        {
            this.Freeze(3f);
            PlayerMovement PlayerMovement = Gobj.GetComponent<PlayerMovement>();
            PlayerMovement.TakeDamage(20);
        }
        else if(Gobj.name == "bullet(Clone)")
        {
            wasTriggered = true;
        }
    }


    public void Freeze(float f_time)
    {
        frozen = true;
        Invoke("Unfreeze", f_time);
    }

    private void Unfreeze()
    {
        frozen = false;
    }

   
}
