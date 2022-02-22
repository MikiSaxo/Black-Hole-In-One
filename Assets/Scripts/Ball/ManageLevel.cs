using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageLevel : MonoBehaviour
{
    public int howManyShoot;
    public int[] howManyShootNeeded;
    public GameObject[] Stars;
    public TrailRenderer tr;
    public GameObject[] SpawnPoint;
    public Collider2D[] EndPoint;
    public GameObject nextLevelMenu;
    public Rigidbody2D rb;
    public float timeForSpawnUIAtEnd = .5f;
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
            Debug.Log("endpoint");
            StartCoroutine(Transi());
            camRipple.RippleEffect();
            rb.velocity = Vector2.zero;
            if (howManyShoot <= howManyShootNeeded[cntEnd])
            {
                for (int i = 0; i < Stars.Length; i++)
                {
                    Stars[i].SetActive(true);
                }
            }
            howManyShoot = 0;
            //Time.timeScale = 0f;
        }
    }

    IEnumerator Transi()
    {
        yield return new WaitForSeconds(timeForSpawnUIAtEnd);
        cntEnd++;
        tr.emitting = false;
        nextLevelMenu.SetActive(true);

    }
}
