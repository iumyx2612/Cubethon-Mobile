using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CoinCollected
{
    public int coinCollected;

    public CoinCollected(CoinData coinData)
    {
        coinCollected = coinData.coinCounter;
    }
}
