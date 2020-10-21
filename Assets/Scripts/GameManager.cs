using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    private bool gameEnded = false;
    public GameObject gameOverPanel;
    public GameObject coinShowPanel;
    private GameObject player;
    public GameObject scoreText;

    // Start is called before the first frame update
    void Awake()
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

    //public void OnPointerDown(PointerEventData data)
    //{
    //    Debug.Log(data.pointerPress);
    //}
}
