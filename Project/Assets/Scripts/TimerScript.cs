using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float startTime = 300f;

    string seconds = "";
    int secondsLength = 0;
    int additionZeros = 0;

    private void Start()
    {
        float t = startTime;
    }

    void Update()
    {
        float t = startTime - Time.time; // counts down
        if (t > 0)
        {
            seconds = (t).ToString("f0");

            secondsLength = seconds.Length;
            additionZeros = 3 - secondsLength; // how many '0's are needed

            for (int i = 0; i < additionZeros; i++) // adds the amount of 0s needed to make the seconds 3 digits
            {
                seconds = "0" + seconds;
            }

            timerText.text = seconds; // sets text
        }

        if (t <= 0)
        {
            //straight up fucking dies
        }
    }
}