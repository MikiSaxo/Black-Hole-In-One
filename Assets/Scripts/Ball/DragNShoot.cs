using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNShoot : MonoBehaviour
{
    public float power = 10f;
    public float ValueToReShoot = .01f;

    public Rigidbody2D rb;
    public SpriteRenderer sprBall;

    public Vector2 minPower;
    public Vector2 maxPower;

    TrajectoryLine tl;

    Camera cam;
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;


    private void Start()
    {
        cam = Camera.main;
        tl = GetComponent<TrajectoryLine>();
    }

    private int collisionCount = 0;

    public bool IsNotColliding
    {
        get { return collisionCount == 0; }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisionCount = 1;

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collisionCount = 0;
    }

    private void Update()
    {
        Debug.Log(rb.velocity.magnitude);
        if (rb.velocity.magnitude <= ValueToReShoot && collisionCount == 1)
        {
            sprBall.color = Color.green;
            rb.velocity = Vector2.zero;
            if (Input.GetMouseButtonDown(0))
            {
                startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                startPoint.z = 15;
            }

            if (Input.GetMouseButton(0))
            {
                Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                currentPoint.z = 15;
                tl.RenderLine(startPoint, currentPoint);
            }

            if (Input.GetMouseButtonUp(0))
            {
                endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                endPoint.z = 15;

                force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
                rb.AddForce(force * power, ForceMode2D.Impulse);
                tl.EndLine();
            }
        }
        else
        {
            sprBall.color = Color.white;
        }
    }
}
