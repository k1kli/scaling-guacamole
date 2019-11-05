using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public float slowedTimescale = 0.1f;
    public float normalTimescale = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = slowedTimescale;
    }

    public void SetNormalTimescale()
    {
        Time.timeScale = normalTimescale;
    }
    public void SetSlowedTimescale()
    {
        Time.timeScale = slowedTimescale;
    }

}
