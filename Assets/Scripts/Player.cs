﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : DamageTaker
{
    public Transform cameraTransform;
    public Transform cameraHorizontalRotator;
    public Transform bodyTransform;

    public TimeController timeController;
    private Rigidbody body;

    public PlayerBullet bulletPrefab;

    private Vector3 cameraRelativePos;

    public float cameraSpeedX = 300.0f;
    public float cameraSpeedY = 300.0f;

    public float playerSpeedForward = 2.0f;
    public float playerSpeedSideways = 2.0f;
    public float PlayerJumpPower = 2.0f;

    private float reloadProgress = 0.0f;
    public float reloadTime = 0.3f;


    private bool readyToShoot = true;


    UnityEngine.UI.Slider healthBar = null;

    public event System.Action ReloadStart;
    public event System.Action ReloadEnd;

    private void OnEnable()
    {
        body = bodyTransform.GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        var playerMaxHP = 20f;
        Init(playerMaxHP);
        healthBar = (UnityEngine.UI.Slider)GameObject.FindGameObjectWithTag("HealthBar").GetComponent("Slider");
        healthBar.value = healthBar.maxValue = playerMaxHP;
        cameraRelativePos = cameraHorizontalRotator.position - bodyTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CameraMovement();
        PlayerMovement();
        ShootingControl();
    }

    private void ShootingControl()
    {
        if (!readyToShoot)
        {
            reloadProgress += Time.deltaTime;
            if (reloadProgress >= reloadTime)
            {
                readyToShoot = true;
                ReloadEnd();
            }
        }
        else if (Input.GetMouseButton(0))
        {
            StartCoroutine(Shoot());
        }
    }

    void CameraMovement()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        if (Mathf.Abs(mouseX) > float.Epsilon)
        {
            cameraHorizontalRotator.Rotate(0.0f, mouseX * cameraSpeedX * Time.unscaledDeltaTime, 0.0f);
        }
        if (Mathf.Abs(mouseY) > float.Epsilon)
        {
            cameraTransform.Rotate(-mouseY * cameraSpeedY * Time.unscaledDeltaTime, 0.0f, 0.0f);

            Vector3 cameraEulerAngles = cameraTransform.localEulerAngles;
            if (cameraEulerAngles.y > 90.0f && cameraEulerAngles.x < 180.0f)
            {
                cameraEulerAngles = new Vector3(90.0f, 0, 0);
            }
            else
            if (cameraEulerAngles.y > 90.0f && cameraEulerAngles.x > 180.0f)
            {
                cameraEulerAngles = new Vector3(270.0f, 0, 0);
            }
            cameraTransform.localEulerAngles = cameraEulerAngles;

        }
    }
    void PlayerMovement()
    {
        Vector2 movement;
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        if (movement.sqrMagnitude > 1f)
            movement.Normalize();
        if (Mathf.Abs(movement.x) > float.Epsilon)
        {
            Vector3 right = cameraHorizontalRotator.right;
            body.AddForce(movement.x * right * playerSpeedSideways);
        }
        if (Mathf.Abs(movement.y) > float.Epsilon)
        {
            Vector3 forward = cameraHorizontalRotator.forward;
            body.AddForce(movement.y * forward * playerSpeedForward);
        }
    }
    public void MovePlayer(Vector3 targetPos, Quaternion targetRotation)
    {
        bodyTransform.position = targetPos;
        bodyTransform.rotation = targetRotation;
        cameraHorizontalRotator.position = bodyTransform.position + cameraRelativePos;
        body.velocity = Vector3.zero;
    }
    private void LateUpdate()
    {
        cameraHorizontalRotator.position = bodyTransform.position + cameraRelativePos;
    }
    IEnumerator Shoot()
    {
        ReloadStart?.Invoke();
        Bullet bullet = Instantiate<PlayerBullet>(bulletPrefab);
        bullet.transform.localPosition = cameraTransform.position + cameraTransform.forward * 0.7f;
        bullet.Init(cameraTransform.forward);
        readyToShoot = false;
        reloadProgress =0;
        yield return null;
    }
    public override void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    protected override void OnDamageTaken(float amount) {
        healthBar.value = Health;
    }
}
