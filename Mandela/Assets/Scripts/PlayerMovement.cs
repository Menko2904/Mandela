using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    public float movement; 
    public float normalHeight;
    public float crouchHeight;
 
    public bool isSprinting = false;
    public float sprintingMultiplier = 30f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        
        float z = Input.GetAxis("Vertical");


        Vector3 move = transform.right * x + transform.forward * z;


        controller.Move(move * speed * Time.deltaTime);


        if (Input.GetButtonDown("Jump") && isGrounded)
        {

            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
             controller.height = crouchHeight;
        }
        if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            controller.height = normalHeight;
        }
        
        Vector3 movement = new Vector3();

        movement = x * transform.right + z * transform.forward;

        if (isSprinting == true)
        {
            movement *= sprintingMultiplier;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(movement * speed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);
    }
}