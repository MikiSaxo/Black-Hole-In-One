using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPointScript : MonoBehaviour
{
    public Collider2D ball;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision = ball)
        {
            Debug.Log("restart game");
            //SceneManager.LoadScene("MainGame");
        }
    }
}
