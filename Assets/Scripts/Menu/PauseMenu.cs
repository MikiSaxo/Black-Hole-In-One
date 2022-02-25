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
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void NextLevel()
    {
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
        yield return new WaitForSeconds(.01f);
        StartCoroutine(StopBall());
        ManageLevel.Instance.tr.emitting = true;
    }

    IEnumerator StopBall()
    {
        yield return new WaitForSeconds(.01f);
        rbBall.velocity = Vector2.zero;
    }

    public void ChooseALevel()
    {
        ball.transform.position = ManageLevel.Instance.SpawnPoint[ManageLevel.Instance.cntSpawn-1].transform.position;
        MakeSldLevelsDisappear();
        StartCoroutine(StopBall());
        //pauseMenuUI.SetActive(false);
        //nextLevel.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        ManageLevel.Instance.howManyShoot--;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Restart()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ball.transform.position = ManageLevel.Instance.SpawnPoint[ManageLevel.Instance.cntSpawn-1].transform.position;
        StartCoroutine(StopBall());
        Time.timeScale = 1f;
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
        ManageLevel.Instance.howManyShoot--;
    }

    public void RestartForEndOfLevel()
    {
        ManageLevel.Instance.cntEnd--;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void MakeSldLevelsDisappear()
    {
        //selectedlevels.SetActive(false);
        StartCoroutine(LevelsDisappear());
    }

    IEnumerator LevelsDisappear()
    {
        MakeFadeON();
        yield return new WaitForSeconds(.5f);
        selectedlevels.transform.DOMoveY(680, .01f);
        yield return new WaitForSeconds(.1f);
        MakeFadeOff();

    }

    public void MakeFadeON()
    {
        fade.DOFade(1, .5f);
    }
    public void MakeFadeOff()
    {
        Debug.Log("go fade off");
        fade.DOFade(0, .9f);
    }

    public void MakeSldLevelsAppear()
    {
        Time.timeScale = 1;
        selectedlevels.transform.DOMoveY(210, .01f).OnComplete(MakeTimeScaleOff);
        ManageLevel.Instance.howManyShoot = 0;
        //selectedlevels.SetActive(true);
    }

    void MakeTimeScaleOff()
    {
        Time.timeScale = 0;
    }
}
