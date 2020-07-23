using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 5f, jumpHeight = 3f, gravityMod = 1f;
    private Vector3 velocity;
    public GameObject camParent;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {

        //XZ movement
        Vector3 move = (transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal")).normalized;
        controller.Move(move * Time.deltaTime * speed);

        //Gravity
        velocity.y += Physics.gravity.y * gravityMod * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //Camera Rotation
        Vector3 rotateY = new Vector3(0, Input.GetAxis("Mouse X"), 0);
        transform.Rotate(rotateY);
        Vector3 rotateX = new Vector3(-Input.GetAxis("Mouse Y"), 0, 0);
        camParent.transform.Rotate(rotateX);
        
        if (Input.GetButton("Jump") && GetComponent<CharacterController>().isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
        }
        if(GetComponent<CharacterController>().isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }
    }

}

