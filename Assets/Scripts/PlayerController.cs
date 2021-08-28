using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("General Parameters")]
    [SerializeField] float playerSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;

    // parameters
    int jumpCounter = 0;

    //caching 
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }

    private void Update()
    {
        Movement();
        Jump();
    }

    private void Jump()
    {

        // Prevent double jumps
        // See on void collision
        if (jumpCounter >=1)        
            return;
        

        if (Input.GetButtonDown("Jump"))
        {
            jumpCounter++;
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }              
    }

    private void Movement()
    {
        var xMove = Input.GetAxis("Horizontal");
        float xVelocity = xMove * playerSpeed;
        Vector3 playerVelocity = new Vector3(xVelocity, rb.velocity.y, rb.velocity.z);

        rb.velocity = playerVelocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Checks if player is touching ground, if they are,
        // reset amount of jumps
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCounter = 0;
            Debug.Log("Touching the ground");
        }
    }
}
