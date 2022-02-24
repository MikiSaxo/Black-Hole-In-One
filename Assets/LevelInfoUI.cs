using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfoUI : MonoBehaviour
{
    public GameObject[] yellowStars;
    public GameObject isUnlockedd;
    LevelInfos _info;
    private void Start()
    {
        Refresh();
    }

    public void Initialize(LevelInfos info)
    {
        _info = info;
        Refresh();
    }

    internal void Refresh()
    {
        if (_info.isUnlocked)
        {
            Debug.Log("Cadena unlock");
            isUnlockedd.SetActive(false);
        }

        for (int i = 0; i < _info.yellowStars; i++)
        {
            Debug.Log("Met les étoiles qu'il faut au select");
            yellowStars[i].SetActive(true);
        }
    }

    public void OnPointerEnter()
    {
        if (_info.isUnlocked)
            Debug.Log("Hello bro");
    }
}
