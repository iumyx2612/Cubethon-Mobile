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
    [SerializeField]
    private float maxSideWaySpeed;

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
        Debug.Log(rb.velocity.x);
        if (Input.touchCount > 0)
        {
            Vector3 touchPosition = Input.GetTouch(0).position;
            if (touchPosition.x > screenWidth / 2)
            {
                if (Mathf.Abs(rb.velocity.x) >= maxSideWaySpeed)
                {
                    return;
                }
                if (rb.velocity.magnitude < maxspeed * 0.8f)
                {
                    rb.AddForce(sideWaySpeed[0] * Time.deltaTime, 0, 0);
                }
                else
                {
                    rb.AddForce(sideWaySpeed[1] * Time.deltaTime, 0, 0);
                }
            }
            else
            {
                if (Mathf.Abs(rb.velocity.x) >= maxSideWaySpeed)
                {
                    return;
                }
                if (rb.velocity.magnitude < maxspeed * 0.8f)
                {
                    rb.AddForce(-sideWaySpeed[0] * Time.deltaTime, 0, 0);
                }
                else
                {
                    rb.AddForce(-sideWaySpeed[1] * Time.deltaTime, 0, 0);
                }
            }
        }
    }
}
