﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryCannonBullet : Bullet
{
    public Transform explosionPrefab;
    protected override void OnHit()
    {
        Transform explosion = Instantiate<Transform>(explosionPrefab, transform);
    }
}