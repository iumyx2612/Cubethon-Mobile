using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject plane; 
    public GameObject planes;
    private float totalLength = 0f;
    private float planeLength = 200;
    private int amountOfPlaneonScreen = 5;
    private List<GameObject> activePlanes;

    private GameObject player;

    public GameObject[] obstacleSet;
    public GameObject obstacleContainer;
    [SerializeField]
    private int min_distance_btw_obstacleset;
    [SerializeField]
    private int max_distance_btw_obstacleset;
    private float obstacle_set_length = 50f;
    [SerializeField]
    private int amount_of_obstacleset_on_scr;
    private List<GameObject> activeObstacles;

    // Start is called before the first frame update
    void Start()
    {
        activePlanes = new List<GameObject>();
        activeObstacles = new List<GameObject>();
        player = GameObject.FindGameObjectWithTag("Player");        
        for (int i = 0; i < amountOfPlaneonScreen; i++) 
        {
            SpawnPlane();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z - 110f > (totalLength - amountOfPlaneonScreen * planeLength))
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

        while (obstacle_set_length < totalLength)
        {
            GameObject new_obstacle_set;
            int random_obstacle = (int)Random.Range(0, obstacleSet.Length);
            if (random_obstacle == 0 || random_obstacle == 1)
            {
                float min_x = -5.6f;
                float max_x = 5.6f;
                new_obstacle_set = Instantiate(obstacleSet[random_obstacle], new Vector3(Random.Range(min_x, max_x), -0.5f, transform.position.z), Quaternion.identity);
                Debug.Log(new_obstacle_set.transform.position);
            }
            else
            {
                new_obstacle_set = Instantiate(obstacleSet[random_obstacle]);
            }
            new_obstacle_set.transform.SetParent(obstacleContainer.transform);
            new_obstacle_set.transform.position = Vector3.forward * obstacle_set_length;
            obstacle_set_length += GenerateDistance();
        }



    }

    void DeletePlane()
    {
        Destroy(activePlanes[0]);
        activePlanes.RemoveAt(0);
    }

    float GenerateDistance()
    {
        float temp;
        temp = Random.Range(min_distance_btw_obstacleset, max_distance_btw_obstacleset);
        return temp;
    }
}
