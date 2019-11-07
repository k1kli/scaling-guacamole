using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 direction = Vector3.zero;
    public float speed = 10f;
    // Start is called before the first frame update
    public void Init(Vector3 direction)
    {
        this.direction = direction;
        transform.forward = direction;
    }
    private void OnCollisionEnter(Collision collision)
    {
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.collider.CompareTag("BoundingSphere"))
        {
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
