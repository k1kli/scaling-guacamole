using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryCannonBullet : Bullet
{
    public Transform explosionPrefab;
    protected override void OnHit(Collider other)
    {
        Transform explosion = Instantiate<Transform>(explosionPrefab, transform);
    }
}