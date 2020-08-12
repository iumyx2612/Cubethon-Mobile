using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private Rigidbody rb;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y <= -15)
        {            
            FindObjectOfType<GameManager>().Restart();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Obstacles"))
        {
            FindObjectOfType<Score>().curScore -= 20;
            FindObjectOfType<Score>().maxScore -= 20;
        }
    }
}
