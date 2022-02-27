using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;


public class HoverButton : MonoBehaviour
{
    public Color initialColor;
    public Color selectedColor;
    public Image whiteContour;
    public TextMeshProUGUI text;

    public void OnPointerEnter()
    {
        whiteContour.DOKill();
        whiteContour.DOColor(selectedColor, .2f);
        text.DOKill();
        text.DOColor(selectedColor, .2f);
    }

    public void OnPointerExit()
    {
        whiteContour.DOKill();
        whiteContour.DOColor(initialColor, .1f);
        text.DOKill();
        text.DOColor(initialColor, .1f);
    }
}
