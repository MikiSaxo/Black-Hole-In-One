using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Animator camAnim;

    public static CameraShake Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void CamShake()
    {
        camAnim.SetTrigger("StartShake");
    }
}
