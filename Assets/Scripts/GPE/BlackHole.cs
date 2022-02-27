using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public float maxGravity;
    public float maxGravityDist;
    public GameObject ball;
    public Rigidbody2D rbBall;
    bool isSoundLaunch;

    private void Update()
    {
        float dist = Vector2.Distance(ball.transform.position, transform.position);
        

        if (dist <= maxGravityDist && !PauseMenu.Instance.GameIsPaused)
        {
            Vector3 v = ball.transform.position - transform.position;
            rbBall.AddForce(v.normalized * (1f - dist / maxGravityDist) * maxGravity * -1);
        }

        if (dist <= maxGravityDist)
        {
            if (!isSoundLaunch)
            {
                isSoundLaunch = true;
                AudioManager.Instance.PlaySound("BlackHole");
                //Debug.Log("Launch BlackHole sound");
                //Debug.Log("isSoundLaunch " + isSoundLaunch);
            }
        }
        else        
        {
            isSoundLaunch = false;
            //AudioManager.Instance.StopSound("BlackHole");
            //Debug.Log("Stop BlackHole sound");
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(gameObject.transform.position, maxGravityDist);
    }
}
