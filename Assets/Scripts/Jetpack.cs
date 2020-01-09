using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour
{
    public Transform bodyTransform;
    public float maxJetpackFuel = 300.0f;
    public float idleFuelRegen = 10.0f;
    public float fuelConsumptionPerSecond=30.0f;
    public float speedMultiplier = 100.0f;
    private Rigidbody body;
    private float fuel;
    private float RemainingJetpackFuel
    {
        get => fuel;
        set
        {
            fuel = Mathf.Min(value, maxJetpackFuel);
            fuelSlider.value = fuel;
        }
    }
    public UnityEngine.UI.Slider fuelSlider = null;

    private void OnEnable()
    {
        fuelSlider.maxValue = maxJetpackFuel;
        RemainingJetpackFuel = maxJetpackFuel;
        body = bodyTransform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float upInput = Input.GetAxis("Jump");
        float fuelUsage = fuelConsumptionPerSecond * Time.deltaTime;
        if(Mathf.Abs(upInput) > float.Epsilon && RemainingJetpackFuel >= fuelUsage)
        {
            body.velocity += Vector3.up * upInput * Time.deltaTime * speedMultiplier;
            RemainingJetpackFuel -= fuelUsage;
        }
        else
        {
            RemainingJetpackFuel += idleFuelRegen * Time.deltaTime;
        }


    }
}
