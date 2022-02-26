using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine;

public class FadeSystem : MonoBehaviour
{
    public Image fade;
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

    public void MakeFadeON()
    {
        fade.DOFade(1, timeFadeON);
    }
    public void MakeFadeOff()
    {
        fade.DOFade(0, timeFadeOFF);
    }
}
