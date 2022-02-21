using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageLevel : MonoBehaviour
{
    public GameObject[] SpawnPoint;
    public Collider2D[] EndPoint;

    private void Start()
    {
        gameObject.transform.position = SpawnPoint[0].transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision = EndPoint[0])
        {
            Debug.Log("endpoint");
            gameObject.transform.position = SpawnPoint[1].transform.position;
        }
    }
}
