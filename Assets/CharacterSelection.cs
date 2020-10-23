using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public List<GameObject> playerList;
    private float distance;
    private float index;

    private void Awake()
    {        
        playerList = new List<GameObject>(transform.childCount);
        for (int i = 0; i < transform.childCount; i++)
        {
            playerList.Add(transform.GetChild(i).gameObject);
        }        
    }

    private void Start()
    {
        InitialPosition();
    }

    private void Update()
    {        
        
    }

    private void InitialPosition()
    {
        for (int i = 0; i < playerList.Count; i++)
        {
            playerList[i].transform.position = new Vector3(Screen.width * i, playerList[i].transform.position.y, 0);
        }
    }


}
