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
    private GameObject gate;

    // Start is called before the first frame update
    void Start()
    {        
        player = GameObject.FindGameObjectWithTag("Player");
        oldPos = (int)player.transform.position.z;
        gate = GameObject.FindGameObjectWithTag("Gate");
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
        if(GameObject.Find("Gate") != null)
        {
            if (player.transform.position.z >= gate.transform.position.z)
            {
                score.text = maxScore.ToString("0");
            }
        }

    }
}
