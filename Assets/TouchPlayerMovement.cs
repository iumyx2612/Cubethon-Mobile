using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxspeed;
    [SerializeField]
    private float[] sideWaySpeed;
    private float screenWidth;

    // Start is called before the first frame update
    void Start()
    {
        screenWidth = Screen.width;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, speed * Time.deltaTime);
        if (rb.velocity.magnitude >= maxspeed)
        {
            rb.velocity = rb.velocity.normalized * maxspeed;
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch(touch.phase)
            {
                case TouchPhase.Began:
                    if (touch.position.x < screenWidth / 2)
                    {
                        Vector3 leftInput = new Vector3(-1f, 0, 0);
                        if (rb.velocity.magnitude < maxspeed)
                        {
                            rb.MovePosition(rb.position + leftInput * sideWaySpeed[0] * Time.deltaTime);
                        }
                        else
                        {
                            rb.MovePosition(rb.position + leftInput * sideWaySpeed[1] * Time.deltaTime);
                        }
                    }
                    else if (touch.position.x > screenWidth / 2)
                    {
                        Vector3 rightInput = new Vector3(1f, 0, 0);
                        if (rb.velocity.magnitude < maxspeed)
                        {
                            rb.MovePosition(rb.position + rightInput * sideWaySpeed[0] * Time.deltaTime);
                        }
                        else
                        {
                            rb.MovePosition(rb.position + rightInput * sideWaySpeed[1] * Time.deltaTime);
                        }
                    }
                    break;
                case TouchPhase.Ended:
                    rb.velocity = new Vector3(0, 0, 0);
                    break;
            }
        }
    } 
}
