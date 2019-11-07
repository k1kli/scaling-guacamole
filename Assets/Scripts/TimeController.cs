using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public float slowedTimescale = 0.1f;
    public float normalTimescale = 1.0f;
    private float defaultFixedDeltaTime;
    // Start is called before the first frame update
    void Start()
    {
        defaultFixedDeltaTime = Time.fixedDeltaTime;
        SetSlowedTimescale();
    }

    public void SetNormalTimescale()
    {
        Time.timeScale = normalTimescale;
        Time.fixedDeltaTime = defaultFixedDeltaTime * normalTimescale;
    }
    public void SetSlowedTimescale()
    {
        Time.timeScale = slowedTimescale;
        Time.fixedDeltaTime = defaultFixedDeltaTime * slowedTimescale;
    }

}
