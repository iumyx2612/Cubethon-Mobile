using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUICam3D : MonoBehaviour
{
    public GameObject player;
    private Vector3 origin;
    private Vector3 direction;
    private float maxDistance = 30f;
    private int layerMasks;

    private void Awake()
    {
        origin = transform.position;        
    }

    // Start is called before the first frame update
    void Start()
    {
        direction = -origin + player.transform.position;
        layerMasks = 1 << 8;
        layerMasks = ~layerMasks;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;
        if(Physics.Raycast(origin, direction, out hitInfo, maxDistance, layerMasks))
        {
            Debug.DrawRay(origin, direction * maxDistance, Color.red);
        }
        else
        {
            Debug.DrawRay(origin, direction * maxDistance, Color.blue);
        }
    }
}
