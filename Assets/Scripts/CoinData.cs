using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinData : MonoBehaviour
{
    public int coinCounter;
    public Text coinText;

    private void Start()
    {
        coinCounter = 0;
    }

    private void Update()
    {
        coinText.text = coinCounter.ToString();
    }
}
