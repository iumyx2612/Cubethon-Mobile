using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject plane;
    private GameObject player;
    private Vector3 playerPos;
    public GameObject planes;
    private float PlaneZ;
    private float planeLength = 200;
    private int amountOfPlaneonScreen = 5;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        for (int i = 0; i < amountOfPlaneonScreen; i++) 
        {
            SpawnPlane();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPlane()
    {
        GameObject gameObject = Instantiate(plane) as GameObject;
        gameObject.transform.SetParent(planes.transform);
        gameObject.transform.position = Vector3.forward * PlaneZ;
        PlaneZ += planeLength;
    }
}
