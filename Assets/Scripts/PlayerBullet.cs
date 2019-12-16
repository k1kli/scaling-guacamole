using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerBullet : Bullet
{
    public Transform explosionPrefab;
    public Transform bulletHolePrefab;
    protected override void OnHit(Collider other)
    {
        if(other.CompareTag("Environment"))
        {
            Debug.Log("hit env");
            Transform bullet = Instantiate(bulletHolePrefab);
            Vector3 pos = transform.position - direction*0.2f;
            Vector3 closest = other.ClosestPoint(pos);
            bullet.transform.up = Vector3.Normalize(pos-closest);
            bullet.localScale *= Random.Range(0.7f, 1.3f);
            bullet.Rotate(0, Random.Range(0, 360.0f), 0);
            Debug.Log("hit normal" + bullet.transform.up);
            bullet.localPosition = closest;
        }
    }
}