using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallGenerator : MonoBehaviour
{
    private float count = 0;
    public GameObject ball,canvas,button2;

    void Update()
    {
        count -= Time.deltaTime;

        if (count <= 0)
        {
            count = 1;
            GameObject go = Instantiate(ball,new Vector3(179,350,0),Quaternion.identity);
            go.transform.SetParent(canvas.transform, false);
        }
    }

    public void StartClick()
    {
        button2.SetActive(true);
    }

    public void StartClick2()
    {
        SceneManager.LoadScene("MainScene");
    }
}
