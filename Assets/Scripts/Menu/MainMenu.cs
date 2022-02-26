using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    const float timeFadeON = .4f;
    const float timeFadeOFF = .9f;

    public void OnClickPlay()
    {
        StartCoroutine(LaunchMainGame());
        FadeSystem.Instance.MakeFadeON();
    }

    IEnumerator LaunchMainGame()
    {
        yield return new WaitForSeconds(timeFadeON);
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void OnClickQuit()
    {
        Debug.Log("Quitte le jeu");
        StartCoroutine(LeaveGame());
    }

    IEnumerator LeaveGame()
    {
        yield return new WaitForSeconds(timeFadeOFF);
        Application.Quit();
    }
}
