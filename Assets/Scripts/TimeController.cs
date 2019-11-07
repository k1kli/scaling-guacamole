using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public float noMoveTimescale = 0.05f;
    public float rotateTimescale = 0.25f;
    public float maxTimescale = 1.0f;
    private float defaultFixedDeltaTime;
    void Start()
    {
        defaultFixedDeltaTime = Time.fixedDeltaTime;
        SetTimescale(false,false, 0f);
    }
    public void SetTimescale(bool cameraRotate, bool moveKeyPressed, float speed)
    {
        if (cameraRotate && Time.timeScale < rotateTimescale)
            Time.timeScale = rotateTimescale;
        if (moveKeyPressed)
            Time.timeScale = maxTimescale;
        if (!moveKeyPressed && !cameraRotate)
            Time.timeScale = noMoveTimescale;

        Time.fixedDeltaTime = defaultFixedDeltaTime * Time.timeScale;
    }

}
