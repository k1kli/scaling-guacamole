using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 direction = Vector3.zero;
    public float speed = 10f;
    public string targetTag;
    // Start is called before the first frame update
    public void Init(Vector3 direction)
    {
        this.direction = direction;
        transform.forward = direction;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit something");
        if (other.CompareTag(targetTag))
        {
            Debug.Log("hit player");
            var damageTaker = other.gameObject.GetComponentInParent<DamageTaker>();
            damageTaker.TakeDamage(10);
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BoundingSphere"))
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
