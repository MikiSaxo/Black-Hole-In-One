using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering;
using UnityEngine;


public class PostProcessingCamera : MonoBehaviour
{
    public PostProcessVolume volume;
    ColorGrading colorGrading;

    public static PostProcessingCamera Instance;
    private void Awake()
    {
        Instance = this;
    }


    private void Start()
    {
        volume.profile.TryGetSettings(out colorGrading);
    }
    public void ChangeColor(bool value)
    {
        //Debug.Log("Passe en gris");
        colorGrading.active = value;
    }
}
