using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGravity : MonoBehaviour
{
    Rigidbody2D rb;
    public Collider2D topCollider;
    public Collider2D downCollider;
    public Collider2D colliderCancel;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == topCollider)
        {
            rb.gravityScale = -1;
        }

        if (collision == downCollider)
        {
            rb.gravityScale = 1;
        }

        if (collision == colliderCancel)
        {
            rb.gravityScale *= 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == colliderCancel)
        {
            rb.gravityScale = 1;
        }
    }
}
