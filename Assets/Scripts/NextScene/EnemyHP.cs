using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHP : MonoBehaviour
{
    TextMeshProUGUI enemyHPText;
    int enemyHP = 55;
    public GameObject ClearPic,GameOverPic;
    [SerializeField] private AudioSource a;
    [SerializeField] private AudioClip b;
    public GameObject particle,particle2,particle3,particle4,serihuY;
    public static bool amountCount0,powerCount1,audioStop = false;

    void Start()
    {
        enemyHPText = GetComponent<TextMeshProUGUI>();
        enemyHPText.text = enemyHP.ToString();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            enemyHP -= PowerCounter.lastCount;
            enemyHPText.text = enemyHP.ToString();
            a.PlayOneShot(b);
            particle.SetActive(true);
        }

        if (enemyHP <= 0)
        {
            particle.SetActive(true);
            Invoke("Explotion2", 0.2f);
            Invoke("Explotion3", 0.4f);
            Invoke("Explotion4", 0.6f);
            Invoke("Destroy", 1.2f);

            if (!NextSceneController.kitikuMode)
            {
                ClearPic.SetActive(true);
                serihuY.SetActive(true);
                audioStop = true;
            }
            else
            {
                NextSceneController.kitikuInsekiBreakCount++;
                Debug.Log("è¦Î‚ª‰ó‚ê‚½”"+NextSceneController.kitikuInsekiBreakCount);
            }
        }

        if (collision.CompareTag("InsekiClash"))
        {
            Destroy(this.gameObject);
            amountCount0 = true;
            powerCount1 = true;

            if (!NextSceneController.kitikuMode)
            {
                audioStop = true;
                GameOverPic.SetActive(true);
            }
            else
            {
                NextSceneController.kitikuDefeat = true;
            }
        }
    }

    void FixedUpdate()
    {
        transform.position += new Vector3(0, -0.1f, 0);
        
        if (NextSceneController.defeatMovie)
        {
            Destroy(this.gameObject);
            Invoke("InsekiRemove",0.1f);
        }
    }

    void Explotion2()
    {
        particle2.SetActive(true);
    }
    void Explotion3()
    {
        particle3.SetActive(true);
    }
    void Explotion4()
    {
        particle4.SetActive(true);
    }
    void Destroy()
    {
        Destroy(this.gameObject);
    }
    void InsekiRemove()
    {
        NextSceneController.defeatMovie = false;
    }
}
