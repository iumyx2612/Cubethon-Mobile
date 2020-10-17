using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuUI : MonoBehaviour
{
    private GameManager gM;

    // Start is called before the first frame update
    void Start()
    {
        gM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
