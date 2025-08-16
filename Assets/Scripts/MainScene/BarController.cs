using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BarController : MonoBehaviour
{
    public GameObject amountZone;
    public static int ballCount = 0;
    private bool leftArrow = false;
    private bool rightArrow = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //transform.Rotate(0, 0, 0.5f);
            leftArrow = true;
            rightArrow = false;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //transform.Rotate(0, 0, -0.5f);
            rightArrow = true;
            leftArrow = false;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene("NextScene");
        }

        if (leftArrow)
        {
            transform.Rotate(0, 0, 0.2f);
        }

        if (rightArrow)
        {
            transform.Rotate(0, 0, -0.2f);
        }

        if (ballCount >= 5)
        {
            amountZone.SetActive(false);
            Invoke("AmountZone", 2);
            ballCount = 0;
        }
    }

    void AmountZone()
    {
        amountZone.SetActive(true);
    }
}
