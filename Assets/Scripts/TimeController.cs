using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public float slowTimescale = 0.1f;
    public float normalTimescale = 1.0f;
    private bool disabled;
    private float defaultFixedDeltaTime;
    UnityEngine.UI.Slider energyIndicator = null;
    void Start()
    {
        energyIndicator = (UnityEngine.UI.Slider)GameObject.FindGameObjectWithTag("EnergyIndicator").GetComponent("Slider");
        defaultFixedDeltaTime = Time.fixedDeltaTime;
        SetTimescale(normalTimescale);
    }
    public void SetTimescale(float timeScale)
    {
        if (disabled) return;
        Time.timeScale = timeScale;
        Time.fixedDeltaTime = defaultFixedDeltaTime * Time.timeScale;
    }
    public void Disable() => disabled = true;
    public void Enable() => disabled = false;

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && (float)energyIndicator.value > Time.unscaledDeltaTime* 100.0f)
        {
            energyIndicator.value -= Time.unscaledDeltaTime * 100.0f;
            SetTimescale(slowTimescale);
        }
        else
        {
            if (energyIndicator.value <= 500.0f)
                energyIndicator.value += Time.unscaledDeltaTime * 50.0f;
            SetTimescale(normalTimescale);
        }
    }

}
