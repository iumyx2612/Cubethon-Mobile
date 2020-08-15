using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinData : MonoBehaviour
{
    public int coinCounter;
    public int totalCoin;
    public Text coinText;
    public Text totalcoinText;

    private void Start()
    {
        coinCounter = 0;
    }

    private void Update()
    {
        coinText.text = coinCounter.ToString();
        totalcoinText.text = totalCoin.ToString();
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
