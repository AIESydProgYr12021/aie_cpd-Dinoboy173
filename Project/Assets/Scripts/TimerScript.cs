using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float startTime = 300f;

    void Update()
    {
        float t = startTime - Time.time;
        if (t > 0)
        {
            string seconds = (t).ToString("f0");

            timerText.text = seconds;
        }

        if (t <= 0)
        {
            //straight up fucking dies
        }
    }
}