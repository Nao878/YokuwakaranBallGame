using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallCounter : MonoBehaviour
{
    TextMeshProUGUI amountCount;
    public static int ballCount = 0;
    [SerializeField] private AudioSource a;
    [SerializeField] private AudioClip b;
    public GameObject paricleAmount;

    private void Start()
    {
        if (EnemyHP.amountCount0)
        {
            ballCount = 0;
            EnemyHP.amountCount0 = false;
        }

        amountCount = GetComponent<TextMeshProUGUI>();
        amountCount.text = ballCount.ToString();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        ballCount++;
        amountCount.text = ballCount.ToString();
        a.PlayOneShot(b);
        paricleAmount.SetActive(true);
    }
}
