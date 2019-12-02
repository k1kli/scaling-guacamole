using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageTaker : MonoBehaviour {
    public float Health { get; private set; }
    public virtual void Init(float health) {
        Health = health;
    }
    public void TakeDamage(float damage) {
        Health -= EffectiveDamage(damage);
        Debug.Log("Oof");
        if (Health <= 0)
            Die();
    }
    protected virtual float EffectiveDamage(float damage) {
        return damage;
    }
    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
