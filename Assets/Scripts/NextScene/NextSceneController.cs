using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneController : MonoBehaviour
{
    public static bool kitikuMode,defeatMovie,kitikuDefeat = false;
    private float time = 1;
    public GameObject inseki, canvas,GameOverPic,ClearPic;
    [SerializeField] private AudioSource a;
    private int kitikuInsekiCount = 0;
    public static int kitikuInsekiBreakCount = 0;

    void Start()
    {
        a.Play();
        EnemyHP.audioStop = false;
    }

    public void ClearClick()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void DefeatClick()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void KitikuClick()
    {
        kitikuMode = true;
    }

    void Update()
    {
        if (kitikuMode)
        {
            time -= Time.deltaTime;

            if (time <= 0 && kitikuInsekiCount <= 20)
            {
                time = 1;
                GameObject go = Instantiate(inseki);
                int px = Random.Range(-450, 450);
                go.transform.position = new Vector3(px, 400, 0);
                go.transform.SetParent(canvas.transform, false);
                kitikuInsekiCount++;
                Debug.Log("è¦Î‚ª—Ž‚¿‚½”"+kitikuInsekiCount);
            }

            if (kitikuInsekiBreakCount > 20)
            {
                kitikuMode = false;
                ClearPic.SetActive(true);
                defeatMovie = true;
            }
        }

        if (EnemyHP.audioStop)
        {
            a.Stop();
        }

        if (kitikuDefeat)
        {
            a.Stop();
            GameOverPic.SetActive(true);
            defeatMovie = true;
            kitikuMode = false;
            kitikuDefeat = false;
        }
    }
}
