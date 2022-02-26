using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject nextLevel;
    public GameObject ball;
    public Rigidbody2D rbBall;
    public GameObject selectedlevels;
    public Image fade;
    public int hasChooseLevel;

    const float timeFadeON = .4f;
    const float timeFadeOFF = .9f;
    const int moveSelectLevel = 467;
    const float avoidSameTic = .01f;

    public static PauseMenu Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        nextLevel.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
        //rbBall.velocity = Vector2.zero;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void NextLevel()
    {
        hasChooseLevel++;
        StartCoroutine(TpBall());
        for (int i = 0; i < ManageLevel.Instance.Stars.Length; i++)
        {
            ManageLevel.Instance.Stars[i].SetActive(false);
        }
        pauseMenuUI.SetActive(false);
        nextLevel.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        ManageLevel.Instance.howManyShoot--;
    }
    IEnumerator TpBall()
    {
        ball.transform.position = ManageLevel.Instance.SpawnPoint[ManageLevel.Instance.cntSpawn-1].transform.position;
        yield return new WaitForSeconds(avoidSameTic);
        StartCoroutine(StopBall());
        ManageLevel.Instance.tr.emitting = true;
    }

    public void ChooseALevel(int whichLevel)
    {
        ball.transform.position = ManageLevel.Instance.SpawnPoint[whichLevel].transform.position;
        hasChooseLevel = whichLevel;
        MakeSldLevelsDisappear();
        StartCoroutine(StopBall());
        //pauseMenuUI.SetActive(false);
        //nextLevel.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        ManageLevel.Instance.howManyShoot--;
    }
    IEnumerator StopBall()
    {
        yield return new WaitForSeconds(avoidSameTic);
        rbBall.velocity = Vector2.zero;
    }

    public void Restart()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ball.transform.position = ManageLevel.Instance.SpawnPoint[hasChooseLevel].transform.position;
        StartCoroutine(StopBall());
        Time.timeScale = 1f;
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
        ManageLevel.Instance.howManyShoot = 0;
    }

    //public void RestartForEndOfLevel()
    //{
    //    ManageLevel.Instance.cntEnd--;
    //}

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void MakeSldLevelsDisappear()
    {
        StartCoroutine(LevelsDisappear());
    }
    public void MakeSldLevelsAppear()
    {
        rbBall.velocity = Vector2.zero;
        Time.timeScale = 1;
        StartCoroutine(LevelsAppear());
        ManageLevel.Instance.howManyShoot = 0;
    }

    IEnumerator LevelsDisappear()
    {
        MakeFadeON();
        yield return new WaitForSeconds(timeFadeON);
        selectedlevels.transform.position += new Vector3(0, moveSelectLevel, 0);
        MakeFadeOff();
    }

    IEnumerator LevelsAppear()
    {
        MakeFadeON();
        yield return new WaitForSeconds(timeFadeON);
        selectedlevels.transform.position += new Vector3(0, -moveSelectLevel, 0);
        MakeFadeOff();
    }

    public void MakeFadeON()
    {
        fade.DOFade(1, timeFadeON);
    }
    public void MakeFadeOff()
    {
        fade.DOFade(0, timeFadeOFF);
    }
}
