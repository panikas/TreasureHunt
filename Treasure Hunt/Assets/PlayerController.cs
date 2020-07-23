using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementForceFactor, speedMax, jumpForce;
    private Rigidbody rBody;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rBody.AddForce(this.transform.up * jumpForce, ForceMode.Impulse);
        }
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if(rBody.velocity.magnitude < speedMax) { 
            rBody.AddForce(this.transform.forward * movementForceFactor);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (rBody.velocity.magnitude < speedMax/2)
            {
                rBody.AddForce(-this.transform.forward * movementForceFactor);
            }
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(-this.transform.up * 2f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(this.transform.up * 2f);
        }
        
    }
}
