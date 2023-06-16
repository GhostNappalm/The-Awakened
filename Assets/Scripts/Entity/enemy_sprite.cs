using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_sprite : MonoBehaviour
{
    public Transform enemy;
    private Rigidbody2D rb;
    public Animator animator;
    public Vector2 movement;
    public GameObject enemy1;
    private enemy es;
    private Vector3 previous;
    public float velocity;

   

    void Start()
    {
        es = enemy1.GetComponent<enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = enemy.position;
    }

    void FixedUpdate()
    {
        movement=es.movement;

        velocity = ((enemy.position - previous).magnitude) / Time.deltaTime;
        previous = enemy.position;

        animator.SetFloat("Horizontal",movement.x);
        animator.SetFloat("Vertical",movement.y);
        animator.SetFloat("Speed",velocity);
        animator.SetFloat("Health", enemy1.GetComponent<enemy>().hp);
    }
}
