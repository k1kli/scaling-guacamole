using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryCannon : DamageTaker {
    public Transform headTransform;
    private Transform playerTransform;
    public float reloadTime = 1f;
    private float reloadProgress = 0f;
    public StationaryCannonBullet cannonBallPrefab;

    private void Start() {
        Init(100);
    }

    private void OnEnable() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        headTransform.LookAt(playerTransform);
    }

    // Update is called once per frame
    void Update() {
        headTransform.LookAt(playerTransform);
        Shoot();
    }

    private void Shoot()
    {
        reloadProgress += Time.deltaTime;
        while(reloadProgress >= reloadTime)
        {
            reloadProgress -= reloadTime;
            Bullet cannonBall = GameObject.Instantiate<StationaryCannonBullet>(cannonBallPrefab);
            cannonBall.transform.localPosition = headTransform.position + headTransform.forward * 0.7f;
            cannonBall.Init(headTransform.forward);
        }
    }
}