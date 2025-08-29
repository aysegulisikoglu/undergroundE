using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    public float moveSpeed = 100;
    private Vector2 input;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (input.x != 0) input.y = 0;
        rb.velocity = new Vector2(input.x * moveSpeed * Time.deltaTime, input.y * moveSpeed * Time.deltaTime);
        if (rb.velocity != Vector2.zero)
        {
            animator.SetFloat("moveX", rb.velocity.x);
            animator.SetFloat("moveY", rb.velocity.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }


    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }
}
