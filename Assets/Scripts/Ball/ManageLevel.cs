using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageLevel : MonoBehaviour
{
    public TrailRenderer tr;
    public GameObject[] SpawnPoint;
    public Collider2D[] EndPoint;
    public GameObject nextLevelMenu;
    public Rigidbody2D rb;
    public int cntEnd = 0;
    public int cntSpawn = 1;
    [SerializeField] private RipplePostProcessor camRipple;

    public static ManageLevel Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        gameObject.transform.position = SpawnPoint[0].transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == EndPoint[cntEnd])
        {
            //StartCoroutine(Transi());
            Debug.Log("endpoint");
            camRipple.RippleEffect();
            cntEnd++;
            tr.emitting = false;
            nextLevelMenu.SetActive(true);
            //Time.timeScale = 0f;
            rb.velocity = Vector2.zero;
        }
    }

    //IEnumerator Transi()
    //{
    //    Debug.Log("endpoint");
    //    cntEnd++;
    //    tr.emitting = false;
    //    yield return new WaitForSeconds(.01f);
    //    nextLevelMenu.SetActive(true);
    //    Time.timeScale = 0f;
    //    rb.velocity = Vector2.zero;
    //}
}
