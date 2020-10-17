using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HomeCanvas : MonoBehaviour
{
    private GameManager gM;

    public void Awake()
    {
        gM = FindObjectOfType<GameManager>();
    }

    public void Update()
    {
        GameStart();
    }

    public void GameStart()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                SceneManager.LoadScene("Test Scene");
            }
        }
    }

    public void Shop()
    {
        Debug.Log("Shop!");
    }

}
