using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxspeed;
    [SerializeField]
    private float[] sideWaySpeed;
    [SerializeField]
    private float maxSideWaySpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, speed * Time.deltaTime);
        if (rb.velocity.magnitude >= maxspeed)
        {
            rb.velocity = rb.velocity.normalized * maxspeed;
        }
        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        if (rb.velocity.magnitude < maxspeed)
        {
            rb.MovePosition(rb.position + moveInput * sideWaySpeed[0] * Time.deltaTime);
        }
        else
        {
            rb.MovePosition(rb.position + moveInput * sideWaySpeed[1] * Time.deltaTime);
        }    
    }

}
