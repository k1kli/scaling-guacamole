using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public float slowTimescale = 0.05f;
    public float normalTimescale = 1.0f;
    private float defaultFixedDeltaTime;
    void Start()
    {
        defaultFixedDeltaTime = Time.fixedDeltaTime;
        SetTimescale(normalTimescale);
    }
    public void SetTimescale(float timeScale)
    {
        Time.timeScale = timeScale;
        Time.fixedDeltaTime = defaultFixedDeltaTime * Time.timeScale;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            SetTimescale(slowTimescale);
        else
            SetTimescale(normalTimescale);
    }

}
