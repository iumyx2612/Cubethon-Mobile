using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelection : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> playerList;
    private int numOfPlayers;
    private int index;

    [SerializeField]
    private GameObject panelHolder;

    private void Awake()
    {
        numOfPlayers = transform.childCount;
        playerList = new List<GameObject>(numOfPlayers);
        for (int i = 0; i < numOfPlayers; i++)
        {
            playerList.Add(transform.GetChild(i).gameObject);
        }
        foreach(GameObject gameObject in playerList)
        {
            gameObject.SetActive(false);
        }
        if(playerList[0])
        {
            playerList[0].SetActive(true);
        }

        panelHolder = GameObject.Find("Panel Holder");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
