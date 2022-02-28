using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGravity : MonoBehaviour
{
    Rigidbody2D rb;
    public Collider2D[] topCollider;
    public Collider2D[] downCollider;
    public Collider2D[] colliderCancel;
    public Collider2D[] pics;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int h = 0; h < pics.Length; h++)
        {
            if (collision == pics[h])
            {
                rb.velocity = Vector2.zero;
                PauseMenu.Instance.Restart();
                AudioManager.Instance.PlaySound("Die");
            }
        }

        for (int j = 0; j < topCollider.Length; j++)
        {
            if (collision == topCollider[j])
            {
                rb.gravityScale = -1;
            }
        }

        for (int k = 0; k < downCollider.Length; k++)
        {
            if (collision == downCollider[k])
            {
                rb.gravityScale = 1;
            }
        }

        for (int i = 0; i < colliderCancel.Length; i++)
        {
            if (collision == colliderCancel[i])
            {
                //Debug.Log("Collision avec le cancel");
                rb.gravityScale *= 0;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        for (int i = 0; i < colliderCancel.Length; i++)
        {
            if (collision == colliderCancel[i])
            {
                rb.gravityScale = 1;
            }
        }
    }
}
