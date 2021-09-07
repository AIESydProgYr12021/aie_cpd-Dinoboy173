using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinCount : MonoBehaviour
{
    public TextMeshProUGUI coinsText;

    public int coinsCollected = 0;

    string coinCounter = "";

    void Update()
    {
        coinCounter = (coinsCollected).ToString();

        if (coinsCollected < 10) // adds '0's if single digit
        {
            coinCounter = "0" + coinCounter;
        }

        coinsText.text = coinCounter; // sets text
    }
}
