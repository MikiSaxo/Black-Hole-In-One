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

    private void Start()
    {
        gameObject.transform.position = SpawnPoint[0].transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == EndPoint[cntEnd])
        {
            Debug.Log("endpoint");
            cntEnd++;
            tr.enabled = false;
            nextLevelMenu.SetActive(true);
            Time.timeScale = 0f;
            gameObject.transform.position = SpawnPoint[cntSpawn].transform.position;
            rb.velocity = Vector2.zero;
            tr.enabled = true;
            cntSpawn++;
        }
    }
}
