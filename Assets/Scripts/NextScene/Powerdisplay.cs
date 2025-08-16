using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Powerdisplay : MonoBehaviour
{
    TextMeshProUGUI powerCount;

    void Start()
    {
        powerCount = GetComponent<TextMeshProUGUI>();
        powerCount.text = PowerCounter.lastCount.ToString("F0");
    }
}
