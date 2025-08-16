using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject ballPrefab,canvas;
    public Transform amountShoot;
    [SerializeField] private AudioSource a;
    [SerializeField] private AudioClip b;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Power"))
        {
            Debug.Log("Power");
            PowerCounter.twice = true;
            PowerCounter.count *= 1.1f;
        }

        if (other.CompareTag("Amount"))
        {
            Debug.Log("Amount");
            Transform amountShoot = transform.Find("/Canvas/Image2/AmountZone");
            Vector3 pos = amountShoot.position;
            pos.x *= 4.7f;
            pos.y *= 4.7f;
            pos.z = 0;
            GameObject go = Instantiate(ballPrefab, pos, amountShoot.rotation);
            GameObject canvas = GameObject.Find("Canvas");
            go.transform.SetParent(canvas.transform, false);

            BarController.ballCount++;
            a.PlayOneShot(b);
        }

        if (other.CompareTag("Finish"))
        {
            Destroy(this.gameObject);
        }
    }
}
