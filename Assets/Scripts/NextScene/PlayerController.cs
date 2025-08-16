using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 80.0f;
    private Rigidbody2D rb = null;
    public GameObject ballPrefab,canvas,serihuA,shootEffect;
    public Transform shotPoint;
    int ballCount = BallCounter.ballCount;
    [SerializeField] private AudioSource a;
    [SerializeField] private AudioClip b;
    [SerializeField] private AudioClip c;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-speed, 0) * Time.deltaTime * 100;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(speed,0) * Time.deltaTime * 100;
        }

        if (Input.GetKeyDown(KeyCode.Space) && ballCount >= 1)
        {
            Vector3 pos = shotPoint.position;
            pos.x *= 4.7f;
            pos.y *= 4.7f;
            pos.z = 0;
            GameObject go = Instantiate(ballPrefab, pos, shotPoint.rotation);
            go.transform.SetParent(canvas.transform, false);
            --ballCount;
            a.PlayOneShot(b);
            shootEffect.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && ballCount < 1)
        {
            a.PlayOneShot(c);
            serihuA.SetActive(true);
        }

        if (!Input.anyKey)
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
}
