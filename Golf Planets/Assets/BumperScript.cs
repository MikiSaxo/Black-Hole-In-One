using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BumperScript : MonoBehaviour
{
    public Rigidbody2D rbBall;
    private float initialPos;
    public float power = 100f;
    public float maxHighExpend = 1f;
    public float timeExpend = .05f;
    public float timeRecover = 1.5f;

    private void Start()
    {
        initialPos = gameObject.transform.position.y;
        //Debug.Log("iniPos : " + initialPos);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("touch bumper");
        rbBall.AddForce(transform.up * power, ForceMode2D.Impulse);
        gameObject.transform.DOMoveY(gameObject.transform.position.y + maxHighExpend, timeExpend).OnComplete(InitialPosition);

    }

    void InitialPosition()
    {
        Debug.Log("bumper revient à sa place");
        gameObject.transform.DOMoveY(initialPos, timeRecover);
    }
}
