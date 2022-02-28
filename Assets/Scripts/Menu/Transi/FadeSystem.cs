using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeSystem : MonoBehaviour
{
    public Image fade;
    public GameObject title;
    bool isTitleOff = true;
    public GameObject main;
    const float timeFadeON = .4f;
    const float timeFadeOFF = .9f;

    public static FadeSystem Instance;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        MakeFadeOff();
    }

    private void Update()
    {
        if (Input.anyKey && isTitleOff)
        {
            MakeTitleOff();
            isTitleOff = false;
        }
    }

    public void MakeFadeON()
    {
        fade.DOFade(1, timeFadeON);
    }
    public void MakeFadeOff()
    {
        fade.DOFade(0, timeFadeOFF);
    }
    public void MakeTitleOff()
    {
        StartCoroutine(TransiTitleToMenu());
    }

    IEnumerator TransiTitleToMenu()
    {
        MakeFadeON();
        yield return new WaitForSeconds(timeFadeON);
        title.SetActive(false);
        main.SetActive(true);
        MakeFadeOff();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
