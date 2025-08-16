using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerCounter : MonoBehaviour
{
    public static bool twice = false;
    private bool count9 = false;
    public static float count = 1;
    public static int lastCount;
    TextMeshProUGUI powerCount;
    [SerializeField] private AudioSource a;
    [SerializeField] private AudioClip b;
    public GameObject particle;

    void Start()
    {
        if (EnemyHP.powerCount1)
        {
            count = 1;
            EnemyHP.powerCount1 = false;
        }
        
        powerCount = GetComponent<TextMeshProUGUI>();
        lastCount = (int)count;
        powerCount.text = lastCount.ToString("F0");
    }

    void Update()
    {
        if (twice && !count9)
        {
            lastCount = (int)count;
            powerCount.text = lastCount.ToString() + " ~ 1.1";
            twice = false;
            Invoke("TwiceDelete",1);
            a.PlayOneShot(b);
            particle.SetActive(true);
        }

        if (count >= 999999999)
        {
            powerCount.text = "999999999+";
            count9 = true;
            lastCount = 999999999;
        }
    }

    void TwiceDelete()
    {
        powerCount.text = lastCount.ToString();
    }
}
