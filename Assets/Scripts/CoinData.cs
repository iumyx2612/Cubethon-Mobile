using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinData : MonoBehaviour
{
    public int coinCounter;
    public int totalCoin;
    public Text coinText;
    public Text coinTextInPanel;
    public Text totalcoinText;

    private void Start()
    {
        coinCounter = 0;
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name != "Main Menu")
        {
            coinText.text = coinCounter.ToString();
            coinTextInPanel.text = coinCounter.ToString();
        }
        else
        {
            totalcoinText.text = totalCoin.ToString();
        }
    }

    public void SaveCoin()
    {
        SaveSystem.SaveCoin(this);
    }

    public void LoadCoin()
    {
        CoinCollected data = SaveSystem.LoadCoin();
        totalCoin = data.coinCollected;
    }
}
