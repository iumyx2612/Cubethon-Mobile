using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private GameObject player;
    public Text score;
    public int maxScore = 200;
    private int oldPos;
    public int curScore;

    // Start is called before the first frame update
    void Start()
    {        
        player = GameObject.FindGameObjectWithTag("Player");
        oldPos = (int)player.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        int newPos = (int)player.transform.position.z;
        curScore += newPos - oldPos;
        score.text = curScore.ToString("0");

        oldPos = (int)player.transform.position.z;
        
    }
    public void LateUpdate()
    {
        if (player.transform.position.z >= 200)
        {
            score.text = maxScore.ToString("0");
        }
    }
}
