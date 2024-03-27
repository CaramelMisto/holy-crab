using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float jumpForce =350.0f;
    private Rigidbody2D rigidbody2D;
    private Animator animator;

    private bool Grounded;
    private bool GameStarted;
    private bool jumping;


    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();//caching
        animator = GetComponent<Animator>();
        Grounded = true;
    }  

    private void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            if (GameStarted&& Grounded)
            {
                animator.SetTrigger("Jump");
                Grounded = false;
                jumping = true;

            }
            else
            {
                animator.SetBool("GameStarted", true);
                GameStarted = true;
            }
        }

     
          animator.SetBool("Grounded", Grounded);

        
    }

    private void FixedUpdate()
    {
        if (GameStarted)
        {
            rigidbody2D.velocity = new Vector2(x:speed, rigidbody2D.velocity.y);
        }
        if (jumping)
        {
            rigidbody2D.AddForce(new Vector2(x: 0f, y: jumpForce));
            jumping = false;
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("zemin"))
        {
            Grounded = true;
        }
    }



}
