using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Coin : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<CoinData>().coinCounter += 1;
            FindObjectOfType<CoinData>().totalCoin += 1;
            FindObjectOfType<CoinData>().SaveCoin();
            Debug.Log("Coin");
            FindObjectOfType<AudioManager>().Play("Coinpickup");
            Destroy(gameObject);
        }
    }
}
