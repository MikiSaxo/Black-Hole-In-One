using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class LevelInfoUI : MonoBehaviour
{
    public GameObject[] yellowStars;
    public GameObject isUnlockedd;
    public Image whiteCircle;
    public Color initialColor;
    public Color selectedColor;
    public TextMeshProUGUI numbers;
    LevelInfos _info;

    /*public static LevelInfoUI Instance;
    private void Awake()
    {
        Instance = this;
    }*/
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
        //Refresh();
    }

    public void OnPointerEnter()
    {
        if (_info.isUnlocked)
        {
            Debug.Log("Pointer Enter");
            whiteCircle.DOKill();
            whiteCircle.DOColor(selectedColor, .2f);
            numbers.DOKill();
            numbers.DOColor(selectedColor, .2f);
        }
    }

    public void OnPointerExit()
    {
        if (_info.isUnlocked)
        {
            whiteCircle.DOKill();
            whiteCircle.DOColor(initialColor, .1f);
            numbers.DOKill();
            numbers.DOColor(initialColor, .1f);
        }
    }

    public void OnPointerClick()
    {
        if (_info.isUnlocked)
            PauseMenu.Instance.ChooseALevel();
        //OnPointerExit();
    }
}
