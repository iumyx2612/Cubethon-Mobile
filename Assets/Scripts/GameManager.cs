using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool gameEnded = false;
    public GameObject gameOverPanel;
    public GameObject coinShowPanel;
    private GameObject player;
    public GameObject scoreText;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        Time.timeScale = 1f;
        FindObjectOfType<CoinData>().LoadCoin();
        player = GameObject.FindGameObjectWithTag("Player");
        gameEnded = false;
    }    
    // Update is called once per frame
    void Update()
    {
        GameStart();
    }

    public void EndGame()
    {
        if(gameEnded == false)
        {
            gameEnded = true;
        }
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        EndGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        EndGame();
        scoreText.SetActive(false);
        coinShowPanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }
    
    public void GameStart()
    {
        if(SceneManager.GetActiveScene().name == "Main Menu")
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    SceneManager.LoadScene("Main Scene");
                }
            }
        }

    }
}
