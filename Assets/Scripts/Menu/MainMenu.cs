using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnClickPlay()
    {
        Debug.Log("lance MainGame");
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void OnClickQuit()
    {
        Debug.Log("Quitte le jeu");
        Application.Quit();
    }
}
