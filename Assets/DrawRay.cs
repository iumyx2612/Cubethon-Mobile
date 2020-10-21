using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRay : MonoBehaviour
{
    Vector3 origin;
    Vector3 direction;
    float maxDistance;
    int layerMask;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
        direction = player.transform.position - origin;
        maxDistance = 30f;
        layerMask = 1 << 8;
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        
        
    }
}
