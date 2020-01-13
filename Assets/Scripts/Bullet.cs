using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    protected Vector3 direction = Vector3.zero;
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
        Debug.Log($"hit {other.gameObject.tag}");
        if (other.CompareTag(targetTag))
        {
            Debug.Log("hit player");
            var damageTaker = other.gameObject.GetComponentInParent<DamageTaker>();
            damageTaker.TakeDamage(10);
        }
        OnHit(other);
        Destroy(gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BoundingSphere"))
        {
            Destroy(this.gameObject);
        }
    }

    virtual protected void OnHit(Collider other) { }
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}