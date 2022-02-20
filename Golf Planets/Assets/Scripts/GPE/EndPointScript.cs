using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointScript : MonoBehaviour
{
    public Collider2D ball;

    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision = ball)
        {
            Debug.Log("restart game");
            Application.LoadLevel("MainGame");
        }
    }
}
