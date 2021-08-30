using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("General Parameters")]
    [SerializeField] float _playerSpeed = 5f;
    [SerializeField] float _jumpSpeed = 5f;

    // parameters
    int jumpCounter = 0;

    //caching 
    Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();   
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
            _rb.velocity = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);
            _rb.AddForce(Vector3.up * _jumpSpeed, ForceMode.Impulse);
        }              
    }

    private void Movement()
    {
        var xMove = Input.GetAxis("Horizontal");
        float xVelocity = xMove * _playerSpeed;
        Vector3 playerVelocity = new Vector3(xVelocity, _rb.velocity.y, _rb.velocity.z);

        _rb.velocity = playerVelocity;
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
