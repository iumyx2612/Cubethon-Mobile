using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public GameObject[] spawnObj;
    public Vector3 pos;
    public Vector3 totalLength;
    public Vector3 distance;

    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector3(Random.Range(-5.3f, 5.3f), 0.5f);
        Test();
        Test();
        Test();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Test()
    {
        GameObject gO;
        gO = Instantiate(spawnObj[Random.Range(0, spawnObj.Length)]);
        gO.transform.position = totalLength;
        totalLength.z += distance.z;
        totalLength.y = 0.5f;
        totalLength.x = Random.Range(-5.3f, 5.3f);
    }

}
