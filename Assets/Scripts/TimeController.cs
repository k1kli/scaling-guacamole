using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public float noMoveTimescale = 0.05f;
    public float rotateTimescale = 0.5f;
    public float maxTimescale = 1.0f;
    private float defaultFixedDeltaTime;
    void Start()
    {
        defaultFixedDeltaTime = Time.fixedDeltaTime;
        SetTimescale(false,false);
    }
    public void SetTimescale(bool cameraRotate, bool moveKeyPressed)
    {
        if (cameraRotate)
            Time.timeScale = rotateTimescale;
        else if (moveKeyPressed)
            Time.timeScale = maxTimescale;
        else
            Time.timeScale = noMoveTimescale;
        Time.fixedDeltaTime = defaultFixedDeltaTime * Time.timeScale;
    }

}
