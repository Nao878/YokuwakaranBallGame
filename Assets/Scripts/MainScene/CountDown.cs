using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour
{
    TextMeshProUGUI timerText;
    public float time = 20.0f;

    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        timerText.text = time.ToString();
    }

    void Update()
    {
        time -= Time.deltaTime;
        timerText.text = time.ToString("F0");

        if (time <= 0)
        {
            SceneManager.LoadScene("NextScene");
        }
    }
}
