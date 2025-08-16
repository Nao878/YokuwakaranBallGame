using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Balldisplay : MonoBehaviour
{
    TextMeshProUGUI amountCount;
    int ballCount = BallCounter.ballCount;

    void Start()
    {
        amountCount = GetComponent<TextMeshProUGUI>();
        amountCount.text = ballCount.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ballCount >= 1)
        {
            --ballCount;
            amountCount.text = ballCount.ToString();
            BallCounter.ballCount = ballCount;
        }
    }
}
