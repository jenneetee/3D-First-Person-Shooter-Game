using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 2f; 
    public float sprintSpeed = 6f; 
    public float jumpForce = 5f; 
    private bool isGrounded = true;
    public CharacterController controller;
    public GameBehavior gameBehavior;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameBehavior = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }

    void Update()
    {
        //player movement
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 moveDirection = transform.right * x + transform.forward * y;

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(moveDirection * sprintSpeed * Time.deltaTime);
        }
        else
        {
            controller.Move(moveDirection * moveSpeed * Time.deltaTime);
        }

        

        // Handle jumping
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("House"))
        {
            gameBehavior.hitHouse = true;
        }
    }

}
