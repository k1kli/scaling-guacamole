using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public float noMoveTimescale = 0.05f;
    public float rotateTimescale = 0.5f;
    public float maxTimescale = 1.0f;
    [Range(0.0f, 1.0f)]
    public float movementInfluencePowerFactor = 0.7f;
    public float cameraRotationInfluenceLimit = 3f;

    private float defaultFixedDeltaTime;
    private float cameraRotationEffect = 0.0f;
    private float movementEffect = 0.0f;

    void Start()
    {
        defaultFixedDeltaTime = Time.fixedDeltaTime;
    }
    public void SetCameraRotationInfluence(float cameraRotationX, float cameraRotationY)
    {
        cameraRotationEffect = 
            Mathf.Clamp(Mathf.Abs(cameraRotationX + cameraRotationY), 0f, cameraRotationInfluenceLimit)
            / cameraRotationInfluenceLimit;
    }
    public void SetMovementInfluence(float movementMagnitude)
    {
        movementEffect = Mathf.Pow(movementMagnitude, movementInfluencePowerFactor);
    }
    private void SetTimescale()
    {
        float currentTimeScale = Mathf.Max(
            noMoveTimescale,
            rotateTimescale * cameraRotationEffect,
            maxTimescale * movementEffect
            );
        Time.timeScale = currentTimeScale;
        Time.fixedDeltaTime = defaultFixedDeltaTime * currentTimeScale;
        cameraRotationEffect = 0f;
        movementEffect = 0f;
    }
    private void LateUpdate()
    {
        SetTimescale();
    }

}
