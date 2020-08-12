using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameObject player;
    Vector3 bias = new Vector3(0, 1.25f, -5.53f);

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameObject.transform.position = player.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.position = player.transform.position + bias;
    }
}
