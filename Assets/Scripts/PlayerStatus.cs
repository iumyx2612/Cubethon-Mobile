using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject deathParticle;
    

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
            Instantiate(deathParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
            FindObjectOfType<GameManager>().GameOver();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Obstacles"))
        {
            Instantiate(deathParticle, transform.position,Quaternion.identity);
            Destroy(gameObject);
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
