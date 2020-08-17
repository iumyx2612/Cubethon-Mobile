using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject plane;
    private GameObject player;
    private Vector3 playerPos;
    public GameObject planes;
    private float totalLength = 0f;
    private float planeLength = 200;
    private int amountOfPlaneonScreen = 5;
    private List<GameObject> activePlanes;

    // Start is called before the first frame update
    void Start()
    {
        activePlanes = new List<GameObject>();
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
        if(player.transform.position.z - 110f > (totalLength - amountOfPlaneonScreen * planeLength))
        {
            SpawnPlane();
            DeletePlane();
        }
    }

    void SpawnPlane()
    {
        GameObject newPlane = Instantiate(plane);
        newPlane.transform.SetParent(planes.transform);
        newPlane.transform.position = new Vector3(0, 0, 1) * totalLength;
        totalLength += planeLength;
        activePlanes.Add(newPlane);
    }

    void DeletePlane()
    {
        Destroy(activePlanes[0]);
        activePlanes.RemoveAt(0);
    }
}
