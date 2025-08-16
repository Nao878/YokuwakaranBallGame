using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.position += new Vector3(0, 1f, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            Destroy(this.gameObject);
        }
    }
}
