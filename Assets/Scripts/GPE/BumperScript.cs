using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BumperScript : MonoBehaviour
{
    public Rigidbody2D rbBall;
    public Collider2D c_bumper;
    //private Rigidbody2D rb;
    private float initialPos;
    public float power;
    public float maxHighExpend = 1f;
    public float timeExpend = .05f;
    public float timeRecover = 1.5f;
    public float timeToLauchBumper = .1f;

    private void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        initialPos = gameObject.transform.position.y;
        //Debug.Log("iniPos : " + initialPos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("touch bumper");
        StartCoroutine(Bump());
        
    }

    IEnumerator Bump()
    {
        yield return new WaitForSeconds(timeToLauchBumper);
        rbBall.AddForce(transform.up * power, ForceMode2D.Impulse);
        c_bumper.isTrigger = false;
        gameObject.transform.DOMoveY(gameObject.transform.position.y + maxHighExpend, timeExpend).OnComplete(InitialPosition);
    }

    void InitialPosition()
    {
        Debug.Log("bumper revient à sa place");
        gameObject.transform.DOMoveY(initialPos, timeRecover);
        c_bumper.isTrigger = true;
    }
}
