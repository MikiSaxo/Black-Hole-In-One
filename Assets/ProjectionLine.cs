using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProjectionLine : MonoBehaviour
{
    public Rigidbody2D rb;
    public LineRenderer lr;
    Vector2 DragStartPos;
    //public int power;
    //public Vector2 power2;
    //public int numberOfPoints;
    //public GameObject ghostPoints;

    private void Start()
    {
        //power = DragNShoot.Instance.power;
    }

    private void Update()
    {
        
    }
    //public static Vector2[] PreviewPhysics(Rigidbody2D rb, Vector2 pos, Vector2 velocity, int steps)
    //{
    //    Vector2[] results = new Vector2[steps];

    //    float timestep = Time.fixedDeltaTime;
    //    Vector2 gravityAccel = Physics2D.gravity * rb.gravityScale * timestep * timestep;
    //    float drag = 1f - timestep * rb.drag;
    //    Vector2 moveStep = velocity * timestep;

    //    for (int i = 0; i < steps; i++)
    //    {
    //        moveStep += gravityAccel;
    //        moveStep *= drag;
    //        pos += moveStep;
    //        results[i] = pos;
    //    }

    //    return results;
    //}

    //private void OnDrawGizmos()
    //{
    //    Vector2[] points = PreviewPhysics(rb, rb.transform.position, new Vector2((DragNShoot.Instance.startPoint.x - DragNShoot.Instance.endPoint.x) * DragNShoot.Instance.force.x, (DragNShoot.Instance.startPoint.y - DragNShoot.Instance.endPoint.y) * DragNShoot.Instance.force.y), numberOfPoints);
    //    //Vector2[] points = PreviewPhysics(rb, rb.transform.position, new Vector2(DragNShoot.Instance.power / rb.mass, DragNShoot.Instance.power / rb.mass), 200);
    //    //Vector2[] points = PreviewPhysics(rb, rb.transform.position, Vector2.up, 200);

    //    foreach (var item in points)
    //    {
    //        Gizmos.DrawSphere(item, .1f);
    //    }


    //}
}

