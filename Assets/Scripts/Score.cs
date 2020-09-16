using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private GameObject player;
    public Text score;
    public Text highScore;
    public Text scoreInPanel;
    private int oldPos;
    public int curScore;

    // Start is called before the first frame update
    void Start()
    {        
        player = GameObject.FindGameObjectWithTag("Player");
        oldPos = (int)player.transform.position.z;
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        scoreInPanel.text = PlayerPrefs.GetInt("CurrentScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        int newPos = (int)player.transform.position.z;
        curScore += newPos - oldPos;
        score.text = curScore.ToString("0");

        oldPos = (int)player.transform.position.z;
        PlayerPrefs.SetInt("CurrentScore", curScore);
        if(curScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", curScore);
            highScore.text = curScore.ToString();
        }
    }
}
