using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 5f, jumpHeight = 3f;
    private Vector3 velocity;
    private bool grounded = true;
    void Start()
    {
            controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * speed);
        velocity.y += Physics.gravity.y * Time.deltaTime;
        
          
        controller.Move(velocity * Time.deltaTime);
        if (GetComponent<CharacterController>().isGrounded) grounded = true;
        if (Input.GetButton("Jump") && grounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
            grounded = false;
        }
        if(grounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }
        //if (move != Vector3.zero) transform.forward = move;
    }

}

