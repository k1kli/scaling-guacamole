using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryCannon : Enemy {
    public Transform headTransform;
    private Transform playerTransform;
    private readonly float speed = 1;

    private void OnEnable() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        headTransform.LookAt(playerTransform);
    }

    // Update is called once per frame
    void Update() {
        headTransform.LookAt(playerTransform);
    }
}
