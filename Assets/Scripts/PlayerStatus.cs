using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            if(SceneManager.GetActiveScene().name != "Endless")
            {
                FindObjectOfType<GameManager>().Restart();
            }
            else
            {
                FindObjectOfType<GameManager>().EndGame();
            }
        }
    }
}
