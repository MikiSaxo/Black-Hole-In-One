using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageLevel : MonoBehaviour
{
    public int howManyShoot;
    public int[] howManyShootNeeded;
    public int howManyStars;
    public TrailRenderer tr;
    public GameObject[] Stars;
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
        if (collision == EndPoint[PauseMenu.Instance.hasChooseLevel])
        {
            Debug.Log("endpoint");
            StartCoroutine(Transi());
            camRipple.RippleEffect();
            rb.velocity = Vector2.zero;
            if (howManyShoot <= howManyShootNeeded[PauseMenu.Instance.hasChooseLevel])
            {
                howManyStars = 3;
                Debug.Log("Active 3 étoiles");
                for (int i = 0; i < Stars.Length; i++)
                {
                    Stars[i].SetActive(true);
                }
            }
            else if (howManyShoot > howManyShootNeeded[PauseMenu.Instance.hasChooseLevel] && howManyShoot <= howManyShootNeeded[PauseMenu.Instance.hasChooseLevel] + 2)
            {
                howManyStars = 2;
                Debug.Log("Active 2 étoiles");
                for (int i = 0; i < Stars.Length - 1; i++)
                {
                    Stars[i].SetActive(true);
                }
            }
            else
            {
                Stars[0].SetActive(true);
                howManyStars = 1;
            }

            SelectLevels.Instance.UpdateLevelInfos(PauseMenu.Instance.hasChooseLevel, howManyStars);
            howManyShoot = 0;
            cntSpawn++;
            PauseMenu.Instance.GameIsPaused = true;
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
