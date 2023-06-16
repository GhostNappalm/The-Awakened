using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float hp = 100;
    public Rigidbody2D rb;
    Vector2 movement;
    public Animator animator;
    public RectTransform Rtbar;
    private float lifeWidth;
    public bool freeze = false;

    private AudioSource Ad_S;
    private AudioClip[] audioClips;

    //grunt-
    public AudioClip gruntFX_1;
    public AudioClip gruntFX_2;
    public AudioClip gruntFX_3;
    public AudioClip gruntFX_4;
    
    //grunt+
    public AudioClip gruntFX_5;
    public AudioClip gruntFX_6;
    public AudioClip gruntFX_7;




    void Start()
    {
        Rtbar = GameObject.Find("Fill").GetComponent<RectTransform>();
        Ad_S= gameObject.GetComponent<AudioSource>();

        audioClips = new AudioClip[7];
        audioClips[0] = gruntFX_1;
        audioClips[1] = gruntFX_2;
        audioClips[2] = gruntFX_3;
        audioClips[3] = gruntFX_4;
        audioClips[4] = gruntFX_5;
        audioClips[5] = gruntFX_6;
        audioClips[6] = gruntFX_7;
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetFloat("Health", hp);
        lifeWidth = Rtbar.sizeDelta.x;

    }
    void FixedUpdate()
    {
        if (freeze != true)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
    public void TakeDamage(float damage)
    {
        if(hp>0)
        {
            hp -= damage;
            Rtbar.sizeDelta = new Vector2(lifeWidth - damage, Rtbar.sizeDelta.y);
            gameObject.GetComponent<Inventario>().Inc_TotDmgTaken(((int)damage));
            Debug.Log("danno ricevuto");

            GruntFXcall();

            if (hp <= 0.01)
            {
                freeze = true;
                Invoke("Die", 1.37f);
                if (GameObject.Find("rifle(Clone)") != null)
                {
                    GameObject.Find("rifle(Clone)").SetActive(false);
                }

            }
        }
        
    }
    public void Freeze()
    {
        freeze = true;
    }

    public void Unfreeze()
    {
        freeze = false;
    }

    private void GruntFXcall()
    {
        if(hp>=40)
        {
            Ad_S.clip= audioClips[Random.Range(0, 3)];
            Ad_S.Play();
        }
        else
        {
            Ad_S.clip = audioClips[Random.Range(4, 6)];
            Ad_S.Play();
        }
    }
}