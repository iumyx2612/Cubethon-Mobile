using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool gameEnded = false;
    public GameObject levelCompletePanel;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<CoinData>().LoadCoin();
        player = GameObject.FindGameObjectWithTag("Player");
        gameEnded = false;
    }    
    // Update is called once per frame
    void Update()
    {
        //Dead();
    }

    public void EndGame()
    {
        if(gameEnded == false)
        {
            gameEnded = true;
            Restart();
        }
    }

    public void Restart()
    {        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void LevelCompleted()
    {
        FindObjectOfType<CoinData>().SaveCoin();
        levelCompletePanel.SetActive(true);
        player.GetComponent<PlayerMovement>().enabled = false;
    }
}
