using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public GameObject ball;

    public float maxGravity;
    public float maxGravityDist;
    public Rigidbody2D rbBall;

    private void Update()
    {
        float dist = Vector2.Distance(ball.transform.position, transform.position);


        if (dist <= maxGravityDist && !PauseMenu.Instance.GameIsPaused)
        {
            Vector3 v = ball.transform.position - transform.position;
            rbBall.AddForce(v.normalized * (1f - dist / maxGravityDist) * maxGravity * -1);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(gameObject.transform.position, maxGravityDist);
    }
}
