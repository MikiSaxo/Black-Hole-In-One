using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNShoot : MonoBehaviour
{
    public int power;
    public float ValueToReShoot = .01f;

    public Rigidbody2D rb;
    public SpriteRenderer sprBall;
    public Collider2D[] reShootCollider;
    bool canReShoot;
    public SpriteRenderer canReShootFeedback;
    public Collider2D saveCollider;
    public float timeScaleInZone = .5f;
    const float timeScaleSlowMo = .02f;

    public Vector2 minPower;
    public Vector2 maxPower;

    TrajectoryLine tl;

    Camera cam;
    public Vector2 force;
    public Vector3 startPoint;
    public Vector3 endPoint;
    public LineRenderer lr;

    public static DragNShoot Instance;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        cam = Camera.main;
        tl = GetComponent<TrajectoryLine>();
        //AudioManager.Instance.PlaySound("MusicGame");
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int j = 0; j < reShootCollider.Length; j++)
        {
            if (collision == reShootCollider[j])
            {
                canReShoot = true;
                //cam.GetComponent<PostProcessingCamera>().ChangeColor();
                PostProcessingCamera.Instance.ChangeColor(true);
                saveCollider = collision;
                Time.timeScale = timeScaleInZone;
                Time.fixedDeltaTime = timeScaleSlowMo * Time.timeScale;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        for (int j = 0; j < reShootCollider.Length; j++)
        {
            if (collision == reShootCollider[j])
            {
                canReShoot = false;
                //saveCollider.enabled = true;
                Time.timeScale = 1f;
                Time.fixedDeltaTime = timeScaleSlowMo * Time.timeScale;
                PostProcessingCamera.Instance.ChangeColor(false);

            }
        }
    }

    private void Update()
    {
        //Debug.Log(rb.velocity.magnitude);
        if ((rb.velocity.magnitude <= ValueToReShoot && collisionCount == 1) || canReShoot)
        {
            //sprBall.color = Color.green;
            canReShootFeedback.enabled = true;
            if (!canReShoot)
            {
                rb.velocity = Vector2.zero;
            }
            if (Input.GetMouseButtonDown(0) && !PauseMenu.Instance.GameIsPaused)
            {
                startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                startPoint.z = 15;
            }

            if (Input.GetMouseButton(0) && !PauseMenu.Instance.GameIsPaused)
            {
                Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                currentPoint.z = 15;
                //tl.RenderLine(startPoint, currentPoint);

                
                force = new Vector2(Mathf.Clamp(startPoint.x - currentPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - currentPoint.y, minPower.y, maxPower.y));
                Vector2 _velocity = force * power / 20;

                Vector2[] trajectory = PreviewPhysics(rb, (Vector2)transform.position, _velocity, 100);

                lr.positionCount = trajectory.Length;

                Vector3[] positions = new Vector3[trajectory.Length];
                for (int i = 0; i < trajectory.Length; i++)
                {
                    positions[i] = trajectory[i];
                }
                lr.SetPositions(positions);
            }

            if (Input.GetMouseButtonUp(0) && !PauseMenu.Instance.GameIsPaused)
            {
                ChooseRandomSoundForShoot();
                endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                endPoint.z = 15;
                //CameraShake.Instance.CamShake();
                force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
                rb.AddForce(force * power, ForceMode2D.Impulse);
                //tl.EndLine();
                lr.positionCount = 0;
                if (!PauseMenu.Instance.GameIsPaused)
                {
                    ManageLevel.Instance.howManyShoot++;
                }
                if (canReShoot)
                {
                    canReShoot = false;
                    Time.timeScale = 1f;
                    Time.fixedDeltaTime = timeScaleSlowMo * Time.timeScale;
                    PostProcessingCamera.Instance.ChangeColor(false);
                }
            }
        }
        else
        {
            startPoint = rb.transform.position;
            startPoint.z = 15;
            //sprBall.color = Color.white;
            canReShootFeedback.enabled = false;
        }
    }

    void ChooseRandomSoundForShoot()
    {
        var i = Random.Range(1, 4);
        Debug.Log(i);
        AudioManager.Instance.PlaySound("Tir" + i);
    }

    public static Vector2[] PreviewPhysics(Rigidbody2D rb, Vector2 pos, Vector2 velocity, int steps)
    {
        Vector2[] results = new Vector2[steps];

        float timestep = Time.fixedDeltaTime;
        Vector2 gravityAccel = Physics2D.gravity * rb.gravityScale * timestep * timestep;
        float drag = 1f - timestep * rb.drag;
        Vector2 moveStep = velocity * timestep;

        for (int i = 0; i < steps; i++)
        {
            moveStep += gravityAccel;
            moveStep *= drag;
            pos += moveStep;
            results[i] = pos;
        }

        return results;
    }

}
