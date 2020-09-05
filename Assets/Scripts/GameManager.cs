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
        Application.targetFrameRate = 60;
        FindObjectOfType<CoinData>().LoadCoin();
        player = GameObject.FindGameObjectWithTag("Player");
        gameEnded = false;
    }    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndGame()
    {
        if(gameEnded == false)
        {
            gameEnded = true;
        }
    }

    public void Restart()
    {
        if (gameEnded == false)
        {
            gameEnded = true;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void LevelCompleted()
    {
        FindObjectOfType<CoinData>().SaveCoin();
        levelCompletePanel.SetActive(true);
        player.GetComponent<PlayerMovement>().enabled = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
