using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject plane;
    private GameObject player;
    private Vector3 playerPos;
    public GameObject planes;
    private float PlaneZ = -100f;
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
        if(player.transform.position.z - 100f > (PlaneZ - amountOfPlaneonScreen * planeLength))
        {
            SpawnPlane();
            DeletePlane();
        }
    }

    void SpawnPlane()
    {
        GameObject newplane = Instantiate(plane) as GameObject;
        newplane.transform.SetParent(planes.transform);
        newplane.transform.position = Vector3.forward * PlaneZ;
        Debug.Log(newplane.transform.position);
        PlaneZ += planeLength;
        activePlanes.Add(newplane);
    }

    void DeletePlane()
    {
        Destroy(activePlanes[0]);
        activePlanes.RemoveAt(0);
    }
}
