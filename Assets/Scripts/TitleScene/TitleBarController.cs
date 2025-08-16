using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBarController : MonoBehaviour
{
    private float count = 1;

    void Update()
    {
        count -= Time.deltaTime;

        if (count <= -1)
        {
            count = 1;
        }

        if (count > 0)
        {
            transform.Rotate(0, 0, 0.2f);
        }

        else
        {
            transform.Rotate(0, 0, -0.2f);
        }
    }
}