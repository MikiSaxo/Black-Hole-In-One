using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBlackHole : MonoBehaviour
{
    public GameObject planet;

    public float maxGravity;
    public float maxGravityDist;
    public Rigidbody2D rb;

    private void Update()
    {
        float dist = Vector2.Distance(planet.transform.position, transform.position);


        if (dist <= maxGravityDist)
        {
            Vector3 v = planet.transform.position - transform.position;
            rb.AddForce(v.normalized * (1f - dist / maxGravityDist) * maxGravity);
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(planet.transform.position, maxGravityDist);
    }
}
